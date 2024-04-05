using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doanNet.Areas.GiaoVien.Controllers
{
    public class DefaultController : Controller
    {
        // GET: GiaoVien/Default
        public ActionResult ChoosingRoom()
        {
            return View();
        }
    }
}