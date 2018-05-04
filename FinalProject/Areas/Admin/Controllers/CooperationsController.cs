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
    public class CooperationsController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/Cooperations
        public ActionResult Index()
        {
            return View(db.Cooperations.ToList());
        }

        // GET: Admin/Cooperations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooperation cooperation = db.Cooperations.Find(id);
            if (cooperation == null)
            {
                return HttpNotFound();
            }
            return View(cooperation);
        }       

        // GET: Admin/Cooperations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cooperation cooperation = db.Cooperations.Find(id);
            if (cooperation == null)
            {
                return HttpNotFound();
            }
            return View(cooperation);
        }

        // POST: Admin/Cooperations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, String Content1, String Content2, Cooperation cooperation)
        {
            if (ModelState.IsValid)
            {
                Cooperation active = db.Cooperations.Find(1);
                active.Content1 = cooperation.Content1;
                active.Content2 = cooperation.Content2;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cooperation);
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
