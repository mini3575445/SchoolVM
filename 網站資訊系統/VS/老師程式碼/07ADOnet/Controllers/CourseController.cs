using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _07ADOnet.Models;
using System.Data.SqlClient;
namespace _07ADOnet.Controllers
{
    public class CourseController : Controller
    {
        SetData sd = new SetData();
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string cid, string cname,int credit)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("cid", cid),
                new SqlParameter("cname", cname),
                new SqlParameter("credit", credit)
            };

            string sql = "insert into 課程 values(@cid,@cname,@credit)";

            sd.executeSql(sql,list);

            return View();
        }
    }
}