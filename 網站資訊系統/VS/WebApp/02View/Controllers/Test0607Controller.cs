using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _02View.Models;


//在View上利用HtmlHelper顯示Model.物件名稱,及input.name
namespace _02View.Controllers
{
    public class Test0607Controller : Controller
    {
        // GET: Test0607
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cat cat)
        {
            string result = "";

            result = "編號:" + cat.Id + "<br>" +
                    "姓名:" + cat.Name + "<br>" +
                    "顏色:" + cat.Color;
            
            ViewBag.result = result;

            return View();
        }
    }
}