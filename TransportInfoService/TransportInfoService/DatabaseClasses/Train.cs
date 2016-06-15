using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("Trains")]
    public class Train
    {
        public string TrainID { get; set; }

        public virtual TrainType Type { get; set; }
        public virtual ICollection<DepartureTimeAndDayOfCruising> ListOfDepartureTimeAndDaysOfCruising { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Wagon> Wagons { get; set; }

        public Train()
        {

        }
    }
}
