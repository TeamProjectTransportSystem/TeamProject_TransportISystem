using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportInfoService.Resources;
using TransportInfoService.TransportSystemLogicClasses;

namespace TransportInfoService.DatabaseClasses
{
    public static class TransportDBWorker
    {
        public static List<TrainWithDaysOfCruising> GetListOfTrainsInfoWithOutDate(string firstStation, string secondStation)
        {
            string trainFullName, departureTime, arrivalTime, travelTime, daysOfCruising = null;
            List<TrainWithDaysOfCruising> listOfTrains = new List<TrainWithDaysOfCruising>();
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
            {
                Station currentFirstStation = null, currentSecondStation = null;
                foreach (Station s in CurrentDBContext.ListOfStations)
                {
                    if (s.Name == firstStation)
                        currentFirstStation = s;
                    if (s.Name == secondStation)
                        currentSecondStation = s;
                }


                List<Route> routes = new List<Route>();
                if (currentFirstStation.Distance > currentSecondStation.Distance)
                    routes = currentFirstStation.Routes.ToList();
                else
                    routes = currentSecondStation.Routes.ToList();

                foreach (Route r in routes)
                {
                    foreach (Train t in r.ListOfTrains)
                    {
                        if (currentFirstStation.Distance > currentSecondStation.Distance)
                        {
                            r.RouteName = ReturnNewRoute(r.RouteName);
                            currentSecondStation.Distance = r.ListOfStations.ToList()[r.ListOfStations.Count - 1].Distance +
                                                           (r.ListOfStations.ToList()[r.ListOfStations.Count - 1].Distance -
                                                            currentSecondStation.Distance);
                            foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                                d.DepartureMinutes += 20;
                        }

                        //полное имя поезда
                        trainFullName = String.Format("{0} {1} {2}", t.TrainIDAsString, t.Type.TrainTypeName, r.RouteName);

                        //скорость поезда
                        int speedTrain = t.Type.Speed;

                        foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                        {

                            //время отправления поезда
                            TimeSpan startTime = new TimeSpan(d.DepartureHours, d.DepartureMinutes, 0);

                            double firstTimeAsDouble = (double)currentFirstStation.Distance / (double)speedTrain;
                            int firstTimeHour = (int)firstTimeAsDouble;
                            int firstTimeMinute = (int)((firstTimeAsDouble - (double)firstTimeHour) * 60);

                            TimeSpan currentFirstTime = startTime.Add(new TimeSpan(firstTimeHour, firstTimeMinute, 0));
                            //время прибытия на первую выбранную станцию
                            departureTime = String.Format("{0:hh\\:mm}", currentFirstTime);
                            TimeSpan timeOfFirstStation = new TimeSpan(firstTimeHour, firstTimeMinute, 0);

                            double secondTimeAsDouble = (double)currentSecondStation.Distance / (double)speedTrain;
                            int secondTimeHour = (int)secondTimeAsDouble;
                            int secondTimeMinute = (int)((secondTimeAsDouble - (double)secondTimeHour) * 60);

                            TimeSpan currentSecondTime = startTime.Add(new TimeSpan(secondTimeHour, secondTimeMinute, 0));
                            //время прибытия на конечную выбранную станцию
                            arrivalTime = String.Format("{0:hh\\:mm}", currentSecondTime);
                            TimeSpan timeOfSecondStation = new TimeSpan(secondTimeHour, secondTimeMinute, 0);

                            //время в пути
                            TimeSpan travelTimeAsTimeSpan = timeOfSecondStation.Subtract(timeOfFirstStation);
                            travelTime = String.Format("{0:hh\\:mm}", travelTimeAsTimeSpan);

                            //дни курсирования(если вбивать как массив, то они должны содержать в расписании как массив!!!)
                            //daysOfCruising = d.DayOfCruisingInfo.DayInfo;
                            foreach (DayOfCruising day in d.DayOfCruisingInfo)
                                daysOfCruising += String.Format("{0}\n", day.DayInfo);

                            TrainWithDaysOfCruising trainCruising =
                                    new TrainWithDaysOfCruising(trainFullName, departureTime, arrivalTime, travelTime, daysOfCruising);

                            listOfTrains.Add(trainCruising);
                            daysOfCruising = null;
                        }
                    }
                }
            }
            return listOfTrains;
        }


