using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _001controller.Models;//引入命名空間(NameSapce)
//命名空間:有兩個王小明。避免混淆把它分為C501王小明，C502王小明。C501就是命名空間

namespace _001controller.Controllers
{
    public class ComplexBindController : Controller
    {
        public ActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            ViewBag.PId = p.PId;
            ViewBag.PName = p.PName;
            ViewBag.Price = p.Price;
            return View();
        }
    }
}