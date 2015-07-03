using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPrime.Models.Service
{
    public class PatientLogin : BaseService
    {
        public bool isUserExist(String accountName)
        {
            //   return db.Price.Where(p => p.Issue == name).ToList();
            bool exist = db.user_info_table.Any(u => u.account_name.Equals(accountName));
            if (exist)
            {
                return true;
            }
            return false;
        }
        public user_info_table getUserById(long user_id)
        {
            List<user_info_table> list = db.user_info_table.Where(u => u.user_id == user_id).ToList();
            if (list.Count() == 0)
                return null;
            else
                return list[0];
        }
        public user_info_table isUserExist(long user_id)
        {
            List<user_info_table> list = db.user_info_table.Where(u => u.user_id == user_id).ToList();
            if (list.Count() == 0)
                return null;
            else
            {
                return list[0];
            }
        }
        public user_info_table login(user_info_table user)
        {
            List<user_info_table> list = db.user_info_table.Where(u => u.account_name.Equals(user.account_name) && u.pwd.Equals(user.pwd) && u.user_type == user.user_type).ToList();
            if (list.Count() == 0)
                return null;
            else
            {
                return list[0];
            }
        }

        public void updateUser(user_info_table user)
        {
            user_info_table tmp = db.user_info_table.Where(u => u.user_id == user.user_id).First();
            tmp.tel = user.tel;
            tmp.user_gender = user.user_gender;
            tmp.birthday = user.birthday;
            tmp.user_name = user.user_name;
            tmp.id_num = user.id_num;
            db.SubmitChanges();
        }

        public bool register(user_info_table user)
        {
            db.user_info_table.InsertOnSubmit(user);
            db.SubmitChanges();
            return true;
        }
        public user_info_table getUserByAccountName(String accountName)
        {
         List<user_info_table> list=    db.user_info_table.Where(d => d.account_name == accountName).ToList();
         if (list.Count() == 0)
             return null;
         else
         {
             return list[0];
         }
        }

        public List<user_info_table> getDoctors()
        {
            List<user_info_table> list = db.user_info_table.Where(d => d.user_type == 2).ToList();
            return list;
        }

    }
}