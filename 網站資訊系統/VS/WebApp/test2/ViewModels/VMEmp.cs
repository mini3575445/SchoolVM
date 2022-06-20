using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using test2.Models;

namespace test2.ViewModels
{
    public class VMEmp
    {
        public List<tDepartment> department { get; set; }
        public List<tEmployee> employee { get; set; }
    }
}