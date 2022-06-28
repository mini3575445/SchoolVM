using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _0626bBind.Models;
namespace _0626bBind.Controllers
{
    public class HomeController : Controller
    {
        // 沒有連DB，只連Model
        public ActionResult Index()
        {
            List<NightMarket> list = new List<NightMarket>(4);

            NightMarket nightMarket = new NightMarket("A01","123","安安");
            NightMarket nightMarket2 = new NightMarket("A01", "123", "安安");

            list.Add(nightMarket);
            list.Add(nightMarket2);

            //Q1為甚麼能夠傳送list?
            return View(list);
        }
        //LinQ練習
        public string ShowAryDesc() {

            int[] score = { 78, 90, 20, 100, 66 };
            string show = "";

            //查詢運算式(Query Expression)
            //這個result是什麼物件?
            var result = from s in score
                         select s;
            foreach (var item in result)
            show += item+",";
            return show;
        }





        //連接DB並能在前端新增資料
        public ActionResult Create() {

            

            return View();

        }
    }
}