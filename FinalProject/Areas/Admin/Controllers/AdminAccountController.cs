using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;
using System.Web.Helpers;

namespace FinalProject.Areas.Admin.Controllers
{
    public class AdminAccountController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: Admin/AdminAccount
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email != "" && password != "")
            {
                AdminInfo admin = db.AdminInfoes.Find(1);
                if (admin.Email == email && Crypto.VerifyHashedPassword(admin.Password, password))
                {
                    Session["AdminLogged"] = true;
                    return Content("I");
                }
                else
                {
                    ViewBag.Error = "Email or Password is wrong!";
                }
            }
            else
            {
                ViewBag.Error = "Email or Password cannot be empty!";
            }
            return Content("ksjh");
        }

        public ActionResult Logout()
        {
            Session["AdminLogged"] = null;
            return RedirectToAction("Login", "AdminAccount");
        }

    }
}