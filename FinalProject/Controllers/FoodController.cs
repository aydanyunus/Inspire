using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class FoodController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: Food
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                posts = db.Posts.ToList(),
                foodBg = db.FoodBgs.First(),
                sidebar = db.Sidebars.ToList(),
                banner = db.Banners.First(),
                minipics = db.MiniPics.ToList(),
                freeOffer = db.FreeOffers.First()
            };
            ViewBag.food = db.Posts.Where(p => p.Page_Isotop_id == 3).ToList();
            return View(homeViewModel);
        }
    }
}