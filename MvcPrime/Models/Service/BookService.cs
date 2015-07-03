using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPrime.Models.Service
{
    public class BookService : BaseService
    {
        public List<book_info_table> getBookByDoctorId(long doctorId)
        {
            List<book_info_table> list = db.book_info_table.Where(b => b.dentist_id == doctorId).ToList();
            return list;
        }
        public List<book_info_table> getBookByPatientId(long patientId)
        {
            List<book_info_table> list = db.book_info_table.Where(b => b.patient_id == patientId).ToList();
            return list;
        }
        public List<book_info_table> getBookByPatientAccountName(String accountName)
        {
            PatientLogin pl = new PatientLogin();
            user_info_table user =  pl.getUserByAccountName(accountName);
            long patientId = user.user_id;
            return getBookByPatientId(patientId);
        }

        public List<book_info_table> getBookByDIdAndTime(DateTime start, DateTime end, long doctorId)
        {
            List<book_info_table> list = db.book_info_table.Where(b => (b.dentist_id == doctorId) && (DateTime.Compare(b.book_time, start) >= 0) && (DateTime.Compare(b.book_time, end) < 0)).ToList();
            return list;
        }

        public void addBook(book_info_table book)
        {
            book.book_gen_time = DateTime.Now;
            db.book_info_table.InsertOnSubmit(book);
            db.SubmitChanges();
        }
        public void submitBook(long doctorid, long patientid, DateTime booktime)
        {
            book_info_table tbl = new book_info_table();
            tbl.dentist_id = doctorid;
            tbl.patient_id = patientid;
            tbl.book_time = booktime;
            addBook(tbl);
        }
        public List<book_info_table> ListOrderByTime(List<book_info_table> Books)
        {
            List<book_info_table> OrderedList = Books;
            //List<book_info_table> nouse = new List<book_info_table>();
            for (int i = 0; i < Books.Count(); i++)
            {
                for (int j = i + 1; j < Books.Count(); j++)
                {
                    if (DateTime.Compare(Books[i].book_time, Books[j].book_time) > 0)
                    {
                        var temp = Books[i];
                        Books[i] = Books[j];
                        Books[j] = temp;
                    }
                }
                OrderedList[i] = Books[i];

            }
            return OrderedList;
        }
        public bool deleteBook(long patID, long docID, DateTime btime)
        {
          
            List<book_info_table> patientbook = db.book_info_table.Where(b => (b.patient_id == patID) && (b.dentist_id == docID)&&(b.book_time==btime)).ToList();
            db.book_info_table.DeleteAllOnSubmit(patientbook);
            db.SubmitChanges();
            return true;
        }
    }
}