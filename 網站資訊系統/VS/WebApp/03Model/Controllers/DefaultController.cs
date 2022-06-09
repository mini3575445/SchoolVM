using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _03Model.Models;

namespace _03Model.Controllers
{
    public class DefaultController : Controller
    {
        dbSutdentEntities db = new dbSutdentEntities();
        // GET: Default
        public ActionResult Index()
        {
            var tStudent = db.tStudent.ToList();    //ToList轉成泛型
            return View(tStudent);
        }

        public ActionResult Create()
        {            
            return View();
        }


        //新增資料至資料庫
        [HttpPost]
             
        public ActionResult Create(tStudent s)
        {
            db.tStudent.Add(s);
            db.SaveChanges();//自己會判斷是新增、修改、刪除

            return RedirectToAction("Index");   //Redirect重新導向XXX
        }

        public ActionResult Delete(string id)
        {
            //SQL
            //delete from tStudent where fStuId=id

            var student = (from s in db.tStudent
                          where s.fStuId == id
                          select s).FirstOrDefault();

            //var student = db.tStudent.where(s => s.fStuId == id).FirstOrDefault();


            db.tStudent.Remove(student);
            db.SaveChanges();//自己會判斷是新增、修改、刪除

            return RedirectToAction("Index");   //Redirect重新導向XXX
        }

    }
}