using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("WagonBookingInfo")]
    public class WagonBookingInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long WagonBookingInfoId { get; set; }
        public virtual BookingInfo RelatedBookingInfo { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OccupiedSeatsAsString { get; set; }

        [NotMapped]
        public IEnumerable<int> OccupiedSeats
        {
            get
            {
                string[] ListOfOccupiedSeatsNumbersAsString = this.OccupiedSeatsAsString.Split(',');
                List<int> ListOfOccupiedSeats = new List<int>();
                foreach (string NumberOfSeat in ListOfOccupiedSeatsNumbersAsString)
                {
                    ListOfOccupiedSeats.Add(Int32.Parse(NumberOfSeat));
                }
                return ListOfOccupiedSeats;
            }
            set
            {
                StringBuilder BuilderForOccupiedSeatsAsString = new StringBuilder();
                foreach (int NumberOfSeat in value)
                {
                    BuilderForOccupiedSeatsAsString.Append(NumberOfSeat.ToString() + ",");
                }
                this.OccupiedSeatsAsString = BuilderForOccupiedSeatsAsString.ToString();
            }
        }

        public WagonBookingInfo(List<int> NumbersOfOccupiedSeats)
        {
            OccupiedSeats = NumbersOfOccupiedSeats;
        }

        public WagonBookingInfo()
        {

        }
    }
}
