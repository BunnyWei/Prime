using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPrime.Models.Service;
using MvcPrime.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace MvcPrime.Controllers
{
    public class ACenterController : Controller
    {
        //
        // GET: /ACenter/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BaseMaterial()
        {
            return View();
        }
        public ActionResult Fee()
        {
            return View();
        }
        public ActionResult Res()
        {
            return View();
        }


        public JsonResult getTreat()
        {
            List<treat_table> list = new List<treat_table>();

            AdminSearch aS = new AdminSearch();
            list = aS.getTreat();
//             for (int i = 0; i < num; i++)
//             {
//                 user_info_table user = new user_info_table();
//                 user.account_name = i.ToString();
//                 list.Add(user);
//             }
            return Json(new { code = 1, msg = list }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult getDevice12()
        {            
            List<medical_devices_info_table> list = new List<medical_devices_info_table>();
            AdminSearch aS = new AdminSearch();
            list = aS.getDevices12();
            return Json(new { code = 1, msg = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDevice3()
        {
            List<medical_devices_info_table> list = new List<medical_devices_info_table>();
            AdminSearch aS = new AdminSearch();
            list = aS.getDevices3();
            return Json(new { code = 1, msg = list }, JsonRequestBehavior.AllowGet);
        }


        public static T FromJsonTo<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                T jsonObject = (T)ser.ReadObject(ms);
                return jsonObject;
            }
        }

        public static int string_to_int(string s)
        {
            int res = 0;
            for (int i = 0; i < s.Length; ++i)
                res = res * 10 + s[i] - '0';
            return res;
        }

        public JsonResult getUser23()
        {
            List<user_info_table> list = new List<user_info_table>();
            AdminSearch aS = new AdminSearch();
            list = aS.getUser23();
            return Json(new { code = 1, msg = list }, JsonRequestBehavior.AllowGet);
        }

//         public static void getCaseToTreat(string jsonString)
//         {
//             char[] ch = { ' ' };
//             string[] arr = jsonString.Split(ch, StringSplitOptions.RemoveEmptyEntries);
//             int userID = string_to_int(arr[0]), treatID = string_to_int(arr[1]);
//             string date = arr[2], note = arr[4], s = arr[3];
//             List<int> caseID, caseCount;
//             for (int i = 0; i < s.Length; )
//             {
//                 int a = 0, b = 0;
//                 for (++i; s[i] != ' '; ++i)
//                     a = a * 10 + s[i] - '0';
//                 for (++i; s[i] != ']'; ++i)
//                     b = b * 10 + s[i] - '0';
//                 caseID.Add(a);
//                 caseCount.Add(b);
//             }
// 
// 
// 
// 
//             
//         }  




//         public List<medical_devices_info_table>  getDevicetest()
//         {
// 
//             List<medical_devices_info_table> list = new List<medical_devices_info_table>();
//             AdminSearch aS = new AdminSearch();
//             return aS.getDevices();
// 
//         }

//         public void test()
//         {
//             treat_table list = FromJsonTo<treat_table>("{\"treat_id\":28,\"charge\":\"12\",\"treat_name\":\"nini\",\"treat_note\":\"wew\"}");
//             long treat_id = list.treat_id;
// 
//             
//         }
        
    }
    
}
