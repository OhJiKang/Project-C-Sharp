    using doanNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doanNet.Areas.GiaoVien.Controllers
{
    public class DefaultController : Controller
    {
        KTXTDTUEntities2 db = new KTXTDTUEntities2();
        // GET: GiaoVien/Default
        public ActionResult ChoosingRoom()
        {
            var rooms = db.Rooms.ToList();
            var ArrNumOfStudent =new List<int>();
            foreach(var room in rooms)
            {
                int NumberStudentOfRoom=db.SinhViens.Where(row=>row.IDRoom==room.IDRoom).Count(); ;
                ArrNumOfStudent.Add(NumberStudentOfRoom);
            }
            ViewBag.ArrNumOfStudent = ArrNumOfStudent;
            ViewBag.rooms = rooms;
            return View();
        }
        public ActionResult QuanLySinhVien()
        {
            var sinhviens = db.SinhViens.ToList();
            ViewBag.sinhviens=sinhviens;
            return View();
        }
        public ActionResult DanhSachHopDong()
        {
            var contracts = db.Contracts.ToList();
            ViewBag.contracts=contracts;

            var places = db.Places.ToList();
            ViewBag.places=places;

            var priorities = db.Priorities.ToList();
            ViewBag.priorities=priorities;

            var sinhviens = db.SinhViens.ToList();
            ViewBag.sinhviens= sinhviens;

            return View();
        }
        public ActionResult DanhSachHopDongTheoThang()
        {
            return View();
        }
        public ActionResult GhiLoiKTX()
        {
            return View();
        }
        public ActionResult Mistake()
        {
            var mistake = db.Mistakes.ToList();
            ViewBag.mistakes=mistake;

            var sinhvien = db.SinhViens.ToList();
            ViewBag.sinhviens = sinhvien;

            var rooms = db.Rooms.ToList();
            ViewBag.rooms=rooms;
            return View();
        }
        public ActionResult Post()
        {
            return View();
        }
        public ActionResult QuanLyMenu()
        {
            var Menus = db.Menus.ToList();
            ViewBag.Menus = Menus;
            return View();
        }
        public ActionResult QuanLyPhong() { 
            var rooms = db.Rooms.ToList();
            ViewBag.rooms = rooms;
            return View();
        }
        public ActionResult QuanLyTaiKhoan()
        {
            return View();
        }
        public ActionResult RegisterPlace()
        {
            return View();
        }
        public ActionResult ThemBaiViet()
        {
            return View();
        }

    }
}