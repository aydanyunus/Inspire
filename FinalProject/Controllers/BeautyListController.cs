using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class BeautyListController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: BeautyList
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                posts = db.Posts.Where(p => p.Page_List_id == 7).OrderBy( p=> p.Id).Take(4).ToList(),
                beautyBg = db.BeautyBgs.First(),
                sidebar = db.Sidebars.ToList(),
                banner = db.Banners.First(),
                minipics = db.MiniPics.ToList(),
                freeOffer = db.FreeOffers.First()
            };
            ViewBag.list = db.Posts.Where(p => p.Page_List_id == 7).ToList();
            return View(homeViewModel);
        }
    }
}