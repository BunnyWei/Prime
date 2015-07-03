using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPrime.Models.Service;
namespace MvcPrime.Models
{
    public class CaseDetail
    {
        public long case_id;
        public user_info_table doctor;
        public user_info_table patient;
        public List<TreatWithCount> treatWithCountList;
        public String note;
        public DateTime case_gen_time;



        public void insert()
        {
            case_info ci = new case_info();
            ci.case_id = this.case_id;
            ci.dentist_id = this.doctor.user_id;
            ci.patient_id = this.patient.user_id;
            ci.case_note = this.note;

            long case_id=new CaseService().insert(ci);

            foreach(TreatWithCount twc in this.treatWithCountList)
            {
                case_to_treat ct = new case_to_treat();
                ct.case_id = case_id;
                ct.treat_id = twc.treat.treat_id; 
                ct.treat_count = twc.count;
                new CaseToTreat().insert(ct);
            }
        }

        //实现方式略丑陋建议用联合查询方式， 我linq不太会用
        public static List<CaseDetail> getListByPId(long patient_id)
        {
            List<CaseDetail> result = new List<CaseDetail>();
            List<case_info> caselist = new CaseService().getCaseListByPId(patient_id);
            foreach (case_info ci in caselist)
            {
                result.Add(getInstanceByCaseId(ci.case_id));
            }
            return result;
        }

        public static List<CaseDetail> getListByPAccount(String account_name)
        {
            List<CaseDetail> result = new List<CaseDetail>();
            user_info_table patient = new PatientLogin().getUserByAccountName(account_name);
            if (patient != null)
            {
                result = getListByPId(patient.user_id);
            }
            return result;

        }
        public static CaseDetail getInstanceByCaseId(long case_id)
        {
            CaseDetail result = new CaseDetail();
            case_info ci = new CaseService().getCaseByCaseId(case_id);
            if (ci==null)
            {
                return null;
            }
            result.case_id = ci.case_id;
            result.note = ci.case_note;
            result.case_gen_time = ci.case_gen_time;
            result.doctor = new PatientLogin().getUserById(ci.dentist_id);
            result.patient = new PatientLogin().getUserById(ci.patient_id);
            result.treatWithCountList = TreatWithCount.getListByCaseId(ci.case_id);
            return result;
        }
    }
}