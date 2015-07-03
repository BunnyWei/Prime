using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPrime.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ClinicInfo()
        {
            return View();
        }
        public ActionResult ClinicFee()
        {
            return View();
        }
        public ActionResult ClinicDoctor()
        {
            return View();
        }
    }
}
