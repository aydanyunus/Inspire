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
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Product product = db.Products.Find(id);
            //if (product == null)
            //{
            //    return HttpNotFound();
            //}
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First(),
                ShopBg = db.ShopBgs.First(),
                ProductImgSingleLarge = db.ProductImgSingleLarges.ToList(),
                ProductImgSingleMini = db.ProductImgSingleMinis.ToList(),
                products = db.Products.ToList()


            };

            return View(homeViewModel);
        }
        public ActionResult CartPage()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                footer = db.Footers.First()
            };
            return View(homeViewModel);
        }
    }
}
