using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _05HW1Controller : Controller
    {
       
        public void No1()
        {
            int a = 42;
            float b= 2.5f;

            Response.Write(a + "+" + b + "=" + (a + b) + "<br>");  //"42"+"+"+"2.5"   "42+2.5=42"-2.5
            Response.Write(a + "-" + b + "=" + (a - b) + "<br>");
            Response.Write(a + "*" + b + "=" + a * b + "<br>");
            Response.Write(a + "/" + b + "=" + a / b + "<br>");
            Response.Write(a + "%" + b + "=" + a % b);
        }


        public void No2(double c)
        {

            Response.Write(c * 9 / 5 + 32);
           
        }

        public void No3(int x, int y)
        {
           
            //x = x ^ y;
            //y = x ^ y;
            //x = x ^ y;
            
            
            x ^= y;
            y ^= y;
            x ^= y;

            Response.Write("x=" + x + ", y=" + y);

        }

        public void No4(int score)
        {
            int result = 0;
            result = score / 10;
            switch (result)
            {

            }
            

        }
    }
}