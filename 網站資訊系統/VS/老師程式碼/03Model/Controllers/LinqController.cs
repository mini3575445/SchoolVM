using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//04-2-6 using _03EF.Model
using _03Model.Models;

namespace _03Model.Controllers
{
    public class LinqController : Controller
    {
        //04-2-7 於LinqController建立DB Context物件
        NorthwindEntities db = new NorthwindEntities();

        //04-2-8 建立一般方法ShowEmployee()-查詢所有員工記錄
        public string ShowEmployee()
        {

            //Linq
            //var result=from m in db.員工
            //           select m;

            var result = db.員工;

            //select * from 員工

            string show = "";


            foreach(var item in result)
            {
                show += "員工編號:" + item.員工編號 + "<br>";
                show += "員工姓名:" + item.姓名 + "<br>";
                show += "員工職稱:" + item.職稱 + "<hr>";
            }

            return show;
        }
    }
}