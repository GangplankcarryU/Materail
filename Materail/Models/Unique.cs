using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Materail.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return Check(value);
            }
            return false;
        }

        public bool Check(object o)
        {
            using (Material_ManagementEntities db = new Material_ManagementEntities())
            {
                return db.Members.Where(m => m.memAct == o.ToString()).Count() <= 0;
            }
        } 
    }

    public class AdmUniqueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return Check(value);
            }
            return false;
        }

        public bool Check(object o)
        {
            using (Material_ManagementEntities db = new Material_ManagementEntities())
            {
                return db.Administrators.Where(m => m.admAct == o.ToString()).Count() <= 0;
                //return !db.Administrators.Any(m => m.admAct == o.ToString());
            }
        }
    }
}

       