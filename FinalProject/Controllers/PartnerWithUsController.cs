using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class PartnerWithUsController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                partnerWithUsBg = db.PartnerWithUsBgs.First(),
                cooperation = db.Cooperations.First(),
                greeniconsection = db.GreenIconSections.ToList(),
                ourPartner = db.OurPartners.First(),
                brandimgs = db.BrandImgs.ToList(),
                sidebar = db.Sidebars.ToList(),
                lookingForWork = db.LookingForWorks.First(),
                minipics = db.MiniPics.ToList(),
                posts = db.Posts.ToList()
            };
            ViewBag.Mustread = db.Posts.Where(p => p.Page_Partner_id == 10).ToList();


            return View(homeViewModel);
        }
    }
}