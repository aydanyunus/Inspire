﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        [AuthorizationFilterController]

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}