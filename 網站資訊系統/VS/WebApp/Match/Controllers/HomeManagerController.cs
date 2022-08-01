using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Match.Models;

namespace Match.Controllers
{
    public class HomeManagerController : Controller
    {
        MatchEntities db = new MatchEntities();
        // GET: HomeManager
        [LoginCheck]
        public ActionResult Index()
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
            var user = db.Member.Where(m => m.member_account == vMLogin.member_account && m.member_password == vMLogin.member_password).FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有錯!";
                return View(vMLogin);
            }

            Session["user"] = user;
            return RedirectToAction("Index");
        }


    }
}