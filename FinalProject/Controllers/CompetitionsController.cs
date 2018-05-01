using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class CompetitionsController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: Competitions
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                freeOffer = db.FreeOffers.First(),
                sidebar = db.Sidebars.ToList(),
                competitionsBg = db.CompetitionsBgs.First()
            };
            return View(homeViewModel);
        }

        // GET: Competitions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
