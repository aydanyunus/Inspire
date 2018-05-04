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
    [AuthorizationFilterController]
    public class HowItAllBegansController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/HowItAllBegans
        public ActionResult Index()
        {
            return View(db.HowItAllBegans.ToList());
        }

        // GET: Admin/HowItAllBegans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HowItAllBegan howItAllBegan = db.HowItAllBegans.Find(id);
            if (howItAllBegan == null)
            {
                return HttpNotFound();
            }
            return View(howItAllBegan);
        }

        // GET: Admin/HowItAllBegans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HowItAllBegan howItAllBegan = db.HowItAllBegans.Find(id);
            if (howItAllBegan == null)
            {
                return HttpNotFound();
            }
            return View(howItAllBegan);
        }

        // POST: Admin/HowItAllBegans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind(Include = "Id,Facebook_link,Twitter_link,Pinterest_link,Instagram_link")] String Content1, String Content2, HowItAllBegan howItAllBegan)
        {
            if (ModelState.IsValid)
            {
                HowItAllBegan active = db.HowItAllBegans.Find(id);
                active.Facebook_link = howItAllBegan.Facebook_link;
                active.Twitter_link = howItAllBegan.Twitter_link;
                active.Pinterest_link = howItAllBegan.Pinterest_link;
                active.Instagram_link = howItAllBegan.Instagram_link;
                active.Content1 = howItAllBegan.Content1;
                active.Content2 = howItAllBegan.Content2;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(howItAllBegan);
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
