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
            var falcuties = db.Faculties.ToList();
            ViewBag.falcuties = falcuties;
            ViewBag.sinhviens=sinhviens;
            var rooms = db.Rooms.ToList();
            ViewBag.rooms = rooms;
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
        public ActionResult DanhSachHoaDon()
        {
            var Fees = db.Fees.ToList();
            ViewBag.Fees = Fees;

            var places = db.Places.ToList();
            ViewBag.places = places;

            var rooms = db.Rooms.ToList();
            ViewBag.rooms = rooms;

            var priorities = db.Priorities.ToList();
            ViewBag.priorities = priorities;

            var sinhviens = db.SinhViens.ToList();
            ViewBag.sinhviens = sinhviens;

            return View();
        }
        public ActionResult DanhSachHoaDonTheoThang(int Year,int Month)
        {
            var Fees = db.Fees.Where(fee => fee.DateStart.Year == Year && fee.DateStart.Month== Month).ToList();
            ViewBag.Fees = Fees;

            var rooms = db.Rooms.ToList();
            ViewBag.rooms = rooms;

            var priorities = db.Priorities.ToList();
            ViewBag.priorities = priorities;

            var sinhviens = db.SinhViens.ToList();
            ViewBag.sinhviens = sinhviens;
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
            var posts = db.Posts.ToList();
            ViewBag.posts=posts;

            var categogries = db.Categories.ToList();
            ViewBag.categories = categogries;
            
            var categorybridge = db.CategoryBridges.ToList();
            ViewBag.categoryBridges = categorybridge;
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
            var sinhviens = db.SinhViens.ToList();
            var falcuties = db.Faculties.ToList();
            ViewBag.falcuties = falcuties;
            ViewBag.sinhviens = sinhviens;
            var AccountType = db.AccountTypes.ToList();
            ViewBag.AccountType = AccountType;
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
        public ActionResult QuanLyHocPhi()
        {
            var sinhviens = db.SinhViens.ToList();
            var fee = db.Fees.ToList();
            return View();
        }
    }
}