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
            return View();
        }
        public ActionResult Post()
        {
            return View();
        }
        public ActionResult QuanLyMenu()
        {
            return View();
        }
        public ActionResult QuanLyPhong()
        {
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