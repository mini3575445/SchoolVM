using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03Model.Controllers
{
    public class Test0607Controller : Controller
    {
        public string ShowAryDesc()
        { 
        int[] score = { 100, 51, 35, 87, 76 };
        string show = "";

            //LinQ
            var result = from s in score
                         orderby s descending
                         select s;
            Console.WriteLine("123");
            
            //LinQ擴充 
            //var result = score.OrderByDescending(s => s);


            //SQL select s from score
            //order by s desc
            foreach (var item in result) {
                show += item + ",";
            }
            return show;
        }
    }
}