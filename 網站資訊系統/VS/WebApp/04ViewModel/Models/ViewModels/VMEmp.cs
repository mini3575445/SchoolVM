using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _04ViewModel.Models;


namespace _04ViewModel.Models.ViewModels
{
    public class VMEmp
    {
        //原本public string name { get; set; }
        public List<tDepartment> department { get; set; }
        public List<tEmployee> employee { get; set; }
    }
}