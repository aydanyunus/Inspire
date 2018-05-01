using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class AboutUsController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                aboutUsBg = db.AboutUsBgs.First(),
                ourTeam = db.OurTeams.First(),
                howItAllBegan = db.HowItAllBegans.First(),
                newsLetter = db.NewsLetters.First(),
                sidebar = db.Sidebars.ToList(),
                freeOffer = db.FreeOffers.First()
            };

            return View(homeViewModel);
        }
    }
}
