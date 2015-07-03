using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPrime.Models.Service
{
    public class TreatService : BaseService
    {
        public treat_table getTreatById(long treat_id)
        {

            List<treat_table> list = db.treat_table.Where(t => t.treat_id == treat_id).ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[0];
            }

        }
    }
}