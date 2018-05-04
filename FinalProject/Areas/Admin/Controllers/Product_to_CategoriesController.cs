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
    public class Product_to_CategoriesController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/Product_to_Categories
        public ActionResult Index()
        {
            var product_to_Categories = db.Product_to_Categories.Include(p => p.ProductCategory).Include(p => p.Product);
            return View(product_to_Categories.ToList());
        }

        // GET: Admin/Product_to_Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_to_Categories product_to_Categories = db.Product_to_Categories.Find(id);
            if (product_to_Categories == null)
            {
                return HttpNotFound();
            }
            return View(product_to_Categories);
        }

        // GET: Admin/Product_to_Categories/Create
        public ActionResult Create()
        {
            ViewBag.Category_id = new SelectList(db.ProductCategories, "Id", "Name");
            ViewBag.Product_id = new SelectList(db.Products, "Id", "Price");
            return View();
        }

        // POST: Admin/Product_to_Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Product_id,Category_id")] Product_to_Categories product_to_Categories)
        {
            if (ModelState.IsValid)
            {
                db.Product_to_Categories.Add(product_to_Categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_id = new SelectList(db.ProductCategories, "Id", "Name", product_to_Categories.Category_id);
            ViewBag.Product_id = new SelectList(db.Products, "Id", "Price", product_to_Categories.Product_id);
            return View(product_to_Categories);
        }

        // GET: Admin/Product_to_Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_to_Categories product_to_Categories = db.Product_to_Categories.Find(id);
            if (product_to_Categories == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_id = new SelectList(db.ProductCategories, "Id", "Name", product_to_Categories.Category_id);
            ViewBag.Product_id = new SelectList(db.Products, "Id", "Price", product_to_Categories.Product_id);
            return View(product_to_Categories);
        }

        // POST: Admin/Product_to_Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind(Include = "Id,Product_id,Category_id")] Product_to_Categories product_to_Categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_to_Categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_id = new SelectList(db.ProductCategories, "Id", "Name", product_to_Categories.Category_id);
            ViewBag.Product_id = new SelectList(db.Products, "Id", "Price", product_to_Categories.Product_id);
            return View(product_to_Categories);
        }

        // GET: Admin/Product_to_Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_to_Categories product_to_Categories = db.Product_to_Categories.Find(id);
            if (product_to_Categories == null)
            {
                return HttpNotFound();
            }
            return View(product_to_Categories);
        }

        // POST: Admin/Product_to_Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_to_Categories product_to_Categories = db.Product_to_Categories.Find(id);
            db.Product_to_Categories.Remove(product_to_Categories);
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
