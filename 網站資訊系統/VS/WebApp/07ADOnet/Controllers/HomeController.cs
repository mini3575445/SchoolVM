using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _07ADOnet.Models;


//using _07ADOnet.Models;


namespace _07ADOnet.Controllers
{
    public class HomeController : Controller
    {
        //這是使用Entities
        //教務系統Entities db = new 教務系統Entities();

        //結論:Connection不應該寫在controller


        GetData gd = new GetData();
        // GET: Home
        public ActionResult Index()
        {          
            //怎麼把dt丟到View?
            //1.使用ViewBag
            //ViewBag.DataSource = dt;
            //2.直接return到View
            return View(gd.querySql("select * from 學生", CommandType.Text));
        }

        public ActionResult GetEmployee()
        {
           
            return View(gd.querySql("select * from 員工", CommandType.Text, "employee"));
        }

        //怎麼在C#呼叫預存程序
        //寫在getData
        public ActionResult GetCoursePivot()
        {
            var result = gd.querySql("getCoursePivot", CommandType.StoredProcedure);
            return View(result);
        }

    }
}