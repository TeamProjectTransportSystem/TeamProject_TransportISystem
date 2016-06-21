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
        public Byte DepartureHours { get; set; }
        public Byte DepartureMinutes { get; set; }
        public bool IsFirstStationStart { get; set; }
        public virtual ICollection<DayOfCruising> DayOfCruisingInfo { get; set; }

        public DepartureTimeAndDayOfCruising(Byte NewDepartureHours, Byte NewDepartureMinutes, bool ThisIsFirstStationStart,  List<DayOfCruising> NewDayOfCruising)
        {
            DepartureHours = NewDepartureHours;
            DepartureMinutes = NewDepartureMinutes;
            IsFirstStationStart = ThisIsFirstStationStart;
            DayOfCruisingInfo = NewDayOfCruising;
        }

        public DepartureTimeAndDayOfCruising()
        {

        }
    }
}
