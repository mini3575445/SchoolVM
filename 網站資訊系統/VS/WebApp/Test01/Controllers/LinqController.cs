using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Test01.Models;



namespace Test01.Controllers
{
    public class LinqController : Controller
    {
        // GET: Linq
        public ActionResult Index()
        {                                    
            return View();
        }


        //從資料庫秀出員工資料
        NorthwindEntities db = new NorthwindEntities();
        public string ShowEmployee()
        {
            //string show = "";

            //var result = from n in db.員工
            //             select n;

            //foreach(var item in result)
            //{
            //    show += "員工編號:" + item.員工編號+"<br>";
            //    show += "姓名:" + item.姓名 + "<br>";
            //    show += "職稱:" + item.職稱 + "<hr>";

            //}
            string show = "";
            
            foreach(var item in db.員工)
            {
                show += "員工編號:" + item.員工編號 + "<br>";
                    show += "姓名:" + item.姓名 + "<br>";
                    show += "職稱:" + item.職稱 + "<hr>";

            }
            return show;
        }


        //get參數，找出客戶地址中含有keyword關鍵字的客戶記錄
        public string ShowCustomerByAddress(string keyword)
        {
            string show = "";

            var result = from c in db.客戶
                         where c.地址.Contains(keyword)
                         select c;
            //Contains(keyword):Like的函數
        
            foreach(var item in result)
            {
                show += "客戶編號:" + item.客戶編號 + "<br>";
                show += "公司名稱:" + item.公司名稱 + "<br>";
                show += "地址:" + item.地址 + "<hr>";
            }
            return show;
        }
        //顯示產品平均價、總合、筆數，最高價和最低價資訊
        public string ShowProductInfo()
        {
            string show = "";
            
            var result = from p in db.產品資料  //這個也是類似foreach的item
                         select p;
            //沒辦法在這裡做avg、加總等
                       
           
            show += "筆數:" + result.Count() + "<br>";
            show += "加總:" + result.Sum(p =>p.單價) + "<br>";
            show += "平均:" + result.Average(p => p.單價) + "<br>";
            show += "最高單價:" + result.Max(p => p.單價) + "<br>";
            show += "最小單價:" + result.Min(p => p.單價) + "<hr>";


            return show;
        }
        //result是整個資料表，p是每一筆資料
    }
}