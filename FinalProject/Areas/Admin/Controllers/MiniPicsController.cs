using System;
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
    public class MiniPicsController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/MiniPics
        public ActionResult Index()
        {
            return View(db.MiniPics.ToList());
        }

        // GET: Admin/MiniPics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniPic miniPic = db.MiniPics.Find(id);
            if (miniPic == null)
            {
                return HttpNotFound();
            }
            return View(miniPic);
        }

        // GET: Admin/MiniPics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MiniPics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Img,Like_count")] MiniPic miniPic, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    string fileName = null;
                    if (Photo.ContentLength > 0 && Photo.ContentLength <= 3 * 1024 * 1024)
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

                            MiniPic pic = new MiniPic();
                            Photo.SaveAs(newFilePath);
                            pic.Img = fileName;
                            pic.Like_count = miniPic.Like_count;
                            db.MiniPics.Add(pic);
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
            return View(miniPic);

        }

        // GET: Admin/MiniPics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniPic miniPic = db.MiniPics.Find(id);
            if (miniPic == null)
            {
                return HttpNotFound();
            }
            return View(miniPic);
        }

        // POST: Admin/MiniPics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Img,Like_count")] MiniPic miniPic, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                MiniPic active = db.MiniPics.Find(id);
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
                                active.Like_count = miniPic.Like_count;
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
                        active.Like_count = miniPic.Like_count;
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
            return View(miniPic);
        }

        // GET: Admin/MiniPics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniPic miniPic = db.MiniPics.Find(id);
            if (miniPic == null)
            {
                return HttpNotFound();
            }
            return View(miniPic);
        }

        // POST: Admin/MiniPics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MiniPic miniPic = db.MiniPics.Find(id);
            db.MiniPics.Remove(miniPic);
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
