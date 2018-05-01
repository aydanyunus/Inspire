using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class AboutUsBgsController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/AboutUsBgs
        public ActionResult Index()
        {
            return View(db.AboutUsBgs.ToList());
        }

        // GET: Admin/AboutUsBgs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUsBg aboutUsBg = db.AboutUsBgs.Find(id);
            if (aboutUsBg == null)
            {
                return HttpNotFound();
            }
            return View(aboutUsBg);
        }

       
        // GET: Admin/AboutUsBgs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUsBg aboutUsBg = db.AboutUsBgs.Find(id);
            if (aboutUsBg == null)
            {
                return HttpNotFound();
            }
            return View(aboutUsBg);
        }

        // POST: Admin/AboutUsBgs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Img")] AboutUsBg aboutUsBg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutUsBg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutUsBg);
        }

        // GET: Admin/AboutUsBgs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUsBg aboutUsBg = db.AboutUsBgs.Find(id);
            if (aboutUsBg == null)
            {
                return HttpNotFound();
            }
            return View(aboutUsBg);
        }

       
    }
}
