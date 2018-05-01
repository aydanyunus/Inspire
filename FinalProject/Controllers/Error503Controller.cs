using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class Error503Controller : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                bg503 = db.Bg503.First()
            };

            return View(homeViewModel);
        }

    }
}
