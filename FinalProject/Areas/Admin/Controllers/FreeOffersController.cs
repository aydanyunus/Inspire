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
    public class FreeOffersController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/FreeOffers
        public ActionResult Index()
        {
            return View(db.FreeOffers.ToList());
        }

        // GET: Admin/FreeOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreeOffer freeOffer = db.FreeOffers.Find(id);
            if (freeOffer == null)
            {
                return HttpNotFound();
            }
            return View(freeOffer);
        }

        // GET: Admin/FreeOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FreeOffer freeOffer = db.FreeOffers.Find(id);
            if (freeOffer == null)
            {
                return HttpNotFound();
            }
            return View(freeOffer);
        }

        // POST: Admin/FreeOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, String SubTitle, String Title, String SupTitle, FreeOffer freeOffer)
        {
            if (ModelState.IsValid)
            {
                FreeOffer active = db.FreeOffers.Find(1);
                active.SubTitle = freeOffer.SubTitle;
                active.Title = freeOffer.Title;
                active.SupTitle = freeOffer.SupTitle;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freeOffer);
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
