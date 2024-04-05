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
        public IHttpActionResult AddingContract([FromBody] Contract Contract)
        {

            try
            {
                db.Contracts.Add(Contract);
                db.SaveChangesAsync();
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
