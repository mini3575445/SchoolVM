using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _02View.Models;

namespace _02View.Controllers
{
    public class HTMLHelperController : Controller
    {
       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member mebmer)
        {
            string result = "";
            result = "您的註冊資料如下:<br>" +
                "帳號:" + mebmer.UserId + ":<br>" +
                "密碼:" + mebmer.Pwd + ":<br>" +
                "姓名:" + mebmer.Name + ":<br>" +
                "E-mail:" + mebmer.Email + ":<br>" +
                "生日:" + mebmer.Birthday;

            ViewBag.Result = result;

            return View();
        }
    }
}