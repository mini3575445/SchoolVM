using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _001controller.Models;

namespace _001controller.Controllers
{
    public class test020526Controller : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)    //把Class引入Action
        {
            ViewBag.SId = s.SId;
            ViewBag.SName = s.SName;
            ViewBag.Score = s.Score;
            return View();
        }
    }
}