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
            Student data = new Student("1", "小明", 80);
            ViewData.Model = data;
            //View(Model)   //回傳模型
            return View();
            //Q1:return View的回傳模型?  A:View為多載，大致上可這樣使用View("Action",Model)，可參考https://docs.microsoft.com/zh-tw/aspnet/core/mvc/views/overview?view=aspnetcore-6.0
            //Q2:return View()，不是回傳全部值至View嗎，為何沒有回傳到data?
        }
    }
}