using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPrime.Models.Service
{
    public class BaseService
    {
        protected static  PrimeDbDataContext db = null;
        private Object ob = new Object();
        public  BaseService()
        {
            if (db == null)
            {
                lock (ob)
                {
                    if (db == null)
                    {
                        db = new PrimeDbDataContext();
                    }
                }
            }
        }

    }
}