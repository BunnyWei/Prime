using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPrime.Models.Service
{
    public class AdminSearch : BaseService
    {
        public List<treat_table> getTreat()
        {
            List<treat_table> list = db.treat_table.ToList();
            return list;
        }

        public List<medical_devices_info_table> getDevices12()
        {
            List<medical_devices_info_table> list = db.medical_devices_info_table.Where(m => (m.medical_devices_type == "1") || (m.medical_devices_type == "2")).ToList();
            return list;
        }

        public List<medical_devices_info_table> getDevices3()
        {
            List<medical_devices_info_table> list = db.medical_devices_info_table.Where(m => m.medical_devices_type == "3").ToList();
            return list;
        }


        public bool updateDevices(List<medical_devices_info_table> list)
        {
            foreach (var item in list)
            {
                medical_devices_info_table tmp = db.medical_devices_info_table.Where(m => m.medical_devices_id == item.medical_devices_id).First();
                if (tmp == null)
                    return false;
                tmp.medical_devices_name = item.medical_devices_name;
                tmp.medical_devices_type = item.medical_devices_type;
                tmp.unitprice = item.unitprice;
                db.SubmitChanges();
            }
            return true;
        }

        public bool updateTreat(List<treat_table> list)
        {
            foreach (var item in list)
            {
                treat_table tmp = db.treat_table.Where(t => t.treat_id == item.treat_id).First();
                if (tmp == null)
                    return false;
                tmp.treat_name = item.treat_name;
                tmp.treat_note = item.treat_note;
                tmp.charge = item.charge;
                db.SubmitChanges();
            }
            return true;
        }

        public bool insertDevices(medical_devices_info_table devices)
        {
            db.medical_devices_info_table.InsertOnSubmit(devices);
            db.SubmitChanges();
            return true;
        }

        public bool insertTreat(treat_table treat)
        {
            db.treat_table.InsertOnSubmit(treat);
            db.SubmitChanges();
            return true;
        }

        public bool deleteDevice(medical_devices_info_table devices)
        {
            db.medical_devices_info_table.DeleteOnSubmit(devices);
            db.SubmitChanges();
            return true;
        }


        public List<user_info_table> getUser23()
        {
            List<user_info_table> list = db.user_info_table.Where(u => (u.user_type == 2) || (u.user_type == 3)).ToList();
            return list;
        }
        public List<charge_info_table> getCharge(long patientID)
        {
            List<charge_info_table> list = db.charge_info_table.Where(u => (u.patient_id == patientID)).ToList();
            return list;
        }
    }
}