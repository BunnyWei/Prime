using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPrime.Models.Service;
namespace MvcPrime.Models
{
    public class TreatWithCount
    {
        public treat_table treat;
        public int count;
        public static List<TreatWithCount> getListByCaseId(long case_id)
        {
            List<TreatWithCount> result = new List<TreatWithCount>();
            List < case_to_treat > ctList =  new CaseToTreat().getCTIdByCaseId(case_id);
            foreach (case_to_treat ct in ctList)
            {
               treat_table treat =  new TreatService().getTreatById(ct.treat_id);
               if (treat != null)
               { 
                   TreatWithCount twc = new TreatWithCount();
                   twc.treat = treat;
                   twc.count = ct.treat_count;
                   result.Add(twc);
               }
            }
            return result;
        }
    }
}