using doanNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity.Validation;
using Newtonsoft.Json.Linq;
using Microsoft.Ajax.Utilities;
using doanNet.Controllers.DTO;
using System.IO;
using System.Web;

namespace doanNet.ApiControllers
{
    public class ContractController : ApiController
    {
        KTXTDTUEntities2 db = new KTXTDTUEntities2();

        public List<Contract> GetAll()
        {
            return db.Contracts.ToList();
        }


        public Contract GetByContractId(int id)
        {
            return db.Contracts.Where(row => row.IDContract == id).FirstOrDefault();
        }

        public List<Contract> getContractsBySinhVienID(int IDSinhVien)
        {
            return db.Contracts.Where(row => row.IDSinhVien == IDSinhVien).ToList();
        }
        [HttpPut]
        public IHttpActionResult ApproveContract([FromBody] int ContractID)
        {
            var ContractNeedApprove = db.Contracts.Where(row => row.IDContract == ContractID).FirstOrDefault();
            ContractNeedApprove.xetduyet = true;
            db.SaveChangesAsync();
            return Ok(ContractNeedApprove);
        }

        public async Task<IHttpActionResult> AddingContract()
        {

            /*
    public class ContractDTO
                    {
                        public string MSSV { get; set; }
                        public string IDCitizen { get; set; }
                        public int ProfilePlace { get; set; }
                        public string IDPlace { get; set; }
                        public string Description { get; set; }
                        public System.DateTime TimeExpired { get; set; }
                        public int IDPriority { get; set; }
                    }
    */
            // Get form data from the request
            HttpRequestBase request = new HttpContextWrapper(HttpContext.Current).Request;
            var tempContract = new Contract();

            // Handle file upload
            HttpPostedFileBase PDFFile = request.Files["Description"];
            if (PDFFile != null && PDFFile.ContentLength > 0)
            {
                var serverFileName = $"{DateTime.Now.Ticks}_{Path.GetFileName(PDFFile.FileName)}";
                var uploadPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Areas/admin/Content/contract"), serverFileName);
                PDFFile.SaveAs(uploadPath);
                tempContract.Description = serverFileName;
            }
            else
            {
                tempContract.Description = "default.png";
            }
            
            // Set other properties from form data
            tempContract.IDSinhVien = Int32.Parse(request.Form["IDSinhVien"]);
            tempContract.IDCitizen = request.Form["IDCitizen"];
            tempContract.IDPlace = request.Form["IDPlace"];
            tempContract.ProfilePlace = Int32.Parse(request.Form["ProfilePlace"]);
            tempContract.TimeExpired = DateTime.Parse(request.Form["TimeExpired"]);
            tempContract.IDPriority = Int32.Parse(request.Form["IDPriority"]);
            tempContract.xetduyet = false;
            tempContract.DateBegin = DateTime.Now;
            tempContract.Hide = 0;

            // Save the post
            try
            {
                db.Contracts.Add(tempContract);
                await db.SaveChangesAsync();
                return Json(new { Message = "Data received successfully!" });
            }
            catch (DbEntityValidationException e)
            {
                string mes = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    mes += $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:";
                    
                    foreach (var ve in eve.ValidationErrors)
                    {
                        mes += $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";

                        
                    }
                        
                        
                }

                return Json(new { Message = mes});
            }
        }
       
        private bool EntityExists(int id)
        {
            return db.Contracts.Any(e => e.IDContract == id);
        }
        [HttpPut]
        public async Task<IHttpActionResult> PutContract(int? id,[FromBody] Contract Contract)
        {

            try
            {
                var contractmodifier=db.Contracts.Where(row => row.IDContract == id).FirstOrDefault();
                contractmodifier.IDCitizen = Contract.IDCitizen;
                contractmodifier.IDPlace = Contract.IDPlace;
                contractmodifier.ProfilePlace= Contract.ProfilePlace;
                db.Entry(contractmodifier).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                    return Json(new { Message = "Data received successfully!" });

                }
                catch (DbEntityValidationException e)
                {
                    string mes = "";
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        mes += $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:";

                        foreach (var ve in eve.ValidationErrors)
                        {
                            mes += $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";


                        }
                    }
                    return Json(new { Message = mes });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Message = "Adding Failed!Error: " + ex, });
            }
        }
        [HttpPut]
        public IHttpActionResult HiddingContract(int id)
        {
            Contract hideContract = db.Contracts.Where(row => row.IDContract == id).FirstOrDefault();
            hideContract.Hide = hideContract.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }

    }
}
