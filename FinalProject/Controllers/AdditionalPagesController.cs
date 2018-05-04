using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class AdditionalPagesController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: AdditionalPages
        public ActionResult Typography()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First()
            };
            return View(homeViewModel);
        }
        public ActionResult Forms()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First()
            };
            return View(homeViewModel);
        }
        public ActionResult Buttons()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First()
            };
            return View(homeViewModel);
        }
        public ActionResult Tables()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First()
            };
            return View(homeViewModel);
        }
        public ActionResult Grid()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First()
            };
            return View(homeViewModel);
        }
        public ActionResult Search()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First()
            };
            return View(homeViewModel);
        }
    }
}