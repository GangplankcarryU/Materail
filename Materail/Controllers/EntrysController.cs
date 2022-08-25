using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Materail.Models;

namespace Materail.Controllers
{
    
    public class EntrysController : Controller
    {
        private Material_ManagementEntities db = new Material_ManagementEntities();
        // GET: Entrys
        public ActionResult Index()
        {
            ViewBag.Test = SetDateNum();
            return View();
        }

        public  string SetDateNum()
        {
            string datenum = string.Empty;
            
            var count = (from e in db.Entrys 
                           select e.entryId).Count();
            if(count == 0)
            {
                datenum = DateTime.Now.ToString("yyyyMMdd") + "0001";
            }
            else
            {
                var max = (from e in db.Entrys
                           select e.entryId).Max();

                string date = max.Substring(1, 8);
                string todate = DateTime.Now.ToString("yyyyMMdd");
                if (date != todate)
                {
                    datenum = DateTime.Now.ToString("yyyyMMdd") + "0001";
                }
                else
                {
                    var lastFour = Convert.ToInt32(max.Substring(max.Length - 4, 4));
                    var nextIndex = lastFour + 1;
                    if (nextIndex < 10)
                    {
                        datenum = todate + "000" + Convert.ToString(nextIndex);
                    }
                    if (nextIndex >= 10 && nextIndex < 100)
                    {
                        datenum = todate + "00" + Convert.ToString(nextIndex);
                    }
                    if (nextIndex >= 100 && nextIndex < 1000)
                    {
                        datenum = todate + "0" + Convert.ToString(nextIndex);
                    }
                    if (nextIndex >= 1000 && nextIndex < 10000)
                    {
                        datenum = todate + Convert.ToString(nextIndex);
                    }
                }
            }
            return datenum;
        }
    }
}