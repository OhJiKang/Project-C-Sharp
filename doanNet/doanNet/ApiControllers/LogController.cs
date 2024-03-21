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
    public class LogController : ApiController
    {
        KTXTDTUEntities2 db = new KTXTDTUEntities2();

        public List<Log> GetAll(int? page)
        {
            return db.Logs.ToList();
        }

        public Log GetByLogId(int id)
        {
            return db.Logs.Where(row => row.IDLog == id).FirstOrDefault();
        }
        public List<Log> GetAllByMSSV(int mssv) {
            return db.Logs.Where(row => row.SinhVien.MSSV == mssv.ToString()).ToList();
        }
        public IHttpActionResult AddingLog([FromBody] Log Log)
        {

            try
            {
                db.Logs.Add(Log);
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
            return db.Logs.Any(e => e.IDLog == id);
        }
        public async Task<IHttpActionResult> PutLog(int id, [FromBody] Log Log)
        {

            try
            {
                db.Entry(Log).State = EntityState.Modified;
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
                return Json(new { Message = "Putting Success " });
            }
            catch (Exception ex)
            {
                return Json(new { Message = "Putting Failed!Error: " + ex, });
            }
        }
        [HttpPut]
        public IHttpActionResult HiddingLog(int id)
        {
            Log hideLog = db.Logs.Where(row => row.IDLog == id).FirstOrDefault();
            hideLog.Hide = hideLog.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }
    }
}
