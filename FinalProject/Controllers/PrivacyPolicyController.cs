using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: PrivacyPolicy
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                PrivacyPolicyBg = db.PrivacyPolicyBgs.First(),
                privacypolicy = db.PrivacyPolicies.ToList()
            };
            ViewBag.Privacy = db.PrivacyPolicies.ToList();
            return View(homeViewModel);
        }
    }
}