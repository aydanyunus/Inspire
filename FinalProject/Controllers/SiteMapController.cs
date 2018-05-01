using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class SiteMapController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: SiteMap
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                SiteMapBg = db.SiteMapBgs.First()
            };

            return View(homeViewModel);
        }
    }
}