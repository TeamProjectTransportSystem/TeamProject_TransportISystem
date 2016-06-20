using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("TrainTypes")]
    public class TrainType
    {
        [Key]
        public string TrainTypeName { get; set; }
        public int PriceForKilometer { get; set; }
        public int Speed { get; set; }

        public virtual ICollection<Train> Trains { get; set; }

        //ЧТО ЭТО???
        public virtual ICollection<StationType> AllowedTypesOfStations { get; set; }

        public TrainType(string NameOfType, int PriceForKilometerForThisType, int SpeedOfThisType)
        {
            TrainTypeName = NameOfType;
            PriceForKilometer = PriceForKilometerForThisType;
            Speed = SpeedOfThisType;
            Trains = new List<Train>();
            AllowedTypesOfStations = new List<StationType>();
        }

        public TrainType()
        {

        }
    }
}
