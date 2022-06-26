using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using _0626bBind.Models;
namespace _0626bBind.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<NightMarket> list = new List<NightMarket>(4);

            NightMarket nightMarket = new NightMarket("A01","123","安安");
            NightMarket nightMarket2 = new NightMarket("A01", "123", "安安");

            list.Add(nightMarket);
            list.Add(nightMarket2);

            //Q1為甚麼能夠傳送list?
            return View(list);
        }
    }
}