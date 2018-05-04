using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class SinglePostController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: SinglePost
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                sidebar = db.Sidebars.ToList(),
                banner = db.Banners.First(),
                minipics = db.MiniPics.ToList(),
                posts = db.Posts.ToList(),
                freeOffer = db.FreeOffers.First(),
                SinglePostBg = db.SinglePostBgs.First(),
                SinglePost = db.SinglePosts.First()              
            };

            return View(homeViewModel);
        }
    }
}