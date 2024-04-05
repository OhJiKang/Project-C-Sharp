using doanNet.Controllers.DTO;
using doanNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace doanNet.ApiControllers
{
    public class AttendanceController : ApiController
    {
        KTXTDTUEntities2 db = new KTXTDTUEntities2();

        public List<Attendance> GetAll()
        {
            return db.Attendances.ToList();
        }


        public Attendance GetByAttendanceId(int id)
        {
            return db.Attendances.Where(row => row.IDAttendance == id).FirstOrDefault();
        }
        public IHttpActionResult AddingAttendance([FromBody] AttendanceDTO Attendance)
        {
            try
            {
                var tempAttendance = new Attendance();
                tempAttendance.IsAttend = Attendance.IsAttend;
                tempAttendance.Reason = Attendance.Reason;
                tempAttendance.DateBegin = DateTime.Now;
                tempAttendance.Hide = 0;

                db.Attendances.Add(tempAttendance);
                db.SaveChangesAsync();
                var tempAttendanceBridge = new AttendanceBridge();
                tempAttendanceBridge.IDAttendance = tempAttendance.IDAttendance;
                tempAttendanceBridge.IDAccount = Attendance.IDAccount;
                tempAttendanceBridge.IDSinhVien=Attendance.IDSinhVien;
                db.AttendanceBridges.Add(tempAttendanceBridge);
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

        private bool EntityExists(int id)
        {
            return db.Attendances.Any(e => e.IDAttendance == id);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAttendance(int? id, [FromBody] AttendanceDTO Attendance)
        {
            try
            {
                var Attendancemodifier = db.Attendances.Where(row => row.IDAttendance == id).FirstOrDefault();
                Attendancemodifier.IsAttend = Attendance.IsAttend;
                Attendancemodifier.Reason = Attendance.Reason;
                //var AttendanceBridgemodifier = db.AttendanceBridges.Where(row => row.IDAttendance == id).FirstOrDefault();
                //AttendanceBridgemodifier.IDAccount=Attendance.IDAccount;
                db.Entry(Attendancemodifier).State = EntityState.Modified;
                //db.Entry(AttendanceBridgemodifier).State = EntityState.Modified;

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
        public IHttpActionResult HiddingAttendance(int id)
        {
            Attendance hideAttendance = db.Attendances.Where(row => row.IDAttendance == id).FirstOrDefault();
            hideAttendance.Hide = hideAttendance.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }
    }
}

