using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPrime.Models.Service
{
    public class SearchTreat : BaseService
    {


        public List<SearchTreatClass> search(long patient_id)
        {
            List<case_info> list = db.case_info.Where(t => t.patient_id == patient_id).ToList();
            List<SearchTreatClass> listFinal = new List<SearchTreatClass>();

            foreach (var item in list)
            {
                List<case_to_treat> cT = db.case_to_treat.Where(t => t.case_id == item.case_id).ToList();
                foreach (var item1 in cT)
                {
                    treat_table tT = db.treat_table.Where(t => t.treat_id == item1.treat_id).First();
                    SearchTreatClass sT = new SearchTreatClass();
                    sT.treat_id = tT.treat_id;
                    sT.treat_name = tT.treat_name;
                    sT.treat_note = tT.treat_note;
                    sT.charge = tT.charge;
                    sT.treat_count = item1.treat_count;
                    listFinal.Add(sT);
                }
            }
            return listFinal;
        }
    }
}
