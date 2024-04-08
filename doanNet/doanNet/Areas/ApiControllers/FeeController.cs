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
using doanNet.Controllers.DTO;

namespace doanNet.ApiControllers
{
    public class FeeController : ApiController
    {
        KTXTDTUEntities2 db = new KTXTDTUEntities2();

        public List<Fee> GetAll(int? page)
        {
            return db.Fees.ToList();
        }

        public Fee GetByFeeId(int id)
        {
            return db.Fees.Where(row => row.IDFee == id).FirstOrDefault();
        }
        public List<Fee> GetFeeByRoomID(int roomid)
        {
            return db.Fees.Where(row => row.IDRoom == roomid).ToList();
        }
        public IHttpActionResult AddingFee([FromBody] Fee Fee)
        {
            Fee.DateBegin= DateTime.Now;
            Fee.Hide = 0;
            try
            {
                db.Fees.Add(Fee);
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
            return db.Fees.Any(e => e.IDFee == id);
        }
        [HttpPut]
        public async Task<IHttpActionResult> PutFee(int id, [FromBody] Fee Fee)
        {

            try
            {
                db.Entry(Fee).State = EntityState.Modified;
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
                return Json(new { Message = "Putting Success "});
            }
            catch (Exception ex)
            {
                return Json(new { Message = "Putting Failed!Error: " + ex, });
            }
        }
        [HttpPut]
        public IHttpActionResult HiddingFee(int id)
        {
            Fee hideFee = db.Fees.Where(row => row.IDFee == id).FirstOrDefault();
            hideFee.Hide = hideFee.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }
    }
}
