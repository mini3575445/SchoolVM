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
        public string HW4(int score)
        {
            int fristNum = score / 10;
                switch (fristNum)
            {
                case 9: return "優等";
                case 8: return "甲等";
                case 7: return "乙等";
                case 6: return "丙等";
            }            
        return "丁等";
        }
        public void HW5(int N)  
        {
            for (int i = 1; i <= N; i++)
            {
                if (i % 5 != 0)
                {
                    Response.Write(i);
                    Response.Write(",");
                }
            }            
        }        
        public void HW6(int N)
        {
            int sum = 0;
            for (int i = 1; i <= N; i++)
            {
                if (i % 3 != 0)
                {
                    sum += i;
                }
            }
            Response.Write(sum);
        }
        public void HW7(int n)
        {
            string j = "";
            int i = 1;            
            while (i<= n){
                j += "*";
                Response.Write(j);
                Response.Write("<br>");
                i++;
            }
        }    
        public void HW8(int n,int m)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j =1; j<=n;j++)
                {
                    Response.Write(i+"*"+j+ "=" + i*j+"<br>");
                }
                Response.Write("<br>");
            }
        }
    }
}