using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class Class2     //定義物件模板
    {
        public int i { get; set; }      //物件屬性i
        public int j() { return i * i; }    //物件方法j()
    }
}