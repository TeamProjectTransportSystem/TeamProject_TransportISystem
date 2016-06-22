using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("Trains")]
    public class Train
    {
        [Key]
        public string TrainIDAsString { get; set; }

        public virtual TrainType Type { get; set; }
        public virtual ICollection<DepartureTimeAndDayOfCruising> ListOfDepartureTimeAndDaysOfCruising { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<Wagon> Wagons { get; set; }
        public virtual ICollection<BookingInfo> ListOfRelatedToThisTrainBookingInfo { get; set; }

        public Train(string TrainID, TrainType TypeOfTrain, Route RouteOfTrain)
        {
            TrainIDAsString = TrainID;
            Type = TypeOfTrain;
            Route = RouteOfTrain;
            ListOfDepartureTimeAndDaysOfCruising = new List<DepartureTimeAndDayOfCruising>();
            Wagons = new List<Wagon>();
        }

        public Train()
        {

        }
    }
}
