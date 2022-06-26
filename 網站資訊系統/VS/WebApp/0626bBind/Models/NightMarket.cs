using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _0626bBind.Models
{
    public class NightMarket
    {
        public string UId { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }

        public NightMarket() {
            UId = "";
            Pwd = "";
            Name = "";
        }
        public NightMarket(string _UId, string _Pwd, string _Name) {
            UId = _UId;
            Pwd = _Pwd;
            Name = _Name;
        }
    }
}