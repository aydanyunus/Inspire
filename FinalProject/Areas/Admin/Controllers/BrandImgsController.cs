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
    public class BrandImgsController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/BrandImgs
        public ActionResult Index()
        {
            return View(db.BrandImgs.ToList());
        }

        // GET: Admin/BrandImgs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandImg brandImg = db.BrandImgs.Find(id);
            if (brandImg == null)
            {
                return HttpNotFound();
            }
            return View(brandImg);
        }

        // GET: Admin/BrandImgs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BrandImgs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandImg brandImg, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    string fileName = null;
                    if (Photo.ContentLength > 0 && Photo.ContentLength <= 3 * 1024 )
                    {
                        if (Photo.ContentType.ToLower() == "image/jpeg" ||
                            Photo.ContentType.ToLower() == "image/jpg" ||
                            Photo.ContentType.ToLower() == "image/png" ||
                            Photo.ContentType.ToLower() == "image/gif"
                        )
                        {
                            DateTime dt = DateTime.Now;
                            var beforeStr = dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second + "_" + dt.Millisecond;
                            fileName = beforeStr + Path.GetFileName(Photo.FileName);
                            var newFilePath = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

                            BrandImg brandimg = new BrandImg();
                            Photo.SaveAs(newFilePath);
                            brandimg.Img = fileName;
                            db.BrandImgs.Add(brandImg);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.EditError = "Photo type is not valid.";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.EditError = "Photo type should not be more than 3 MB.";
                        return View();
                    }
                }
                ViewBag.EditError = "photo can not be empty.";
                return View();
            }
            return View(brandImg);       
        }

        // GET: Admin/BrandImgs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandImg brandImg = db.BrandImgs.Find(id);
            if (brandImg == null)
            {
                return HttpNotFound();
            }
            return View(brandImg);
        }

        // POST: Admin/BrandImgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Img")] BrandImg brandImg, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                BrandImg activebg = db.BrandImgs.Find(id);
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
            return View(brandImg);
        }

        // GET: Admin/BrandImgs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandImg brandImg = db.BrandImgs.Find(id);
            if (brandImg == null)
            {
                return HttpNotFound();
            }
            return View(brandImg);
        }

        // POST: Admin/BrandImgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrandImg brandImg = db.BrandImgs.Find(id);
            db.BrandImgs.Remove(brandImg);
            db.SaveChanges();
            return RedirectToAction("Index");
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
