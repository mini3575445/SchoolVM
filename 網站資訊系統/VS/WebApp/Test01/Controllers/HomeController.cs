using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Test01.Models;

namespace Test01.Controllers
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
            int[] score = { 58, 79, 14, 100, 65 };
            string show = "";
            var result = from s in score
                         orderby s descending
                         select s;
            //擴充
            //var result = score.OrderByDescending(s => s);
            foreach (var item in result)
            {
                show += item + ",";
            }
            return show;
        }


        public string ShowAryAsc()
        {
            int[] score = { 58, 79, 14, 100, 65 };
            string show = "";
            var result = from s in score
                         orderby s
                         select s;

            foreach (var item in result)
            {
                show += item + ",";
            }
            return show;
        }

        public string LoginMember(string uid,string pwd)
        {   
            

            string show = "";

            //純class
            //Member member = new Member() { UId = "A01", Pwd = "123", Name = "安安" };
            
            //class陣列(裡面放member資料型態)
            Member[] members = new Member[3]
            {
            new Member(){ UId="A01",Pwd="123",Name="安安"},
            new Member(){ UId="A02",Pwd="456",Name="咪路"},
            new Member(){ UId="A03",Pwd="789",Name="爆米香"}
            };
            
            var result = (from m in members
                         where m.UId == uid && m.Pwd == pwd
                         select m).FirstOrDefault();

            if (result != null)
                show = "歡迎" + result.Name + "登入";
            else
            {
                show = "帳號密碼輸入錯誤";
            }                      
        return show;
        }
    }
}