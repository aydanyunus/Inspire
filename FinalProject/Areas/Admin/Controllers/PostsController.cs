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
    public class PostsController : Controller
    {
        private BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author).Include(p => p.CompetitionsImg).Include(p => p.HomePageImg).Include(p => p.Page).Include(p => p.Page1).Include(p => p.Page2).Include(p => p.Page3).Include(p => p.Page4).Include(p => p.Page5).Include(p => p.PostCategory).Include(p => p.PostCategory1).Include(p => p.PostImgMedium).Include(p => p.PostImgSmall).Include(p => p.SinglePost);
            return View(posts.ToList());
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.Author_id = new SelectList(db.Authors, "Id", "Name");
            ViewBag.ImgCompetitions_id = new SelectList(db.CompetitionsImgs, "Id", "Img");
            ViewBag.ImgHomePage_id = new SelectList(db.HomePageImgs, "Id", "Img");
            ViewBag.Page_Competitions_id = new SelectList(db.Pages, "Id", "Name");
            ViewBag.Page_home_id = new SelectList(db.Pages, "Id", "Name");
            ViewBag.Page_Isotop_id = new SelectList(db.Pages, "Id", "Name");
            ViewBag.Page_List_id = new SelectList(db.Pages, "Id", "Name");
            ViewBag.Page_Partner_id = new SelectList(db.Pages, "Id", "Name");
            ViewBag.Page_SinglePost_id = new SelectList(db.Pages, "Id", "Name");
            ViewBag.Category1_id = new SelectList(db.PostCategories, "Id", "Name");
            ViewBag.Category2_id = new SelectList(db.PostCategories, "Id", "Name");
            ViewBag.ImgMedium_id = new SelectList(db.PostImgMediums, "Id", "Img");
            ViewBag.ImgSmall_id = new SelectList(db.PostImgSmalls, "Id", "Img");
            ViewBag.SinglePost_id = new SelectList(db.SinglePosts, "Id", "Content1");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,Written_date,View_Count,SinglePost_id,ImgMedium_id,ImgSmall_id,ImgCompetitions_id,ImgHomePage_id,SubTitle,Category1_id,Category2_id,Author_id,Page_home_id,Page_Competitions_id,Page_List_id,Page_SinglePost_id,Page_Isotop_id,Page_Partner_id")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Author_id = new SelectList(db.Authors, "Id", "Name", post.Author_id);
            ViewBag.ImgCompetitions_id = new SelectList(db.CompetitionsImgs, "Id", "Img", post.ImgCompetitions_id);
            ViewBag.ImgHomePage_id = new SelectList(db.HomePageImgs, "Id", "Img", post.ImgHomePage_id);
            ViewBag.Page_Competitions_id = new SelectList(db.Pages, "Id", "Name", post.Page_Competitions_id);
            ViewBag.Page_home_id = new SelectList(db.Pages, "Id", "Name", post.Page_home_id);
            ViewBag.Page_Isotop_id = new SelectList(db.Pages, "Id", "Name", post.Page_Isotop_id);
            ViewBag.Page_List_id = new SelectList(db.Pages, "Id", "Name", post.Page_List_id);
            ViewBag.Page_Partner_id = new SelectList(db.Pages, "Id", "Name", post.Page_Partner_id);
            ViewBag.Page_SinglePost_id = new SelectList(db.Pages, "Id", "Name", post.Page_SinglePost_id);
            ViewBag.Category1_id = new SelectList(db.PostCategories, "Id", "Name", post.Category1_id);
            ViewBag.Category2_id = new SelectList(db.PostCategories, "Id", "Name", post.Category2_id);
            ViewBag.ImgMedium_id = new SelectList(db.PostImgMediums, "Id", "Img", post.ImgMedium_id);
            ViewBag.ImgSmall_id = new SelectList(db.PostImgSmalls, "Id", "Img", post.ImgSmall_id);
            ViewBag.SinglePost_id = new SelectList(db.SinglePosts, "Id", "Content1", post.SinglePost_id);
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.Author_id = new SelectList(db.Authors, "Id", "Name", post.Author_id);
            ViewBag.ImgCompetitions_id = new SelectList(db.CompetitionsImgs, "Id", "Img", post.ImgCompetitions_id);
            ViewBag.ImgHomePage_id = new SelectList(db.HomePageImgs, "Id", "Img", post.ImgHomePage_id);
            ViewBag.Page_Competitions_id = new SelectList(db.Pages, "Id", "Name", post.Page_Competitions_id);
            ViewBag.Page_home_id = new SelectList(db.Pages, "Id", "Name", post.Page_home_id);
            ViewBag.Page_Isotop_id = new SelectList(db.Pages, "Id", "Name", post.Page_Isotop_id);
            ViewBag.Page_List_id = new SelectList(db.Pages, "Id", "Name", post.Page_List_id);
            ViewBag.Page_Partner_id = new SelectList(db.Pages, "Id", "Name", post.Page_Partner_id);
            ViewBag.Page_SinglePost_id = new SelectList(db.Pages, "Id", "Name", post.Page_SinglePost_id);
            ViewBag.Category1_id = new SelectList(db.PostCategories, "Id", "Name", post.Category1_id);
            ViewBag.Category2_id = new SelectList(db.PostCategories, "Id", "Name", post.Category2_id);
            ViewBag.ImgMedium_id = new SelectList(db.PostImgMediums, "Id", "Img", post.ImgMedium_id);
            ViewBag.ImgSmall_id = new SelectList(db.PostImgSmalls, "Id", "Img", post.ImgSmall_id);
            ViewBag.SinglePost_id = new SelectList(db.SinglePosts, "Id", "Content1", post.SinglePost_id);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind(Include = "Id,Title,Content,Written_date,View_Count,SinglePost_id,ImgMedium_id,ImgSmall_id,ImgCompetitions_id,ImgHomePage_id,SubTitle,Category1_id,Category2_id,Author_id,Page_home_id,Page_Competitions_id,Page_List_id,Page_SinglePost_id,Page_Isotop_id,Page_Partner_id")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Author_id = new SelectList(db.Authors, "Id", "Name", post.Author_id);
            ViewBag.ImgCompetitions_id = new SelectList(db.CompetitionsImgs, "Id", "Img", post.ImgCompetitions_id);
            ViewBag.ImgHomePage_id = new SelectList(db.HomePageImgs, "Id", "Img", post.ImgHomePage_id);
            ViewBag.Page_Competitions_id = new SelectList(db.Pages, "Id", "Name", post.Page_Competitions_id);
            ViewBag.Page_home_id = new SelectList(db.Pages, "Id", "Name", post.Page_home_id);
            ViewBag.Page_Isotop_id = new SelectList(db.Pages, "Id", "Name", post.Page_Isotop_id);
            ViewBag.Page_List_id = new SelectList(db.Pages, "Id", "Name", post.Page_List_id);
            ViewBag.Page_Partner_id = new SelectList(db.Pages, "Id", "Name", post.Page_Partner_id);
            ViewBag.Page_SinglePost_id = new SelectList(db.Pages, "Id", "Name", post.Page_SinglePost_id);
            ViewBag.Category1_id = new SelectList(db.PostCategories, "Id", "Name", post.Category1_id);
            ViewBag.Category2_id = new SelectList(db.PostCategories, "Id", "Name", post.Category2_id);
            ViewBag.ImgMedium_id = new SelectList(db.PostImgMediums, "Id", "Img", post.ImgMedium_id);
            ViewBag.ImgSmall_id = new SelectList(db.PostImgSmalls, "Id", "Img", post.ImgSmall_id);
            ViewBag.SinglePost_id = new SelectList(db.SinglePosts, "Id", "Content1", post.SinglePost_id);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
