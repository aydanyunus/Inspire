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
    public class CareersController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/Careers
        public ActionResult Index()
        {
            return View(db.Careers.ToList());
        }

        // GET: Admin/Careers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }

        

        // GET: Admin/Careers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }

        // POST: Admin/Careers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string Content, Career career, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                Career active = db.Careers.Find(id);
                if (active != null)
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
                                var path = Path.Combine(Server.MapPath("~/Uploads/"), active.Img);

                                if (System.IO.File.Exists(path))
                                {
                                    System.IO.File.Delete(path);
                                }

                                DateTime dt = DateTime.Now;
                                var beforeStr = dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second + "_" + dt.Millisecond;
                                fileName = beforeStr + Path.GetFileName(Photo.FileName);
                                var newFilePath = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

                                Photo.SaveAs(newFilePath);

                                active.Img = fileName;
                                active.Content = Content;
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                ViewBag.EditError = "Photo type is not valid.";
                                return View(active);
                            }
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type should not be more than 3 MB.";
                            return View(active);
                        }
                    }
                    else
                    {
                        active.Content = Content;
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                }
                else
                {
                    ViewBag.EditError = "Id is not correct.";
                    return View(active);
                }
            }
            return View(career);
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
