using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _04ViewModel.Models;
using _04ViewModel.Models.ViewModels;

namespace _04ViewModel.Controllers
{
    public class HomeController : Controller
    {
        dbEmployeeEntities db = new dbEmployeeEntities();
        // GET: Home
                                    //depId=1，預設值為1
        public ActionResult Index(int depId=1)
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
            ViewBag.dept= db.tDepartment.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(tEmployee emp)
        {
            db.tEmployee.Add(emp);
            db.SaveChanges();

            return RedirectToAction("Index", new { depId=emp.fDepId });
        }

        public ActionResult Delete(string id)
        {
            var emp = db.tEmployee.Where(m => m.fEmpId == id).FirstOrDefault();
            
            db.tEmployee.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index", new { depId = emp.fDepId});
        }
    }
}