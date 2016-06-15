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

        public string NameOfSeatType { get; set; }
        [ForeignKey("NameOfSeatType")]
        public virtual SeatType TypeOfSeats { get; set; }

        public virtual ICollection<WagonType> WagonTypes { get; set; }

        public SeatSector(int NewNumberOfFirstSeat, int NewNumberOfLastSeat, SeatType TypeOfSeatsInSector)
        {
            NumberOfFirstSeat = NewNumberOfFirstSeat;
            NumberOfLastSeat = NewNumberOfLastSeat;
            TypeOfSeats = TypeOfSeatsInSector;
            WagonTypes = new List<WagonType>();
        }

        public SeatSector()
        {

        }
    }
}
