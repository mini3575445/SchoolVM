using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using test2.Models;
using test2.ViewModels;



namespace test2.Controllers
{
    public class HomeController : Controller
    {
        //06-2-4 於HomeController建立DB物件
        dbEmployeeEntities1 db = new dbEmployeeEntities1();

        //06-2-5 編輯ActionResult Index()的內容
        public ActionResult Index(int depId = 1)
        {
            VMEmp vme = new VMEmp()
            {
                department = db.tDepartment.ToList(),
                employee = db.tEmployee.Where(m => m.fDepId == depId).ToList()
            };

            ViewBag.deptName = db.tDepartment.Where(m => m.fDepId == depId).FirstOrDefault().fDepName;


            return View(vme);
        }


        public ActionResult Create()
        {
            ViewBag.dept = db.tDepartment.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(tEmployee emp)
        {
            db.tEmployee.Add(emp);
            db.SaveChanges();

            return RedirectToAction("Index", new { depId = emp.fDepId });
        }
    }
}