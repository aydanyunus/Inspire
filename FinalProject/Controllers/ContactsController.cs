using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class ContactsController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();
        // GET: Contacts
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                contactsBg = db.ContactsBgs.First(),
                Contact = db.Contacts.First()
            };
            return View(homeViewModel);
        }
    }
}