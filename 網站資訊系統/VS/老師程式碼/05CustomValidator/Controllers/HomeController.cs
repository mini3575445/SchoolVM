using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _05CustomValidator.Models;

namespace _05CustomValidator.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                //把資料存入DB
                return  RedirectToAction("Index");
            }

            return View(member);


            
        }
    }
}