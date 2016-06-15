using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    public class TransportDBseeder : CreateDatabaseIfNotExists<TransportDBContext>
    {
        protected override void Seed(TransportDBContext context)
        {
            context.ListOfStationTypes.Add(new StationType() { Name = "FirstType" });
            context.ListOfStationTypes.Add(new StationType() { Name = "SecondType" });
            context.ListOfStationTypes.Add(new StationType() { Name = "ThirdType" });

            //Test of adding new element with foreign key
            context.ListOfSeatSectors.Add(new SeatSector() {  NumberOfFirstSeat = 10, NumberOfLastSeat = 50,  TypeOfSeats = new SeatType() { CanBeUpper = false, Name = "FirstSeatType", PriceForKilometer = 20 } });

            base.Seed(context);
        }
    }
}
