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
    public class SlidersController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/Sliders
        public ActionResult Index()
        {
            var sliders = db.Sliders.Include(s => s.SliderCategory).Include(s => s.SliderCategory1);
            return View(sliders.ToList());
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }       

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category1_id = new SelectList(db.SliderCategories, "Id", "Name", slider.Category1_id);
            ViewBag.Category2_id = new SelectList(db.SliderCategories, "Id", "Name", slider.Category2_id);
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind(Include = "Id,Background_img,Title,Written_date,View_Count,Category1_id,Category2_id")] Slider slider, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                Slider active = db.Sliders.Find(id);
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
                                var path = Path.Combine(Server.MapPath("~/Uploads/"), active.Background_img);

                                if (System.IO.File.Exists(path))
                                {
                                    System.IO.File.Delete(path);
                                }

                                DateTime dt = DateTime.Now;
                                var beforeStr = dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second + "_" + dt.Millisecond;
                                fileName = beforeStr + Path.GetFileName(Photo.FileName);
                                var newFilePath = Path.Combine(Server.MapPath("~/Uploads/"), fileName);

                                Photo.SaveAs(newFilePath);

                                active.Background_img = fileName;
                                active.SliderCategory.Name = slider.SliderCategory.Name;
                                active.Category1_id = slider.Category1_id;
                                active.Category2_id = slider.Category2_id;
                                active.Title = slider.Title;
                                active.View_Count = slider.View_Count;
                                active.Written_date = slider.Written_date;
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
                        active.Category1_id = slider.Category1_id;
                        active.Category2_id = slider.Category2_id;
                        active.Title = slider.Title;
                        active.View_Count = slider.View_Count;
                        active.Written_date = slider.Written_date;
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
            ViewBag.Category1_id = new SelectList(db.SliderCategories, "Id", "Name", slider.Category1_id);
            ViewBag.Category2_id = new SelectList(db.SliderCategories, "Id", "Name", slider.Category2_id);
            return View(slider);
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
