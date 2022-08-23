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
    public class WareHouseController : Controller
    {
        private Material_ManagementEntities db = new Material_ManagementEntities();
        // GET: WareHouse
        public ActionResult Index()
        {
            var warehouses = db.Warehouse.ToList();

            List<VMWareHouse> list = new List<VMWareHouse>();

            foreach (var item in warehouses)
            {
                VMWareHouse vmwh = new VMWareHouse();
                vmwh.whId = item.whId;
                vmwh.whName = item.whName;
                vmwh.whTel = item.whTel;
                vmwh.whAddress = item.whAddress;
                
                list.Add(vmwh);
            }
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMWareHouse vmwh)
        {
            Warehouse warehouses = new Warehouse();
            var exist = db.Warehouse.Where(w => w.whId == vmwh.whId).FirstOrDefault();

            if (exist == null)
            {
                if (ModelState.IsValid)
                {
                    warehouses.whId = vmwh.whId;
                    warehouses.whName = vmwh.whName;
                    warehouses.whTel = vmwh.whTel;
                    warehouses.whAddress = vmwh.whAddress;
                    
                    db.Warehouse.Add(warehouses);
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
                ViewBag.ErrorMessage = "商庫編號不可重複，請重新輸入!";
                return View();
            }

        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMWareHouse vmwh = new VMWareHouse();
            Warehouse warehouses = db.Warehouse.Find(id);
            if (warehouses == null)
            {
                return HttpNotFound();
            }

            vmwh.whId = warehouses.whId;
            vmwh.whName = warehouses.whName;
            vmwh.whTel = warehouses.whTel;
            vmwh.whAddress = warehouses.whAddress;
           
            return View(vmwh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(VMWareHouse vmwh)
        {

            if (ModelState.IsValid)
            {
                Warehouse edit = db.Warehouse.Where(w => w.whId == vmwh.whId).FirstOrDefault();

                edit.whName = vmwh.whName;
                edit.whTel = vmwh.whTel;
                edit.whAddress = vmwh.whAddress;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]

        public ActionResult Delete(string id)
        {
            Warehouse warehouse = db.Warehouse.Where(w => w.whId == id).FirstOrDefault();
            if (warehouse != null)
            {
                db.Warehouse.Remove(warehouse);
                db.SaveChanges();
                TempData["ResultMessage"] = String.Format("已成功刪除客戶編號[{0}]的相關資料", warehouse.whId);
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