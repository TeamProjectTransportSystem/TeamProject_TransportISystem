using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("TypesOfSeat")]
    public class SeatType
    {
        [Key]
        public string Name { get; set; }
        public bool CanBeUpper { get; set; }
        public int PriceForKilometer { get; set; }

        public SeatType()
        {

        }
    }
}
