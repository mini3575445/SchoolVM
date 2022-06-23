using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//04-3-8 using _03Model.Models
using _03Model.Models;


namespace _03Model.Controllers
{
    public class DefaultController : Controller
    {
        //04-3-9 於DefualtController建立DB物件,並撰寫Index、Create、Delete的Action
        dbSutdentEntities db = new dbSutdentEntities();

        //04-4-1 建立HttpPost Create() Action
        public ActionResult Index()
        {
            var tStudent = db.tStudent.ToList();

            return View(tStudent);
        }

        public ActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Create(tStudent s)
        {

            db.tStudent.Add(s);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        //04-4-3 建立Delete() Action
        public ActionResult Delete(string id)
        {
            //SQL
            //delete from tStudent where fStuId=id

            //Linq
            //var student = from s in db.tStudent
            //              where s.fStuId==id
            //              select s;

            var student = db.tStudent.Where(s => s.fStuId == id).FirstOrDefault();

            db.tStudent.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}