using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Match.Controllers
{
    [LoginCheck]
    public class MessageController : Controller
    {        
        public ActionResult AddMessage(string activityID, string text)
        {
            string sessionName = Session["member_name"].ToString();
            ActivityMessage activityMessage = new ActivityMessage();
            activityMessage.Write(activityID, sessionName, text);

            return RedirectToAction("Details", "UserActivity", new { id = activityID } );
        }
    }
}