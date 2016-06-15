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
            StationType station = new StationType("Станция");
            StationType op = new StationType("ОП");
            Station minsk_pass = new Station("Минск-Пассажирский", 0, station);
            Station minsk_ost = new Station("Минск-Восточный", 3, station);
            Station tractor = new Station("Тракторный", 6, op);
            Station stepyanka = new Station("Степянка", 9, station);
            Station ozerische = new Station("Озерище", 13, station);
            Station kolodischy = new Station("Колодищи", 17, station);
            Station sadovy = new Station("Садовый", 21, op);
            Station gorodische = new Station("Городище", 24, station);
            Route routeMinskBorisov = new Route("Минск-Борисов");
            routeMinskBorisov.ListOfStations.Add(minsk_pass);
            routeMinskBorisov.ListOfStations.Add(minsk_ost);
            routeMinskBorisov.ListOfStations.Add(tractor);
            routeMinskBorisov.ListOfStations.Add(stepyanka);
            routeMinskBorisov.ListOfStations.Add(ozerische);
            routeMinskBorisov.ListOfStations.Add(kolodischy);
            routeMinskBorisov.ListOfStations.Add(sadovy);
            routeMinskBorisov.ListOfStations.Add(gorodische);
            Train train1 = new Train("061b", new TrainType("Эконом-Класс", 700, 60), routeMinskBorisov);
            train1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(18, 30, true, new DayOfCruising("ежедневно")));
            routeMinskBorisov.ListOfTrains.Add(train1);
            context.ListOfRoutes.Add(routeMinskBorisov);
            //context.ListOfStationTypes.Add(new StationType() { Name = "FirstType" });
            //context.ListOfStationTypes.Add(new StationType() { Name = "SecondType" });
            //context.ListOfStationTypes.Add(new StationType() { Name = "ThirdType" });
            //Test of adding new element with foreign key
            //context.ListOfSeatSectors.Add(new SeatSector() {  NumberOfFirstSeat = 10, NumberOfLastSeat = 50,  TypeOfSeats = new SeatType() { CanBeUpper = false, Name = "FirstSeatType", PriceForKilometer = 20 } });
            base.Seed(context);
        }
    }
}