        public static List<TrainWithoutDaysOfCruising> GetListOfTrainsInfoWithDate(DateTime? date, string firstStation, string secondStation)
        {
            string trainFullName, departureTime, arrivalTime, travelTime, infoAboutSeats = null;
            List<TrainWithoutDaysOfCruising> listOfTrains = new List<TrainWithoutDaysOfCruising>();

            List<Train> listTrainWithDate = new List<Train>();
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
            {
                Station currentFirstStation = null, currentSecondStation = null;
                foreach (Station s in CurrentDBContext.ListOfStations)
                {
                    if (s.Name == firstStation)
                        currentFirstStation = s;
                    if (s.Name == secondStation)
                        currentSecondStation = s;
                }

                List<Route> routes = new List<Route>();
                if (currentFirstStation.Distance > currentSecondStation.Distance)
                    routes = currentFirstStation.Routes.ToList();
                else
                    routes = currentSecondStation.Routes.ToList();

                foreach (Route r in routes)
                {

                    if (date == null)
                        listTrainWithDate = r.ListOfTrains.ToList();
                    else
                    {
                        switch (date.Value.DayOfWeek)
                        {
                            case DayOfWeek.Monday:
                                foreach (Train t in r.ListOfTrains)
                                {
                                    foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                                        foreach (DayOfCruising day in d.DayOfCruisingInfo)
                                        {
                                            if (day.DayInfo == "Понедельник" || day.DayInfo == "Ежедневно")
                                                listTrainWithDate.Add(t);
                                        }
                                }
                                break;
                            case DayOfWeek.Tuesday:
                                foreach (Train t in r.ListOfTrains)
                                {
                                    foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                                        foreach (DayOfCruising day in d.DayOfCruisingInfo)
                                        {
                                            if (day.DayInfo == "Вторник" || day.DayInfo == "Ежедневно")
                                                listTrainWithDate.Add(t);
                                        }
                                }
                                break;
                            case DayOfWeek.Wednesday:
                                foreach (Train t in r.ListOfTrains)
                                {
                                    foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                                        foreach (DayOfCruising day in d.DayOfCruisingInfo)
                                        {
                                            if (day.DayInfo == "Среда" || day.DayInfo == "Ежедневно")
                                                listTrainWithDate.Add(t);
                                        }
                                }
                                break;
                            case DayOfWeek.Thursday:
                                foreach (Train t in r.ListOfTrains)
                                {
                                    foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                                        foreach (DayOfCruising day in d.DayOfCruisingInfo)
                                        {
                                            if (day.DayInfo == "Четверг" || day.DayInfo == "Ежедневно")
                                                listTrainWithDate.Add(t);
                                        }
                                }
                                break;
                            case DayOfWeek.Friday:
                                foreach (Train t in r.ListOfTrains)
                                {
                                    foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                                        foreach (DayOfCruising day in d.DayOfCruisingInfo)
                                        {
                                            if (day.DayInfo == "Пятница" || day.DayInfo == "Ежедневно")
                                                listTrainWithDate.Add(t);
                                        }
                                }
                                break;
                            case DayOfWeek.Saturday:
                                foreach (Train t in r.ListOfTrains)
                                {
                                    foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                                        foreach (DayOfCruising day in d.DayOfCruisingInfo)
                                        {
                                            if (day.DayInfo == "Суббота" || day.DayInfo == "Ежедневно")
                                                listTrainWithDate.Add(t);
                                        }
                                }
                                break;
                            case DayOfWeek.Sunday:
                                foreach (Train t in r.ListOfTrains)
                                {
                                    foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                                        foreach (DayOfCruising day in d.DayOfCruisingInfo)
                                        {
                                            if (day.DayInfo == "Воскресенье" || day.DayInfo == "Ежедневно")
                                                listTrainWithDate.Add(t);
                                        }
                                }
                                break;
                        }
                    } 
                    foreach (Train t in listTrainWithDate)
                    {
                        if (currentFirstStation.Distance > currentSecondStation.Distance)
                        {
                            r.RouteName = ReturnNewRoute(r.RouteName);
                            currentSecondStation.Distance = r.ListOfStations.ToList()[r.ListOfStations.Count - 1].Distance +
                                                           (r.ListOfStations.ToList()[r.ListOfStations.Count - 1].Distance -
                                                            currentSecondStation.Distance);
                            foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                                d.DepartureMinutes += 20;
                        }
                        //полное имя поезда
                        trainFullName = String.Format("{0} {1} {2}", t.TrainIDAsString, t.Type.TrainTypeName, r.RouteName);

                        //скорость поезда
                        int speedTrain = t.Type.Speed;

                        foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                        {
                            //время отправления поезда
                            TimeSpan startTime = new TimeSpan(d.DepartureHours, d.DepartureMinutes, 0);

                            double firstTimeAsDouble = (double)currentFirstStation.Distance / (double)speedTrain;
                            int firstTimeHour = (int)firstTimeAsDouble;
                            int firstTimeMinute = (int)((firstTimeAsDouble - (double)firstTimeHour) * 60);

                            TimeSpan currentFirstTime = startTime.Add(new TimeSpan(firstTimeHour, firstTimeMinute, 0));
                            //время прибытия на первую выбранную станцию
                            departureTime = String.Format("{0:hh\\:mm}", currentFirstTime);
                            TimeSpan timeOfFirstStation = new TimeSpan(firstTimeHour, firstTimeMinute, 0);

                            double secondTimeAsDouble = (double)currentSecondStation.Distance / (double)speedTrain;
                            int secondTimeHour = (int)secondTimeAsDouble;
                            int secondTimeMinute = (int)((secondTimeAsDouble - (double)secondTimeHour) * 60);

                            TimeSpan currentSecondTime = startTime.Add(new TimeSpan(secondTimeHour, secondTimeMinute, 0));
                            //время прибытия на конечную выбранную станцию
                            arrivalTime = String.Format("{0:hh\\:mm}", currentSecondTime);
                            TimeSpan timeOfSecondStation = new TimeSpan(secondTimeHour, secondTimeMinute, 0);

                            //время в пути
                            TimeSpan travelTimeAsTimeSpan = timeOfSecondStation.Subtract(timeOfFirstStation);
                            travelTime = String.Format("{0:hh\\:mm}", travelTimeAsTimeSpan);

                            //дни курсирования(если вбивать как массив, то они должны содержать в расписании как массив!!!)
                            //foreach (DayOfCruising day in d.DayOfCruisingInfo)
                            //{
                            //    infoAboutSeats += String.Format("{0}\n", day.DayInfo); 
                            //}
                            //string str = null;

                            List<TypeWagon> types = new List<TypeWagon>();
                            foreach (Wagon ws in t.Wagons)
                            {
                                types.Add(new TypeWagon()
                                {
                                    Name = String.Format("{0}-{1} руб.",
                                                  ws.Type.WagonName, currentSecondStation.Distance *
                                                  (t.Type.PriceForKilometer + ws.Type.PriceForKilometer)),
                                    Count = ws.Type.SeatSectors.ToList()[0].NumberOfLastSeat
                                });
                            }

                            int countSeat = t.Wagons.Select(s => s.Type.SeatSectors.ToList()[0].NumberOfLastSeat).FirstOrDefault();

                            for(int i = 0; i < types.Count; ++i)
                            {
                                if (types[i].Name != null)
                                {
                                    for (int j = i + 1; j <= types.Count - 1; ++j)
                                    {
                                        if (types[i].Name == types[j].Name)
                                        {
                                            countSeat += types[i].Count;
                                            types[i].Name = types[j].Name;
                                            types[j].Name = null;
                                            types[j].Count = 0;
                                        }
                                        else
                                        {
                                            types[i].Name += types[j].Name;

                                        }
                                    }
                                }
                                else
                                    break;
                                infoAboutSeats = String.Format("{0} Свободно {1} шт\n", types[i].Name, countSeat);
                            } 
                          
                            TrainWithoutDaysOfCruising trainCruising =
                                    new TrainWithoutDaysOfCruising(trainFullName, departureTime, arrivalTime, travelTime, infoAboutSeats);

                            listOfTrains.Add(trainCruising);

                            infoAboutSeats = null;
                        }
                    }
                }
            }
            return listOfTrains;
        }

