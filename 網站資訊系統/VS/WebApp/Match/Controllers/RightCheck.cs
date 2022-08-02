using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Match.Controllers
{
    public class RightCheck : ActionFilterAttribute
    {
        void LoginState(HttpContext context)//傳入HttpContext context這樣才能用Session
        {
            if (context.Session["user"] == null || "CDE".Contains(context.Session["right"].ToString()))  //Contains找是否含有字串
            {                                       //是CDE的話則跳到首頁
               
                context.Response.Redirect("/Home/Index");
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