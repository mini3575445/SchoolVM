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

        dbSutdentEntities db = new dbSutdentEntities();


        public ActionResult Index()
        {
            var tStudent = db.tStudent.ToList();

            return View(tStudent);
        }
    }
}