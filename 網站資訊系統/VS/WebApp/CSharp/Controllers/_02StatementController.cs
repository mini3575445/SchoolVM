using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _02StatementController : Controller
    {
        public void Statement()
        {
            int a = 10;
            a = 20;

            a = a + 10;
            a += 10;
            a -= 15; //a:25
            a *= 10; //a:250
            a /= 25; //a:10

            a = a + 1;
            a += 1;
            a++;  //a:13

            Response.Write(a);
            Response.Write("<hr>");
            /////////////////////////
            int x = 123;
            float y = 12.1234567f;
            float z = 12.134f;
            float result = 0;

            result = x + z;
            Response.Write("y=" + y);
            Response.Write("<br>");
            Response.Write("x+z=" + result);
            Response.Write("<hr>");

            float xx = 10000.9f;
            float yy = 9999.3f;
            Response.Write("xx+yy=" + (xx - yy));
            Response.Write("<hr>");

            //decimal t = (decimal)123.123;
            Response.Write("xx+yy=" + ((decimal)xx - (decimal)yy));
            Response.Write("<hr>");

        }

        //if敘述句
        public string IfStatement(int age)
        {

            //0-6歲免票, 7-20歲半票, 20歲以上全票

            if (age > 20)
            {
                return "全票";
            }
            else if (age > 6)
                return "半票";
            else if (age >= 0)
                return "免票";

            return "年齡輸入錯誤";


        }

        //switch敘述句
        public string SwitchStatement(string color)
        {

            switch (color)
            {
                case "黃":
                    return "黃色";
                case "綠":
                    return "綠色";
                case "紅":
                    return "紅色";

            }

            return "這不是黃綠紅";
        }
        //for敘述句
        public string ForStatement()
        {
            string[] arrRainbow = { "紅", "橙", "黃", "綠", "藍", "靛", "紫" }; //陣列

            string[] arrColor = { "red", "orange", "yellow", "green", "blue", "indigo", "violet" };

            string result = "";

            for (int i = 0; i < arrRainbow.Length; i++)
            {
                result += "<h2 style='color:" + arrColor[i] + "'>" + arrRainbow[i] + "</h2>";
            }

            return result;
        }

        //for each 敘述句 
        //通常用來讀取集合資料(陣列或物件)
        //拜訪每集合裡面的每一個元素
        public void ForeachStatement()
        {
            string[] arrRainbow = {"紅", "橙", "黃", "綠", "藍", "靛", "紫" }; //陣列
            foreach(string i in arrRainbow)
            {
                Response.Write(i);
            }
        }
        //While
        public void WhileStatement()
        {
            int i = 1;
            while (i <= 52)
            {
                Response.Write("<img src='../poker_img/"+i+".gif' />");
                i++;
            }
        }

        //DoWhile
        public void DoWhileStatement()
        {
            int i = 1;
            do
            {
                Response.Write("<img src='../poker_img/" + i + ".gif' />");
                i++;
            } while (i <= 52);
        }
    }
}