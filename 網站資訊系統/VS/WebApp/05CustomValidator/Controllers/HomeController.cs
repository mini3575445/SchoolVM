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
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Member member)
        {

            //ModelState.IsValid，如果驗證全都通過的話
            if (ModelState.IsValid)
            {
                //把資料存入DB
                return RedirectToAction("Index");
            }
            //錯的話把資料傳回View
            return View(member);
        }
    }
}