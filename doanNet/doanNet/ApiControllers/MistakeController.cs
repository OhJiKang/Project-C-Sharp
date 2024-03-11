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

namespace doanNet.ApiControllers
{
    public class MistakeController : ApiController
    {
        KTXTDTUEntities1 db = new KTXTDTUEntities1();

        public List<Mistake> GetAll()
        {
            return db.Mistakes.ToList();
        }


        public Mistake GetByMistakeId(int id)
        {
            return db.Mistakes.Where(row => row.IDMistake == id).FirstOrDefault();
        }

        public Mistake GetBySinhVien(int mssv)
        {
            return db.Mistakes.Where(row => row.SinhVien.MSSV == mssv.ToString()).FirstOrDefault();
        }
        public IHttpActionResult AddingMistake([FromBody] Mistake Mistake)
        {

            try
            {
                db.Mistakes.Add(Mistake);
                db.SaveChangesAsync();
                return Json(new { Message = "Data received successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { Message = "Adding Failed!Error: " + ex, });
            }
        }
        [HttpPut]
        private bool EntityExists(int id)
        {
            return db.Mistakes.Any(e => e.IDMistake == id);
        }
        public async Task<IHttpActionResult> PutMistake(int id, [FromBody] Mistake Mistake)
        {

            try
            {
                db.Entry(Mistake).State = EntityState.Modified;
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
        public IHttpActionResult HiddingMistake(int id)
        {
            Mistake hideMistake = db.Mistakes.Where(row => row.IDMistake == id).FirstOrDefault();
            hideMistake.Hide = hideMistake.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }
    }
}
