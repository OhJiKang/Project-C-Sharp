using doanNet.Controllers.DTO;
using doanNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Services.Description;

namespace doanNet.ApiControllers
{
    public class SinhVienController : ApiController
    {
        KTXTDTUEntities1 db = new KTXTDTUEntities1();

        public List<SinhVien> GetAll()
        {
            return db.SinhViens.ToList();
        }

        public SinhVien GetByMSSV(int id)
        {
            return db.SinhViens.Where(row => row.MSSV == id.ToString()).FirstOrDefault();
        }
        public IHttpActionResult AddingSinhVien([FromBody] SinhVien SinhVien)
        {

            try
            {
                db.SinhViens.Add(SinhVien);
                db.SaveChangesAsync();
                return Json(new { Message = "Data received successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { Message = "Adding Failed!Error: "+ex,});
            }
        }
        [HttpPut]
        private bool EntityExists(int id)
        {
            return db.SinhViens.Any(e => e.IDSinhVien == id);
        }
        public async Task<IHttpActionResult> PutSinhVien(int id,[FromBody] SinhVien SinhVien)
        {

            try
            {
                db.Entry(SinhVien).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Json(new { Message = "Adding Failed!Error: " + ex, });
            }
        }
        [HttpPut]
        public IHttpActionResult HiddingSinhVien(int id)
        {
            SinhVien hideSinhVien = db.SinhViens.Where(row => row.IDSinhVien == id).FirstOrDefault();
            hideSinhVien.Hide = hideSinhVien.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }
    }
}
