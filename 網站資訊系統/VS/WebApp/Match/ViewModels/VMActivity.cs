using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Match.Models;

namespace Match.ViewModels
{
    public class VMActivity
    {
        public List<Activity> activity { get; set; }
        public List<Activity_detail> activity_detail { get; set; }
        
    }
}