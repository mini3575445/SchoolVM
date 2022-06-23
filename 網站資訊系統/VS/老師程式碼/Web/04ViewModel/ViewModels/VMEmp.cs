using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//06-1-6 在VMEmp.cs裡 using _04ViewModel.Models
using _04ViewModel.Models;

namespace _04ViewModel.ViewModels
{
    public class VMEmp
    {
        //06-1-7 建立tDepartment和tEmployee的List物件做為屬性
        public List<tDepartment> department { get; set; }
        public List<tEmployee> employee { get; set; }
    }
}