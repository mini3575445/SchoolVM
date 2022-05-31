using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _02View.Models;

namespace _02View.Controllers
{
    public class test053001Controller : Controller
    {
        // GET: test053001


        Apple apple = new Apple { Breed = "Fuji", Origin = "Japan", IsMature = true };


        public string EatApple<T>(T num)
        {
            
            return "我吃了" + num + "個蘋果，資料型別為" + typeof(T);

            
        }

        public void Main()
        {
            Response.Write(EatApple<int>(5)+"<br>");
            Response.Write(EatApple<string>("6") + "<br>");
            Response.Write(EatApple<float>(2.5f) + "<br>");
        }
    }
}