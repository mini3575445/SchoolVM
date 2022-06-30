using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _0630Model.Models;

namespace _0630Model.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string ShowAryDesc()
        {
            int[] score = { 78, 90, 20, 100, 66 };
            string show = "";

            var result = from s in score
                         orderby s descending
                         select s;


            foreach (var item in result)
            {
                show += item + ",";
            }
            return show;
        }

        public string ShowAryAsc() {
            int[] score = { 78, 90, 20, 100, 66 };
            string show = "";

            var result = from s in score
                         orderby s
                         select s;


            foreach (var item in result)
            {
                show += item+",";
            }
        return show;
        }


        //登入會員，直接使用Controller輸入帳密
        public string LoginMember(string _UId, string _Pwd) 
        {
            string show = "";
            Member[] members = 
            { 
                new Member { UId = "123", Pwd = "123", Name = "湯姆"},
                new Member { UId = "456", Pwd = "456", Name = "母湯"},
                new Member { UId = "789", Pwd = "789", Name = "哈哈"}
            };

            var result = (from m in members
                          where m.UId == _UId && m.Pwd == _Pwd
                          select m).FirstOrDefault();

            if (result == null) { show = "你不要來亂"; }
            else { show = "你好" + result.Name; }

            return show;
        }



    }
}