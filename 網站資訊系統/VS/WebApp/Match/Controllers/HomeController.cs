using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Match.Controllers;
using Match.Models;
using Match.ViewModels;

namespace Match.Controllers
{
    public class HomeController : Controller
    {
        private MatchEntities db = new MatchEntities();

        // GET: Home
        public ActionResult Index()
        {
            VMActivity vmActivity = new VMActivity();
            vmActivity.activity = db.Activity.OrderByDescending(a => a.activity_create_date).ToList();

            return View(vmActivity);
        }
    }
}