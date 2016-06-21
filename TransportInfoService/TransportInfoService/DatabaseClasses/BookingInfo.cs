using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    public class BookingInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BookingInfoId { get; set; }
        public DateTime? DepartureDateTime { get; set; }
        public virtual Train CurrentTrain { get; set; }
        public virtual ICollection<WagonBookingInfo> ListOfWagonsBookingInfoForCurrentTrain { get; set; }

        public BookingInfo(DateTime DepartureDateTimeForBookingInfo, Train TrainForBookingInfo)
        {

        }

        public BookingInfo()
        {

        }
    }
}
