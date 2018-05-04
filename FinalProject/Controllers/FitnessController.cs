using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class FitnessController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: Fitness
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                posts = db.Posts.ToList(),
                fitnessBg = db.FitnessBgs.First(),
                sidebar = db.Sidebars.ToList(),
                banner = db.Banners.First(),
                minipics = db.MiniPics.ToList(),
                freeOffer = db.FreeOffers.First()
            };
            ViewBag.fitness = db.Posts.Where(p => p.Page_Isotop_id == 2).ToList();
            return View(homeViewModel);
        }
    }
}
