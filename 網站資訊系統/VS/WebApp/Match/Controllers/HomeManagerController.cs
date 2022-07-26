using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Match.Models;

namespace Match.Controllers
{
    public class HomeManagerController : Controller
    {
        // GET: HomeManager
        public ActionResult Index()
        {
            return View();
        }
    }
}