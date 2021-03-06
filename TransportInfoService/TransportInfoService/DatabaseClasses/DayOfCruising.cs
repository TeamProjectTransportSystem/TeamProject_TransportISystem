﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("DaysOfCruising")]
    public class DayOfCruising
    {
        [Key]
        public string DayInfo { get; set; }

        public virtual ICollection<DepartureTimeAndDayOfCruising> DepartureTimeAndDayOfCruising { get; set; }

        public DayOfCruising(string NewDayInfo)
        {
            DayInfo = NewDayInfo;
        }

        public DayOfCruising()
        {

        }
    }
}
