using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _001controller.Controllers
{
    public class HomeController : Controller
    {
        //修飾詞:public公開的 protected受保護的 private私有的
        public string ShowAry()
        {
            int[] score = { 78, 90, 20, 100, 66 };
            int sum = 0;
            string show = "";
            
            foreach (int s in score)
            {
                sum += s;
                show += s + " , ";
                
            }
            show += "成績總和為" + sum;
            return show;
        }


        public string ShowImages()
        {
            string show = "";
            for (int i=1;i<=8;i++)
            {
                show += "<a href=ShowImagesIndex?n="+i+"><img src='../images/" + i + ".JPG'></a>";                
            }
            return show;
        }
        //public string ShowImagesIndex(int n)
        //{
        //    string[] name = { "11111", "22222", "33333", "444444444", "555555555", "666666", "777777", "888888888" };
        //    string show = "";
        //    //一般寫法
        //    //show += "<img src='../images/" + n + ".JPG'><h2></h2>";

        //    //字串格式化
        //    show = string.Format("<img src = '../images/{0}.JPG'><h2>{1}</h2 >",n,name[n-1]);
        //    show += "<br><a href='ShowImages'>回菜單</a>";
        //    return show;
        //}
    }



}