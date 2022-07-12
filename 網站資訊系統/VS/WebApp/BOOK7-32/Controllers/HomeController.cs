using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BOOK7_32.Models;

namespace BOOK7_32.Controllers
{
    public class HomeController : Controller
    {

        dbEmployeeEntities db = new dbEmployeeEntities();
        // GET: Home
        public ActionResult Index()
        {
            var result = db.tEmployee;
            return View(result);
        }
        public ActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Create(tEmployee employee)
        {
            if (ModelState.IsValid) 
            {
                ViewBag.Error = false;
                var temp = db.tEmployee.Where(m => m.fEmpId == employee.fEmpId).FirstOrDefault();
                if (temp != null)
                {
                    ViewBag.Error = true;
                    return View(employee);
                }
                db.tEmployee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(string fEmpId) 
        {
            var employee = db.tEmployee.Where(m => m.fEmpId == fEmpId).FirstOrDefault();
            db.tEmployee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}