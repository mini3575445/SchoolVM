using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06WebAPI.Models
{

    public class TRAStation
    {
        public string StationID { get; set; }
        public Stationname StationName { get; set; }
        public string TrainNo { get; set; }
        public int Direction { get; set; }
        public string TrainTypeID { get; set; }
        public string TrainTypeCode { get; set; }
        public Traintypename TrainTypeName { get; set; }
    }

    public class Stationname
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

    public class Traintypename
    {
        public string Zh_tw { get; set; }
        public string En { get; set; }
    }

}