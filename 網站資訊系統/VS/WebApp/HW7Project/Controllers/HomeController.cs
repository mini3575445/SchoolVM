using HW7Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW7Project.Controllers
{
    public class HomeController : Controller
    {
        HW7ProjectContext db = new HW7ProjectContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        //前台商品瀏覽
        public ActionResult ProductList()
        {
            var products = db.Products.Where(p=>p.Discontinued==false).ToList();

            return View(products);
        
        }




    }


}