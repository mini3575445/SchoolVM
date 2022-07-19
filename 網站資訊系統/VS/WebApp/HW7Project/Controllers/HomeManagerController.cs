using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW7Project.Models;

namespace HW7Project.Controllers
{   
    
    public class HomeManagerController : Controller
    {
        HW7ProjectContext db = new HW7ProjectContext();
        // GET: HomeManager
        //***
        [LoginCheck]
        public ActionResult Index()
        {
            //if (Session["user"] == null)
            //{ return RedirectToAction("Index", "Home"); }    
            //return View();
            //這樣子寫需要每一個Action都要檢查
            //比較好的方法是:在Controller建立LoginCheck的類別
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            //select * from Employee where account and password=@password
            var user = db.Employees.Where(m => m.Account == vMLogin.Account && m.Password == vMLogin.Password).FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有錯!!";
                return View(vMLogin);
            }

            Session["user"] = user;
            return RedirectToAction("Index");
        }

        [LoginCheck]
        public ActionResult Logout()
        {
            Session["user"] = null;
            //登出後回到前台首頁(HOME)
            return RedirectToAction("Index","Home");
        }
    }
}