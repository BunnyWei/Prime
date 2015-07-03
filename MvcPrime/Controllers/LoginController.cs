using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MvcPrime.Models;
using MvcPrime.Models.Service;
namespace MvcPrime.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login(String account_name=null,String pwd=null,int user_type=0)
        {
            // this.Response.Cookies.Add(
            if (account_name == null || pwd == null || user_type == 0)
            {
                  return View();
            }
            else{
                user_info_table user = new user_info_table();
                user.account_name = account_name;
                user.pwd =pwd;
                user.user_type = user_type;
                PatientLogin pl = new PatientLogin();
                user = pl.login(user);
                if (user != null)
                {
                    //写入cookies
                    HttpCookie newCookie = new HttpCookie("Log");
                    newCookie.Values.Set("isLog", "true");
                    newCookie.Values.Set("user_id", user.user_id.ToString());
                    newCookie.Expires = DateTime.Now.AddDays(10);
                    Response.AppendCookie(newCookie);
                    //重定向到主页
                    return Json(new { code = 1, msg = "登陆成功" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { code = 0, msg = "用户名密码错误" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        public JsonResult IsAccountNameExist(String account_name)
        {
            bool isExist = false;
            PatientLogin pl = new PatientLogin();
            isExist = pl.isUserExist(account_name);
            if (isExist)
            {
                return Json(new { code = 0, msg = "用户名已存在" }, JsonRequestBehavior.AllowGet);
              
            }
            return Json(new { code = 1, msg = "用户名可用" }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult addUser(user_info_table user)
        {
            //user_info_table user = new user_info_table();
            //user.account_name = "pkxiuluo";
            //user.pwd = "111";
            //user.user_name = "网易通";

           // user.birthday = DateTime.Now;

            user.user_type = 1;//1:患者2：医生3：管理员
            PatientLogin pl = new PatientLogin();
            pl.register(user);
            return Json(new { code =1, msg = "注册成功" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult test( )
        {
            CaseService cs = new CaseService();
            case_info ci = new case_info();
            ci.patient_id =1;
            ci.dentist_id =1;
            ci.case_note ="aa";
            ci.case_gen_time = DateTime.Now;
            cs.insert(ci);
            return null;
          
        }

    }
}
