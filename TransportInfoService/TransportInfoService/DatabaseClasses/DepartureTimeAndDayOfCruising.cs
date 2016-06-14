using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("DepartureTimeAndDayOfCruising")]
    public class DepartureTimeAndDayOfCruising
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartureTimeAndDayOfCruisingID { get; set; }
        public Byte? FirstRouteStationDepartureHours { get; set; }
        public Byte? FirstRouteStationDepartureMinutes { get; set; }
        public Byte? LastRouteStationDepartureHours { get; set; }
        public Byte? LastRouteStationDepartureMinutes { get; set; }

        public virtual DayOfCruising DayOfCruisingInfo { get; set; }

        public DepartureTimeAndDayOfCruising()
        {

        }
    }
}
