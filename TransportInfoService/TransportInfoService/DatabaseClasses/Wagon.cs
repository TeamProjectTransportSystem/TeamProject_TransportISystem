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

        public string WagonTypeName { get; set; }
        [ForeignKey("WagonTypeName")]
        public virtual WagonType Type { get; set; }

        public virtual ICollection<Train> TrainWhichUsesThisWagon { get; set; }

        //Номера занятых мест перечисленные в строке, через запятую
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

        public Wagon(WagonType TypeOfWagon)
        {
            Type = TypeOfWagon;
            OccupiedSeatsAsString = string.Empty;
        }

        public Wagon()
        {

        }
    }
}
