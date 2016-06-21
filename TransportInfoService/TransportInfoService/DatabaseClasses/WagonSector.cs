using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("WagonSectors")]
    public class WagonSector
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WagonSectorID { get; set; }

        public int FirstNumberOfWagon { get; set; }
        public int LastNumberOfWagon { get; set; }

        public string WagonTypeName { get; set; }
        [ForeignKey("WagonTypeName")]
        public virtual WagonType Type { get; set; }

        public virtual ICollection<Train> TrainWhichUsesThisWagon { get; set; }

        public WagonSector(WagonType TypeOfWagon, int CurrentFirstNumberOfWagon, int CurrentLastNumberOfWagon)
        {
            Type = TypeOfWagon;
            FirstNumberOfWagon = CurrentFirstNumberOfWagon;
            LastNumberOfWagon = CurrentLastNumberOfWagon;
        }

        public WagonSector()
        {

        }
    }
}
