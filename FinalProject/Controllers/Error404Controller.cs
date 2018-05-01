using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class Error404Controller : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: Error404
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                bg404 = db.Bg404.First()

            };

            return View(homeViewModel);
        }
    }
}