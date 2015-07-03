using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPrime.Models;
using MvcPrime.Models.Service;

namespace MvcPrime.Controllers
{
    public class PCenterController : Controller
    {
        //
        // GET: /PCenter/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Info()
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
        public ActionResult Fee()
        {
            return View();
        }

        public JsonResult updatePInfo(user_info_table user)
        {
            PatientLogin pl = new PatientLogin();
            user_info_table temp = pl.getUserById(user.user_id);
            if (temp != null)
            {
                pl.updateUser(user);
                return Json(new { code = 1, msg = "修改成功" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { code = 0, msg = "指定用户不存在" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getBookByDIdAndTime(long doctor_id, long patient_id, DateTime date)
        {
            int[] hour = new int[99];
            BookService getbook = new BookService();
            for (int i = 7; i < 18; i++)
            {
                DateTime Start = date.AddHours(i);
                DateTime End = Start.AddHours(1);
                List<book_info_table> booklist = getbook.getBookByDIdAndTime(Start, End, doctor_id);
                if (booklist.Count() == 0)
                {
                    hour[i] = 1;
                }
                else if (booklist[0].patient_id == patient_id)
                {
                    hour[i] = 2;
                }
                else
                {
                    hour[i] = 3;
                }
            }

            var result = new
            {
                seven = hour[7],
                eight = hour[8],
                nine = hour[9],
                ten = hour[10],
                eleven = hour[11],
                twelve = hour[12],
                thirteen = hour[13],
                fourteen = hour[14],
                fifteen = hour[15],
                sixteen = hour[16],
                seventeen = hour[17],
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public JsonResult submitBookinfo(long doctorID, long patientID, DateTime booktime)
        {
            BookService submit = new BookService();
            DateTime bookstart = booktime;
            DateTime bookend = booktime.AddHours(1);
            List<book_info_table> BookExist = submit.getBookByDIdAndTime(bookstart, bookend, doctorID);
            if (BookExist.Count() == 0)
            {
                submit.submitBook(doctorID, patientID, booktime);
            }
            DateTime date = booktime.Date;
            int[] time = new int[99];
            BookService getbook = new BookService();
            for (int i = 7; i < 18; i++)
            {
                DateTime Start = date.AddHours(i);
                DateTime End = Start.AddHours(1);
                List<book_info_table> booklist = getbook.getBookByDIdAndTime(Start, End, doctorID);
                if (booklist.Count() == 0)
                {
                    time[i] = 1;
                }
                else if (booklist[0].patient_id == patientID)
                {
                    time[i] = 2;
                }
                else
                {
                    time[i] = 3;
                }
            }

            return Json(new
            {
                doctorid = doctorID,
                patientid = patientID,
                seven = time[7],
                eight = time[8],
                nine = time[9],
                ten = time[10],
                eleven = time[11],
                twelve = time[12],
                thirteen = time[13],
                fourteen = time[14],
                fifteen = time[15],
                sixteen = time[16],
                seventeen = time[17]
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult searchBook(long patientID)
        {
            BookService search = new BookService();
            List<book_info_table> books = search.getBookByPatientId(patientID);
            List<book_info_table> OrderedBooks = search.ListOrderByTime(books);
            return Json(OrderedBooks, JsonRequestBehavior.AllowGet);

        }
        public JsonResult DeleteBook(long patID, long docID, DateTime btime)
        {
            BookService delete = new BookService();
            bool isdeleted = delete.deleteBook(patID, docID, btime);
            return Json(isdeleted, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchTreat(long patientID)
        {
            SearchTreat search = new SearchTreat();
            List<SearchTreatClass> sT = search.search(patientID);

            return Json(new { code = 1, msg = sT }, JsonRequestBehavior.AllowGet);

        }


    }
}
