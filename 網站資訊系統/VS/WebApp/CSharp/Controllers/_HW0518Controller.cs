using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _HW0518Controller : Controller
    {
        public void HW1()
        {
            int a = 42;
            float b = 2.5f;
            Response.Write("a + b = "+(a+b) + "</br>");
            Response.Write("a - b = "+(a-b) + "</br>");
            Response.Write("a * b = "+(a * b) + "</br>");
            Response.Write("a / b = "+(a / b) + "</br>");
            Response.Write("a % b = "+(a % b) + "</br>");
        }
        public void HW2(float C)
        {
            float F = C * 9 / 5 + 32;
            Response.Write("F=" + F);
        }
        public void HW3(int x,int y)
        {
            x = x + y;
            y = x - y;
            x = x - y;
            Response.Write("x=" + x + " y=" + y);
        }
        public string HW4(int intScore)
        {
            
            switch (intScore)
            {
                case 90:
                    return "優等";
                case 80:
                    return "甲等";

            }
        return "輸入錯誤";
        }
    }
}