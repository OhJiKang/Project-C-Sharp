using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doanNet.Controllers
{
    public class SVTuQuanController : Controller
    {
        // GET: SVTuQuan
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
    }
}