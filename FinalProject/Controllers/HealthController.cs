using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class HealthController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: Health
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                posts = db.Posts.ToList(),
                healthBg = db.HealthBgs.First(),
                sidebar = db.Sidebars.ToList(),
                banner = db.Banners.First(),
                minipics = db.MiniPics.ToList(),
                freeOffer = db.FreeOffers.First()
            };
            ViewBag.health = db.Posts.Where(p => p.Page_Isotop_id == 4).ToList();
            return View(homeViewModel);
        }
    }
}