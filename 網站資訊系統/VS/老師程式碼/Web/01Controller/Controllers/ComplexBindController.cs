using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//02-3-5 using _01Controller.Models
using _01Controller.Models;
//引入命名空間(Namepace)

namespace _01Controller.Controllers
{
    public class ComplexBindController : Controller
    {
        //02-3-6 建立GET與POST的Create方法
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
          
            ViewBag.PId = p.PId;
            ViewBag.PName = p.PName;
            ViewBag.Price = p.Price;

            return View();
        }
    }
}