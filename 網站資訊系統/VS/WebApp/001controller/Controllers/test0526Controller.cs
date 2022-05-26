using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _001controller.Controllers
{
    public class test0526Controller : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string SId,string SName,int Score)
        {
            ViewBag.SId = SId;
            ViewBag.SName = SName;
            ViewBag.Score = Score;
            return View();
        }
    }
}