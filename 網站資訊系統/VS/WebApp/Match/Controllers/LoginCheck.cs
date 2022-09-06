using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Match.Controllers
{
    public class LoginCheck : ActionFilterAttribute
    {
        void LoginState(HttpContext context)//傳入HttpContext context這樣才能用Session
        {
            if (context.Session["user"] == null)
            {
                context.Response.Redirect("/HomeManager/Login");
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            LoginState(context);
        }
        //再ACTION被執行時就使用FILTER


    }
}