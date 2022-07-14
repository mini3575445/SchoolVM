using _06WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06WebAPI.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var customers = db.Customers.ToList();
            return View(customers);
        }

        public ActionResult Customers()
        {
     
            var customers = db.Customers.ToList();
            return View(customers);
        }
    }
}
