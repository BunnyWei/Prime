using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPrime.Models.Service
{
    public class CaseToTreat:BaseService
    {
        //通过casa_id 获得 case_to_treat
        public  List<case_to_treat> getCTIdByCaseId(long case_id)
        {
            return     db.case_to_treat.Where(ct => ct.case_id == case_id).ToList();
        }
        //通过casa_id 获得 treat_table
        //public List<treat_table> getTreatByCaseId(long case_id)
        //{
        //    List<treat_table> treatList = new List<treat_table>();
        //    List<case_to_treat> CTList = getCTIdByCaseId(case_id);
        //    TreatService ts = new TreatService();

        //    foreach (case_to_treat ct in CTList)
        //    {
        //        ts.getTreatListById(ct.treat_id);
        //    }
        //    return null;
        //}
        public void insert(case_to_treat ct)
        {
            db.case_to_treat.InsertOnSubmit(ct);
            db.SubmitChanges();
        }
    }
}