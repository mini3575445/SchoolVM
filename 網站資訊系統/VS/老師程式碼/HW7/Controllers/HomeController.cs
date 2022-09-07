﻿using System;
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

            Random r = new Random();
            int i=r.Next(0, db.Products.Count());

            //select ProductID from Products
            var productIDs = db.Products.Select(p => p.ProductID).ToList();
            string PID = productIDs[i];

            ViewBag.PID = PID;


            return View();
        }

        public ActionResult ProductList()
        {

            return View();
        }

        [ChildActionOnly]
        public ActionResult _ProductList(int itemCount=0)
        {
            List<Products> products;

            if (itemCount==0)

                 products = db.Products.Where(p=>p.Discontinued==false).OrderByDescending(p=>p.CreatedDate).ThenByDescending(p=>p.ProductID).ToList();
            else       
                 products = db.Products.Where(p => p.Discontinued == false).OrderByDescending(p => p.CreatedDate).ThenByDescending(p => p.ProductID).Take(itemCount).ToList();
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult _ProductPhotoShow()
        {
            var products = db.Products.OrderByDescending(p => p.CreatedDate).ThenByDescending(p => p.ProductID).Take(10).ToList();

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