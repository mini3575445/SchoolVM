using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _0623Form.Models;

namespace _0623Form.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            ViewBag.Date = date;

            Student data = new Student("2", "中明", 80);
            return View(data);
        }
    }
}