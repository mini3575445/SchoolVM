using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _001controller.Controllers
{
    public class SimpleBindController : Controller
    {
        // GET: SimpleBind
        //ActionResult是一個Action物件
        //寫在Controller的函數都叫Action
        public ActionResult Create()
        {
            //ViewBag.Date = DateTime.Now;  
            return View();
        }


        [HttpPost]
        public ActionResult Create(string PId,string PName,int Price)
        {
            ViewBag.PId = PId;
            ViewBag.PName = PName;
            ViewBag.Price= Price;
            return View();
        }

    }
}