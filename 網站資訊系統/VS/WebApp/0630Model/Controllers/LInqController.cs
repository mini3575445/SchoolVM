using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//1.引入Models
using _0630Model.Models;

namespace _0630Model.Controllers
{
    public class LInqController : Controller
    {
        // GET: LInq
        public ActionResult Index()
        {
            return View();
        }

        //2.建立DB Context物件，於新增ADO時創建
        NorthwindEntities db = new NorthwindEntities();

        public string ShowEmployee() 
        {
            string show = "";

            var result = from e in db.員工
                         select e;

            foreach (var item in result) 
            {
                show += "員工編號：" + item.員工編號 + "<br>";
                show += "姓名：" + item.姓名 + "<br>";
                show += "雇用日期：" + item.雇用日期 + "<br>";
            }

            return show;
        }
    }

   
}