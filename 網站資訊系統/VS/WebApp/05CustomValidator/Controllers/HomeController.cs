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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            //IsValid如果模型驗證全部通過
            if (ModelState.IsValid)
            {
                //成功就至首頁
                //把資料存入DB
                return RedirectToAction("Index");
            }
            //失敗回傳member
            return View(member);



        }
    }
}