﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    [Table("TypesOfWagons")]
    public class WagonType
    {
        [Key]
        public string WagonName { get; set; }
        public int PriceForKilometer { get; set; }
        public bool HasUpperSeats { get; set; }
        public virtual ICollection<SeatSector> SeatSectors { get; set; }

        public WagonType(string NameOfType, int PriceForKilometerForThisType, bool IsThisWagonTypeHasUpperSeats)
        {
            WagonName = NameOfType;
            PriceForKilometer = PriceForKilometerForThisType;
            HasUpperSeats = IsThisWagonTypeHasUpperSeats;
            SeatSectors = new List<SeatSector>();
        }

        public WagonType()
        {

        }
    }
}
