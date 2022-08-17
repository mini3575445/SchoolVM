using Match.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Match.ViewModels
{
    public class VMPlace
    {
        public List<Place> place{ get; set; }
        public List<Place_off_day> place_off_day { get; set; }
        public List<Place_type> place_type { get; set; }
    }
}