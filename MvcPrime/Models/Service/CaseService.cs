using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPrime.Models.Service
{
    public class CaseService : BaseService
    {
        public List<case_info> getCaseListByPId(long patient_id)
        {
            return db.case_info.Where(c => c.patient_id == patient_id).ToList();
        }
        public List<case_info> getCaseListByPIdAndDId(long patient_id, long doctor_id)
        {
            return db.case_info.Where(c => (c.patient_id == patient_id) && (c.dentist_id == doctor_id)).ToList();
        }
        public case_info getCaseByCaseId(long case_id)
        {
            List<case_info> list = db.case_info.Where(ci => ci.case_id == case_id).ToList();
            if (list.Count == 0)
            { 
                return null; 
            }
            else
            {
                return list[0];
            }
        }
        //返回插入的行数
        public long insert(case_info ci)
        {
            ci.case_gen_time = DateTime.Now;
            db.case_info.InsertOnSubmit(ci);
            db.SubmitChanges();
            return ci.case_id;
        }


    }
}