using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public String Index()
        {
            String result="";
            List<int> list = new List<int>();
            list.Add(555);
            list.Add(222);
            list.Add(333);
            list.Add(444);
            list.Add(111);

            list.Remove(111);
            list.RemoveAt(2);

            list.Sort();

            for (var i = 0; i < list.Count; i++) 
            {
                result += "第" + i + "個:" + list[i].ToString() + "<br>";
            }
            result += list.Contains(222);   //找list裡面有沒有222
            
            return result;
        }
    }
}