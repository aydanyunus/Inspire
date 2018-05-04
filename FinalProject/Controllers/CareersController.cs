using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class CareersController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                careersBg = db.CareersBgs.First(),
                career = db.Careers.First(),
                vacancies = db.Vacancies.ToList(),
                positions = db.Positions.ToList(),
                sidebar = db.Sidebars.ToList(),
                lookingForWork = db.LookingForWorks.First()
            };
            return View(homeViewModel);
        }
    }
}
