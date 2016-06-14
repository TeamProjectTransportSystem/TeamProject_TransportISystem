﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("Stations")]
    public class Station
    {
        public int StationID { get; set; }
        public string Name { get; set; }
        public int  Distance { get; set; }

        public virtual StationType Type { get; set; }
        public virtual ICollection<Route> Routes { get; set; }

        public Station()
        {

        }
    }
}