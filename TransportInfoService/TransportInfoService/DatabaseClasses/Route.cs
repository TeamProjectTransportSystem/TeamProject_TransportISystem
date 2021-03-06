﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("Routes")]
    public class Route
    {
        [Key]
        public string RouteName { get; set; }

        public virtual ICollection<Station> ListOfStations { get; set; }
        public virtual ICollection<Train> ListOfTrains { get; set; }

        public Route(string NewRouteName)
        {
            RouteName = NewRouteName;
            ListOfStations = new List<Station>();
            ListOfTrains = new List<Train>();
        }

        public Route()
        {

        }
    }
}
