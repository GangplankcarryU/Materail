using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Materail.Models;
using Materail.Models.ViewModel;

namespace Materail.Controllers
{
    public class MembersController : Controller
    {//edit
        private Material_ManagementEntities db = new Material_ManagementEntities();
        // GET: Members
        
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.adm = db.Administrators.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMMembersCreate vmmc)
        {
            Members members = new Members();
            var exist = db.Members.Where(m =>m.memId == vmmc.memId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                if(exist == null)
                {
                    members.memId = vmmc.memId;
                    members.memName = vmmc.memName;
                    members.memAct = vmmc.memAct;
                    members.memPwd = vmmc.memPwd;
                    members.memTel = vmmc.memTel;
                    members.memEmail = vmmc.memEmail;
                    members.memGender = vmmc.memGender;
                    members.memTitle = vmmc.memTitle;
                    members.Authority = vmmc.Authority;
                    members.admId = vmmc.admId;

                    db.Members.Add(members);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessageKEY = "職員編號不可重複，請重新輸入!";
                    ViewBag.adm = db.Administrators.ToList();
                    ViewBag.admId = vmmc.admId.ToString();
                    return View(vmmc);
                }

            }
            
            ViewBag.adm = db.Administrators.ToList();
            ViewBag.admId = vmmc.admId.ToString();
            return View(vmmc);
        }

        public ActionResult Delete(string id)
        {
            var mem = db.Members.Where(m => m.memId == id).FirstOrDefault();
            if(mem != null)
            {
                db.Members.Remove(mem);
                db.SaveChanges();
                TempData["ResultMessage"] = String.Format("已成功刪除員工編號[{0}]的相關資料", mem.memId);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = "該員工資料不存在，無法刪除，請重新操作";
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit()
        {
            return View();
        }        
    }
}