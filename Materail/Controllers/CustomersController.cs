using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Materail.Models;
using Materail.Models.ViewModel;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace Materail.Controllers
{
    public class CustomersController : Controller
    {
        private Material_ManagementEntities db = new Material_ManagementEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();

            List<VMCustomers> list = new List<VMCustomers>();

            foreach (var item in customers)
            {
                VMCustomers vmc = new VMCustomers();
                vmc.cusId = item.cusId;
                vmc.cusName = item.cusName;
                vmc.cusTel = item.cusTel;
                vmc.cusAddress = item.cusAddress;
                vmc.cusNotes = item.cusNotes;
                list.Add(vmc);
            }
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMCustomers vmc)
        {
            Customers customers = new Customers();
            var exist = db.Customers.Where(c => c.cusId == vmc.cusId).FirstOrDefault();

            if (exist == null)
            {
                if (ModelState.IsValid)
                {
                    customers.cusId = vmc.cusId;
                    customers.cusName = vmc.cusName;
                    customers.cusTel = vmc.cusTel;
                    customers.cusAddress = vmc.cusAddress;
                    customers.cusNotes = vmc.cusNotes;

                    db.Customers.Add(customers);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "客戶編號不可重複，請重新輸入!";
                return View();
            }

        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMCustomers vmc = new VMCustomers();
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }

            vmc.cusId = customers.cusId;
            vmc.cusName = customers.cusName;
            vmc.cusTel = customers.cusTel;
            vmc.cusAddress = customers.cusAddress;
            vmc.cusNotes = customers.cusNotes;

            return View(vmc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(VMCustomers vmc)
        {
            
            if (ModelState.IsValid)
            {
                Customers edit = db.Customers.Where(c => c.cusId == vmc.cusId).FirstOrDefault();

                edit.cusName = vmc.cusName;
                edit.cusTel = vmc.cusTel;
                edit.cusAddress = vmc.cusAddress;
                edit.cusNotes = vmc.cusNotes;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            Customers customers = db.Customers.Where(c => c.cusId == id).FirstOrDefault();
            if (customers != null)
            {
                db.Customers.Remove(customers);
                db.SaveChanges();
                TempData["ResultMessage"] = String.Format("已成功刪除客戶編號[{0}]的相關資料", customers.cusId);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = "該客戶資料不存在，無法刪除，請重新操作";
                return RedirectToAction("Index");
            }
        }
    }
}