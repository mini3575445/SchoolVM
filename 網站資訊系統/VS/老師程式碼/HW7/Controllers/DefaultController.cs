using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW7Project.Models;

namespace HW7Project.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            Members members = new Members();

            members.Password = "12345678";

            return View();
        }
    }
}