using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels.HomeViewModel;

namespace FinalProject.Controllers
{
    public class ShopController : Controller
    {
        BlogInspireEntities db = new BlogInspireEntities();

        // GET: Shop
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                products = db.Products.ToList(),
                product_to_categories = db.Product_to_Categories.ToList(),
                ShopBg = db.ShopBgs.First()
            };

            return View(homeViewModel);
        }

        public ActionResult ShopList()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                products = db.Products.ToList().OrderBy(p => p.Id).Take(3).ToList(),
                ShopBg = db.ShopBgs.First()
            };
            return View(homeViewModel);
        }

        public ActionResult Details()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                ShopBg = db.ShopBgs.First(),
                products = db.Products.ToList()
            };
            ViewBag.ProductImgSingleMini = db.ProductImgSingleMinis.ToList();
            ViewBag.ProductImgSingleLarge = db.ProductImgSingleLarges.ToList();
            ViewBag.products = db.Products.ToList();
            return View(homeViewModel);
        }
        public ActionResult CartPage()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                ShopBg = db.ShopBgs.First(),
                product_to_categories = db.Product_to_Categories.OrderBy(p => p.Id).Take(2).ToList(),
                products = db.Products.Where(p => p.ImgMini_id != null).ToList()
            };
            return View(homeViewModel);
        }
    }
}
