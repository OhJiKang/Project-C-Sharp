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
    public class AccountController : ApiController
    {
        KTXTDTUEntities2 db = new KTXTDTUEntities2();

        public List<Account> GetAll()
        {
            return db.Accounts.ToList();
        }

        public bool CheckingLogin([FromBody] LoginDTO loginTemp) {
            if (db.Accounts.Where(row => row.Password == loginTemp.password && row.SinhVien.MSSV == loginTemp.account).FirstOrDefault()==null)
            {
                return false;
            }
            return true;
        }

        public Account GetByAccountId(int id)
        {
            return db.Accounts.Where(row => row.IDAccount == id).FirstOrDefault();
        }
        public IHttpActionResult AddingAccount([FromBody] Account Account)
        {

            try
            {
                db.Accounts.Add(Account);
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
            return db.Accounts.Any(e => e.IDAccount == id);
        }
        public async Task<IHttpActionResult> PutAccount(int id, [FromBody] Account Account)
        {

            try
            {
                db.Entry(Account).State = EntityState.Modified;
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
        public IHttpActionResult HiddingAccount(int id)
        {
            Account hideAccount = db.Accounts.Where(row => row.IDAccount == id).FirstOrDefault();
            hideAccount.Hide = hideAccount.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }
    }
}
