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
    
    public class SuppliersController : Controller
    {
        Material_ManagementEntities db = new Material_ManagementEntities();
        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = db.Suppliers.ToList();

            List<VMSuppliers> list = new List<VMSuppliers>();

            foreach (var item in suppliers)
            {
                VMSuppliers vms = new VMSuppliers();
                vms.supId = item.supId;
                vms.supName = item.supName;
                vms.supTel = item.supTel;
                vms.supAddress = item.supAddress;
                vms.supNotes = item.supNotes;
                list.Add(vms);
            }

            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Create(VMSuppliers vms)
        {
            Suppliers suppliers = new Suppliers();
            var exist = db.Suppliers.Where(s => s.supId == vms.supId).FirstOrDefault();

            if(exist == null)
            {
                if (ModelState.IsValid)
                {
                    suppliers.supId = vms.supId;
                    suppliers.supName = vms.supName;
                    suppliers.supTel = vms.supTel;
                    suppliers.supAddress = vms.supAddress;
                    suppliers.supNotes = vms.supNotes;

                    db.Suppliers.Add(suppliers);
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
                ViewBag.ErrorMessage = "供應商編號不可重複，請重新輸入!";
                return View();
            }
                        
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMSuppliers vms = new VMSuppliers();
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }

            vms.supId = suppliers.supId;
            vms.supName = suppliers.supName;
            vms.supTel = suppliers.supTel;
            vms.supAddress = suppliers.supAddress;
            vms.supNotes = suppliers.supNotes;

            return View(vms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(VMSuppliers vms)
        {
            if (ModelState.IsValid)
            {
                Suppliers edit = db.Suppliers.Where(s => s.supId == vms.supId).FirstOrDefault();
                
                edit.supName = vms.supName;
                edit.supTel = vms.supTel;
                edit.supAddress = vms.supAddress;
                edit.supNotes = vms.supNotes;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
       
        public ActionResult Delete(string id)
        {
            Suppliers suppliers = db.Suppliers.Where(s => s.supId == id).FirstOrDefault();
            if (suppliers != null)
            {
                db.Suppliers.Remove(suppliers);
                db.SaveChanges();
                TempData["ResultMessage"] = String.Format("已成功刪除供應商編號[{0}]的相關資料", suppliers.supId);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = "該供應商資料不存在，無法刪除，請重新操作";
                return RedirectToAction("Index");
            }
        }
    }
}