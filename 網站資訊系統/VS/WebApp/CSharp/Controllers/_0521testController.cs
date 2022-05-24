using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class _0521testController : Controller
    {
        [HttpGet]

        
        [ActionName("test01")]
        public string ShowAry()
        {
            int[] score = new int[] { 1, 2, 3, 4, 5, };
            string show = "";
            int sum = 0;
            foreach (int scoreItem in score)
            {
                show += scoreItem+",";
                sum += scoreItem; 
            }
            
            return show;
        }
        
    }
}