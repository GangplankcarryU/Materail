using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpPost]
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
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMMembersEdit vmme = new VMMembersEdit();
            Members members = db.Members.Find(id);


            if (members == null)
            {
                return HttpNotFound();
            }

            

            vmme.memId = members.memId;
            vmme.memName = members.memName;
            vmme.memAct = members.memAct;
            vmme.memPwd = members.memPwd;
            vmme.memTel = members.memTel;
            vmme.memEmail = members.memEmail;
            vmme.memGender = members.memGender;
            vmme.Authority = members.Authority;
            vmme.memTitle = members.memTitle;
            vmme.admId = members.admId;

            ViewBag.adm = db.Administrators.ToList();
            ViewBag.admId = vmme.admId.ToString();

            return View(vmme);
        }
        
        [HttpPost]
                
        public ActionResult Edit(VMMembersEdit vmme)
        {


            if (ModelState.IsValid)
            {
                var exist = db.Members.Where(m => m.memAct == vmme.memAct).FirstOrDefault();


                if (exist == null)
                {
                    var edit = db.Members.Where(x => x.memId == vmme.admId).FirstOrDefault();

                    ViewBag.adm = db.Administrators.ToList();
                    ViewBag.admId = vmme.admId.ToString();


                    edit.memName = vmme.memName;
                    edit.memAct = vmme.memAct;
                    edit.memPwd = vmme.memPwd;
                    edit.memTel = vmme.memTel;
                    edit.memEmail = vmme.memEmail;
                    edit.memGender = vmme.memGender;
                    edit.Authority = vmme.Authority;
                    edit.memTitle = vmme.memTitle;
                    edit.admId = vmme.admId;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if (exist.memId == vmme.memId)
                {
                    var edit = db.Members.Where(x => x.memId == vmme.memId).FirstOrDefault();

                    ViewBag.adm = db.Administrators.ToList();
                    ViewBag.admId = vmme.admId.ToString();

                    edit.memName = vmme.memName;
                    edit.memAct = vmme.memAct;
                    edit.memPwd = vmme.memPwd;
                    edit.memTel = vmme.memTel;
                    edit.memEmail = vmme.memEmail;
                    edit.memGender = vmme.memGender;
                    edit.Authority = vmme.Authority;
                    edit.memTitle = vmme.memTitle;
                    edit.admId = vmme.admId;

                    

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                ViewBag.ErrorMessage = "此帳號已經存在，請重新操作!";
                ViewBag.adm = db.Administrators.ToList();
                ViewBag.admId = vmme.admId.ToString();
                return View(vmme);
            }
            ViewBag.adm = db.Administrators.ToList();
            ViewBag.admId = vmme.admId.ToString();
            return View(vmme);
        }
    }
}