using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("Wagons")]
    public class Wagon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WagonID { get; set; }
        public int NumberOfThisWagon { get; set; }
        public string WagonTypeName { get; set; }
        [ForeignKey("WagonTypeName")]
        public virtual WagonType Type { get; set; }

        public virtual ICollection<Train> TrainWhichUsesThisWagon { get; set; }

        public Wagon(WagonType TypeOfWagon, int NewNumberOfThisWagon)
        {
            Type = TypeOfWagon;
            NumberOfThisWagon = NewNumberOfThisWagon;
        }

        public Wagon()
        {

        }
    }
}
