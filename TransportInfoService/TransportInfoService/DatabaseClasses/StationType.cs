using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("TypesOfStations")]
    public class StationType
    {
        [Key]
        public string StationTypeName { get; set; }

        public virtual ICollection<Station> ListOfStations { get; set; }
        public virtual ICollection<TrainType> AllowedTypesOfTrains { get; set; }

        public StationType(string TypeName)
        {
            StationTypeName = TypeName;
            ListOfStations = new List<Station>();
        }

        public StationType()
        {

        }
    }
}
