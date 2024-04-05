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
    }
}