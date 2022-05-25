using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharp.Models;

namespace CSharp.Controllers
{
    public class _0525Controller : Controller
    {
       public void sss(int x)   
        {
            Class2 xxx = new Class2() { i =x};      //鑄造物件
            Response.Write(xxx.j());
        }

    }
}