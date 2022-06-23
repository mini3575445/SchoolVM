using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class SimpleBindController : Controller
    {
        //02-2-3 建立GET與POST的Create方法
        //Action
        public ActionResult Create()
        {
           // ViewBag.Date = DateTime.Now;
            return View();
        }

        [HttpPost]
        public ActionResult Create(string PId, string PName, int Price)
        {
            ViewBag.PId = PId;
            ViewBag.PName = PName;
            ViewBag.Price = Price;

            return View();
        }
    }
}