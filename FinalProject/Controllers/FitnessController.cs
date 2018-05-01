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
                posts = db.Posts.ToList()
            };
            return View(homeViewModel);
        }
    }
}
