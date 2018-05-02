using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    
    public class HomeController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        public ActionResult Index()
        {
            ViewBag.MustRead = db.Posts.Where(p => p.Page_Partner_id == 10).ToList();
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Slider = db.Sliders.ToList(),
                footer = db.Footers.First(),
                sidebar = db.Sidebars.ToList(),
                trending = db.Trendings.First(),
                instagramPics = db.InstagramPics.ToList(),
                posts = db.Posts.ToList(),
                video = db.Posts.Where(v => v.ImgHomePage_id == 4).FirstOrDefault()
            };
            ViewBag.Mustread = db.Posts.Where(p => p.Page_Partner_id == 10).FirstOrDefault();

            return View(homeViewModel);
        }
    }
}