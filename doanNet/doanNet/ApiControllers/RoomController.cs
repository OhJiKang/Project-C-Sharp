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
    public class RoomController : ApiController
    {
        KTXTDTUEntities1 db = new KTXTDTUEntities1();

        public List<Room> GetAll()
        {
            return db.Rooms.ToList();
        }
        

        public Room GetByRoomId(int id)
        {
            return db.Rooms.Where(row => row.IDRoom == id).FirstOrDefault();
        }
        public IHttpActionResult AddingRoom([FromBody] Room Room)
        {

            try
            {
                db.Rooms.Add(Room);
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
            return db.Rooms.Any(e => e.IDRoom == id);
        }
        public async Task<IHttpActionResult> PutRoom(int id, [FromBody] Room Room)
        {

            try
            {
                db.Entry(Room).State = EntityState.Modified;
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
        public IHttpActionResult HiddingRoom(int id)
        {
            Room hideRoom = db.Rooms.Where(row => row.IDRoom == id).FirstOrDefault();
            hideRoom.Hide = hideRoom.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }
    }
}
