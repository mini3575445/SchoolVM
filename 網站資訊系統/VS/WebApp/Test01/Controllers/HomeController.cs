using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test01.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public string ShowAryDesc()
        {
            int[] score = { 58, 79, 14, 100, 65 };
            string show = "";
            var result = from s in score
                         orderby s descending
                         select s;
            //擴充
            //var result = score.OrderByDescending(s => s);
            foreach(var item in result)
            {
                show += item + ",";
            }
            return show;
        }


        public string ShowAryAsc()
        {
            int[] score = { 58, 79, 14, 100, 65 };
            string show = "";
            var result = from s in score
                         orderby s
                         select s;

            foreach (var item in result)
            {
                show += item + ",";
            }
            return show;
        }



    }
}