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
        [RightCheck]
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
            string pw = Member.getHashPassword(vMLogin.member_password);    //將登入的密碼Hash
            var user = db.Member.Where(m => m.member_account == vMLogin.member_account && m.member_password == pw).FirstOrDefault();
            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有錯!";
                return View(vMLogin);
            }
            if (user.right_id == "E")   //E為被封鎖會員
            {
                ViewBag.ErrMsg = "您的帳號已被封鎖!";
                return View(vMLogin);
            }          
            
            Session["user"] = user;
            Session["right"] = user.right_id;
            Session["member_id"] = user.member_id;
            Session["member_name"] = user.member_name;
            Session["member_photo_file"] = user.member_photo_file;
            return RedirectToAction("Index");
        }

        [LoginCheck]
        public ActionResult Logout()
        {

            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }


    }
}