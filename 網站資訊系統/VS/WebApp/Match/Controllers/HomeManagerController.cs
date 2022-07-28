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
        MatchEntities db = new MatchEntities();
        // GET: HomeManager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }


    }
}