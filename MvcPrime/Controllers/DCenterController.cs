using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPrime.Models;
using MvcPrime.Models.Service;

namespace MvcPrime.Controllers
{
    public class DCenterController : Controller
    {
        //
        // GET: /DCenter/

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult PatientInfo()
        {
            return View();
        }
        public ActionResult Case()
        {
            return View();
        }
        public ActionResult Res()
        {
            return View();
        }
        public JsonResult getPatientInfo(long user_id)
        {
            PatientLogin pl = new PatientLogin();
            user_info_table user = pl.getUserById(user_id);
            if (user == null)
            {
                return Json(new { code = 0, msg = "用户不存在" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { code = 1, msg = user }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getCaseDetialByPAccountName(String  account_name)
        {
            List<CaseDetail> list = CaseDetail.getListByPAccount(account_name);
            if (list.Count == 0)
            {
                return Json(new { code = 0, msg = "没有找到病例" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { code = 1, msg = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult addCase(CaseDetail cd)
        {
            cd.insert();
            return Json(new { code= 1 ,msg ="毛哥nice"});
        }

    }
}
