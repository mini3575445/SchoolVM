using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _0622.Models
{
    public class Tclass
    {
        public int classID { get; set; }
        public string className { get; set; }

        public Tclass()
        {
            classID = 0;
            className = "";
        }
        public Tclass(int _classID, string _className){
            classID = _classID;
            className = _className;
        }       
        
    }
}