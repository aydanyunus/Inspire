using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class MaintenanceController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: Maintenance
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                maintenanceBg = db.MaintenanceBgs.First()
            };
            return View(homeViewModel);
        }
    }
}