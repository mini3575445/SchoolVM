using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03Model.Models;

namespace _03Model.Controllers
{ 
public class LinQController : Controller
{

    //於LinQController建立DB Context物件
    NorthwindEntities db = new NorthwindEntities();
    public string ShowEmployee()
    {
        //LinQ
        var result = from m in db.員工
                     select m;
        //箭頭函數
        //var result = db.員工;



        string show = "";
        foreach (var item in result)
        {
            show += "員工編號:" + item.員工編號 + "<br>";
            show += "員工姓名:" + item.姓名 + "<br>";
            show += "員工職稱:" + item.職稱 + "<hr>";
        }


        return show;
    }
    }
}