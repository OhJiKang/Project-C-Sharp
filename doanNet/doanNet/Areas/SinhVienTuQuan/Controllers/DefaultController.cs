using doanNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doanNet.Areas.SinhVienTuQuan.Controllers
{
    public class DefaultController : Controller
    {
        KTXTDTUEntities2 db = new KTXTDTUEntities2();

        // GET: SinhVienTuQuan/Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LichTrucTuan()
        {
            return View();
        }
        public ActionResult DangKyLichGacCong()
        {

            return View();
        }
        public ActionResult GhiLoiKTX()
        {
            return View();
        }
        public ActionResult DiemDanhKTX()
        {
            var RoomList = db.Rooms.ToList();
            var SinhVienList = db.SinhViens.ToList();
            ViewBag.RoomList = RoomList;
            ViewBag.SinhVienList = SinhVienList;
            return View();
        }
    }
}