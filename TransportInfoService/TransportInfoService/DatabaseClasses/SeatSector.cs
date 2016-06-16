using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("SeatSectorsForWagonTypes")]
    public class SeatSector
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatSectorID { get; set; }
        public int NumberOfFirstSeat { get; set; }
        public int NumberOfLastSeat { get; set; }
        //Являются ли места боковыми (имеет смысл для плацкартных вагонов)
        public bool IsSide { get; set; }

        public virtual ICollection<WagonType> WagonTypes { get; set; }

        public SeatSector(int NewNumberOfFirstSeat, int NewNumberOfLastSeat, bool IsThisSectorSide)
        {
            NumberOfFirstSeat = NewNumberOfFirstSeat;
            NumberOfLastSeat = NewNumberOfLastSeat;
            WagonTypes = new List<WagonType>();
            IsSide = IsThisSectorSide;
        }

        public SeatSector()
        {

        }
    }
}
