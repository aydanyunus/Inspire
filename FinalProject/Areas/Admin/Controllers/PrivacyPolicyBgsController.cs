﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    [AuthorizationFilterController]
    public class PrivacyPolicyBgsController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/PrivacyPolicyBgs
        public ActionResult Index()
        {
            return View(db.PrivacyPolicyBgs.ToList());
        }

        // GET: Admin/PrivacyPolicyBgs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivacyPolicyBg privacyPolicyBg = db.PrivacyPolicyBgs.Find(id);
            if (privacyPolicyBg == null)
            {
                return HttpNotFound();
            }
            return View(privacyPolicyBg);
        }

        // GET: Admin/PrivacyPolicyBgs/Create
        public ActionResult Create()
        {
            return View();
        }

       

        // GET: Admin/PrivacyPolicyBgs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrivacyPolicyBg privacyPolicyBg = db.PrivacyPolicyBgs.Find(id);
            if (privacyPolicyBg == null)
            {
                return HttpNotFound();
            }
            return View(privacyPolicyBg);
        }

        // POST: Admin/PrivacyPolicyBgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Img")] PrivacyPolicyBg privacyPolicyBg, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                PrivacyPolicyBg activebg = db.PrivacyPolicyBgs.Find(id);
                if (activebg != null)
                {
                    string fileName = null;
                    if (Photo != null)
                    {
                        if (Photo.ContentLength > 0 && Photo.ContentLength <= 3 * 1024 * 1024)
                        {
                            if (Photo.ContentType.ToLower() == "image/jpeg" ||
                                Photo.ContentType.ToLower() == "image/jpg" ||
                                Photo.ContentType.ToLower() == "image/png" ||
                                Photo.ContentType.ToLower() == "image/gif"
                            )
                            {
                                var path = Path.Combine(Server.MapPath("~/Uploads/"), activebg.Img);

                                if (System.IO.File.Exists(path))
                                {
                                    System.IO.File.Delete(path);
                                }

                                DateTime dt = DateTime.Now;
                                var beforeStr = dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second + "_" + dt.Millisecond;
                                fileName = beforeStr + Path.GetFileName(Photo.FileName);
                                var newFilePath = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

                                Photo.SaveAs(newFilePath);

                                activebg.Img = fileName;
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.EditError = "Photo type is not valid.";
                                return View(activebg);
                            }
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type should not be more than 3 MB.";
                            return View(activebg);
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index");

                    }
                }
                else
                {
                    ViewBag.EditError = "Id is not correct.";
                    return View(activebg);
                }
            }
            return View(privacyPolicyBg);
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