        static string ReturnNewRoute(string nameRoute)
        {
            string firstNameStation = nameRoute.Substring(0, nameRoute.IndexOf('-'));
            string secondNameStation = nameRoute.Substring(nameRoute.IndexOf('-') + 1);
            return String.Format("{0}-{1}", secondNameStation, firstNameStation);
        }
        //static string ReturnTrainFullName(string firstStation, string secondStation)
        //{
        //    string trainFullName = null;
        //    using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
        //    {
        //        foreach (Route r in CurrentDBContext.ListOfRoutes)
        //        {

        //            if (r.ListOfStations.Where(s => s.Name == firstStation).FirstOrDefault() != null &&
        //                r.ListOfStations.Where(s => s.Name == secondStation).FirstOrDefault() != null)
        //            {
        //                string trainName = CurrentDBContext.ListOfTrains.
        //                                   Where(s => s.Route.RouteName == r.RouteName).
        //                                   Select(t => t.TrainIDAsString).FirstOrDefault();
        //                trainFullName = string.Format("{0} {1}", trainName, r.RouteName);
        //            }
        //        }
        //    }
        //    return trainFullName;
        //}

        public static List<string> ReturnListOfStationNames()
        {

            List<string> NewListOfStations = new List<string>();
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
            {
                NewListOfStations = CurrentDBContext.ListOfStations.OrderBy(p => p.Name).Select(s => s.Name).ToList();
            }

            return NewListOfStations;
        }

        public class TypeWagon
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        //static string ReturnCurrentDepartureTime()
        //{
        //    string DepartureTime = null;
        //    using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
        //    {

        //    }
        //}
    }
}
