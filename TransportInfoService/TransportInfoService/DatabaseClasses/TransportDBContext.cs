using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    public class TransportDBContext : DbContext
    {
        public DbSet<Station> ListOfStations { get; set; }
        public DbSet<Train> ListOfTrains { get; set; }
        public DbSet<Route> ListOfRoutes { get; set; }
        public DbSet<TrainType> ListOfTrainTypes { get; set; }
        public DbSet<StationType> ListOfStationTypes { get; set; }
        public DbSet<DayOfCruising> DaysOfCruising { get; set; }
        public DbSet<DepartureTimeAndDayOfCruising> DepartueTimesAndDaysOfCrusing { get; set; }
        public DbSet<Wagon> ListOfWagons { get; set; }
        public DbSet<WagonType> ListOfWagonTypes { get; set; }
        public DbSet<SeatSector> ListOfSeatSectors { get; set; }

        public TransportDBContext(string ConnectionStringName) : base(ConnectionStringName)
        {
            Database.SetInitializer<TransportDBContext>(new TransportDBseeder());
        }
    }
}
