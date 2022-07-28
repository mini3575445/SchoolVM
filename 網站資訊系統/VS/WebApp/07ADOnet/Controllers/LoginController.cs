using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _07ADOnet.Models;
namespace _07ADOnet.Controllers
{
    public class LoginController : Controller
    {
        GetData gd = new GetData();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string id ,string name)
        {
            //select * from 學生 where 學號 = 'S001' and 姓名 = '陳小安'
            //  string sql = "select * from 學生 where 學號 = '"+id+"' and 姓名 = '"+name+"'";
            //  ***避免資料隱碼攻擊，SQL的字串不可以跟C#的變數、物件串在一起!!!

            //比較安全的寫法是把變數丟到SQL執行，使用sqlParameters
            string sql = "select * from 學生 where 學號 =@id and 姓名 =@name ";
            var dt = gd.querySql(sql, System.Data.CommandType.Text,id,name);

            if (dt.Rows.Count == 0)
            {
                ViewBag.Msg = "帳號或密碼有誤!";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}