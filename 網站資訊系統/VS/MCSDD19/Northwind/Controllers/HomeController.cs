using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Northwind.Models;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {

        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index2()
        {
            var Products = db.Products.ToList();
            return View(Products);
        }
        public ActionResult Create()
        {
            return View();
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }        
        
    }
}