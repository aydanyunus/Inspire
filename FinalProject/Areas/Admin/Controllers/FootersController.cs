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
    public class FootersController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/Footers
        public ActionResult Index()
        {
            return View(db.Footers.ToList());
        }

        // GET: Admin/Footers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = db.Footers.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // GET: Admin/Footers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footer footer = db.Footers.Find(id);
            if (footer == null)
            {
                return HttpNotFound();
            }
            return View(footer);
        }

        // POST: Admin/Footers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind(Include = "Id,Copywrite_date,Instagram_link,Facebook_link,Twitter_link,Adress")] String Title, Footer footer)
        {
            if (ModelState.IsValid)
            {
                Footer active = db.Footers.Find(1);
                active.Copywrite_date = footer.Copywrite_date;
                active.Instagram_link = footer.Instagram_link;
                active.Facebook_link = footer.Facebook_link;
                active.Twitter_link = footer.Twitter_link;
                active.Adress = footer.Adress;
                active.Title = footer.Title;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footer);
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
