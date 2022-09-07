using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW7Project.Models;

namespace HW7Project.Controllers
{
    public class HomeController : Controller
    {
        HW7ProjectContext db=new HW7ProjectContext();
        public ActionResult Index()
        {
            var products = db.Products.Select(p => p.ProductID);
            //等於
            //select ProductID from Products

            return View();
        }

        public ActionResult ProductList()
        {
            return View();
        }


        [ChildActionOnly]   //不能直接執行View，只能利用psView存取
        public ActionResult _ProductList(int? itemCount)   //int? 表示這個參數可傳可不傳  //int? 不等於 int ，int?有含null
        {
            List<Products> products;
            if (itemCount == null)
            {
                products = db.Products.Where(p => p.Discontinued == false).OrderByDescending(p => p.CreatedDate).ThenByDescending(p => p.ProductID).ToList();
            }
            else
            {
                products = db.Products.Where(p => p.Discontinued == false).OrderByDescending(p => p.CreatedDate).ThenByDescending(p => p.ProductID).Take((int)itemCount).ToList();
            }
            return View(products);
        }


        public ActionResult MyCart()
        {

            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {

            //select * from Members where account=@account and password=@password
            string pw = Members.getHashPassword(vMLogin.Password);
            var member = db.Members.Where(m => m.Account == vMLogin.Account && m.Password == pw).FirstOrDefault();

            if (member == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有錯!!";
                return View(vMLogin);
            }

            Session["member"] = member;
            return RedirectToAction("ProductList");


        }


        [LoginCheck]
        public ActionResult Logout()
        {

            Session["member"] = null;
            return RedirectToAction("Login", "Home");
        }


    }
}