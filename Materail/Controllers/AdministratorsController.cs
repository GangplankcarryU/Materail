using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Materail.Models;
using Materail.Models.ViewModel;

namespace Materail.Controllers
{
    public class AdministratorsController : Controller
    {
        private Material_ManagementEntities db = new Material_ManagementEntities();

        // GET: Administrators
        public ActionResult Index()
        {
            return View(db.Administrators.ToList());
        }

        // GET: Administrators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrators/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMAdministratorsCreate vmac)
        {
            Administrators administrators = new Administrators();
            var exist = db.Administrators.Where(m => m.admId == vmac.admId).FirstOrDefault();
            
            if (ModelState.IsValid)
            {
                if(exist == null)
                {
                    administrators.admId = vmac.admId;
                    administrators.admName = vmac.admName;
                    administrators.admAct = vmac.admAct;
                    administrators.admPwd =vmac.admPwd;
                    administrators.admGender = vmac.admGender;
                    administrators.admTel = vmac.admTel;
                    administrators.admEmail = vmac.admEmail;

                    db.Administrators.Add(administrators);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessageKEY = "管理員編號不可重複，請重新輸入!";
                    return View(vmac);
                }
             
            }
           
            return View(vmac);
        }

        // GET: Administrators/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMAdministratorsEdit vmae = new VMAdministratorsEdit();
            Administrators administrators = db.Administrators.Find(id);
            
            
            if (administrators == null)
            {
                return HttpNotFound();
            }
            vmae.admId = administrators.admId;
            vmae.admName = administrators.admName;
            vmae.admAct = administrators.admAct;
            vmae.admPwd = administrators.admPwd;
            vmae.admGender = administrators.admGender;
            vmae.admTel = administrators.admTel;
            vmae.admEmail = administrators.admEmail;

            
            return View(vmae);
        }

        // POST: Administrators/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMAdministratorsEdit vmae)
        {
            
            
            if (ModelState.IsValid)
            {
              var  exist = db.Administrators.Where(m => m.admAct == vmae.admAct).FirstOrDefault();
                
                
                if (exist == null ) {
                    var edit = db.Administrators.Where(x => x.admId == vmae.admId).FirstOrDefault();

                    edit.admName = vmae.admName;
                    edit.admAct = vmae.admAct;
                    edit.admPwd = vmae.admPwd;
                    edit.admGender = vmae.admGender;
                    edit.admTel = vmae.admTel;
                    edit.admEmail = vmae.admEmail;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if(exist.admId == vmae.admId)
                {
                    var edit = db.Administrators.Where(x => x.admId == vmae.admId).FirstOrDefault();

                    edit.admName = vmae.admName;
                    edit.admAct = vmae.admAct;
                    edit.admPwd = vmae.admPwd;
                    edit.admGender = vmae.admGender;
                    edit.admTel = vmae.admTel;
                    edit.admEmail = vmae.admEmail;


                    db.SaveChanges();
                                       
                    return RedirectToAction("Index");
                }
                ViewBag.ErrorMessage = "此帳號已經存在，請重新操作!";
                return View(vmae);                 
            }
            return View(vmae);
        }

        // GET: Administrators/Delete/5
        /*public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrators administrators = db.Administrators.Find(id);
            if (administrators == null)
            {
                return HttpNotFound();
            }
            return View(administrators);
        }

        // POST: Administrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Administrators administrators = db.Administrators.Find(id);
            db.Administrators.Remove(administrators);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        [HttpPost]
        public ActionResult Delete(string id)
        {
            Administrators adm = db.Administrators.Where(a => a.admId == id).FirstOrDefault();
            if (adm != null)
            {
                db.Administrators.Remove(adm);
                db.SaveChanges();
                TempData["ResultMessage"] = String.Format("已成功刪除管理員編號[{0}]的相關資料", adm.admId);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = "該員工資料不存在，無法刪除，請重新操作";
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
