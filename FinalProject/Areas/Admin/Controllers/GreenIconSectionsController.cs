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
    public class GreenIconSectionsController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/GreenIconSections
        public ActionResult Index()
        {
            return View(db.GreenIconSections.ToList());
        }

        // GET: Admin/GreenIconSections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GreenIconSection greenIconSection = db.GreenIconSections.Find(id);
            if (greenIconSection == null)
            {
                return HttpNotFound();
            }
            return View(greenIconSection);
        }       

        // GET: Admin/GreenIconSections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GreenIconSection greenIconSection = db.GreenIconSections.Find(id);
            if (greenIconSection == null)
            {
                return HttpNotFound();
            }
            return View(greenIconSection);
        }

        // POST: Admin/GreenIconSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Icon,Title,Content")] GreenIconSection greenIconSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(greenIconSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(greenIconSection);
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
