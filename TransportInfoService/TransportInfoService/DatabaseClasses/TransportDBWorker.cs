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

                if (currentFirstStation.Distance == currentSecondStation.Distance)
                    routes = new List<Route>();
                else
                    routes = currentSecondStation.Routes.ToList();

                foreach (Route r in routes)
                {
                    List<Train> listTrains = null;

                    foreach(Station s in r.ListOfStations)
                    {
                        if (firstStation == s.Name)
                        {
                            listTrains = r.ListOfTrains.ToList();
                            break;
                        }    
                        else
                            listTrains = new List<Train>();
                    }
                    foreach (Train t in listTrains)
                    {
                        if (currentFirstStation.Distance > currentSecondStation.Distance)
                        {
                            r.RouteName = ReturnNewRoute(r.RouteName);  
                        }

                        //полное имя поезда
                        trainFullName = String.Format("{0} {1} {2}", t.TrainIDAsString, t.Type.TrainTypeName, r.RouteName);

                        //скорость поезда
                        int speedTrain = t.Type.Speed;

                        foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                        {

                            //максимальная длина маршрута
                            int maxStationDistance = r.ListOfStations.Select(s => s.Distance).Max();
                            double maxTimeAsDouble = (double)maxStationDistance / (double)speedTrain;
                            int maxTimeHour = (int)maxTimeAsDouble;
                            int maxTimeMinute = (int)((maxTimeAsDouble - (double)maxTimeHour) * 60);

                            //время отправления поезда
                            TimeSpan startTime = new TimeSpan();

                            if (currentFirstStation.Distance > currentSecondStation.Distance)
                            {
                                startTime = new TimeSpan(d.DepartureHours + maxTimeHour,
                                                        d.DepartureMinutes + maxTimeMinute + 20, 0);

                                currentFirstStation.Distance = maxStationDistance - (maxStationDistance - currentFirstStation.Distance);
                                currentSecondStation.Distance = maxStationDistance - (maxStationDistance - currentSecondStation.Distance);

                                int temp = 0;
                                temp = currentFirstStation.Distance;
                                currentFirstStation.Distance = currentSecondStation.Distance;
                                currentSecondStation.Distance = temp;
                            }
                            else
                                startTime = new TimeSpan(d.DepartureHours, d.DepartureMinutes, 0);

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
                if (currentFirstStation.Distance == currentSecondStation.Distance)
                    routes = new List<Route>();
                else
                    routes = currentSecondStation.Routes.ToList();

                if (currentFirstStation.Distance == currentSecondStation.Distance)
                    routes = new List<Route>();

                foreach (Route r in routes)
                {
                    foreach (Station s in r.ListOfStations)
                    {
                        if (firstStation != s.Name)
                            listTrainWithDate = new List<Train>();
                        else
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
                                                    {
                                                        listTrainWithDate.Add(t);
                                                        break;
                                                    }
                                                        
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
                                                    {
                                                        listTrainWithDate.Add(t);
                                                        break;
                                                    }
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
                                                    {
                                                        listTrainWithDate.Add(t);
                                                        break;
                                                    }
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
                                                    {
                                                        listTrainWithDate.Add(t);
                                                        break;
                                                    }
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
                                                    {
                                                        listTrainWithDate.Add(t);
                                                        break;
                                                    }
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
                                                    {
                                                        listTrainWithDate.Add(t);
                                                        break;
                                                    }
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
                                                    {
                                                        listTrainWithDate.Add(t);
                                                        break;
                                                    }
                                                }
                                        }
                                        break;
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
                        }
                        //полное имя поезда
                        trainFullName = String.Format("{0} {1} {2}", t.TrainIDAsString, t.Type.TrainTypeName, r.RouteName);

                        //скорость поезда
                        int speedTrain = t.Type.Speed;

                        foreach (DepartureTimeAndDayOfCruising d in t.ListOfDepartureTimeAndDaysOfCruising)
                        {
                            //максимальная длина маршрута
                            int maxStationDistance = r.ListOfStations.Select(s => s.Distance).Max();
                            double maxTimeAsDouble = (double)maxStationDistance / (double)speedTrain;
                            int maxTimeHour = (int)maxTimeAsDouble;
                            int maxTimeMinute = (int)((maxTimeAsDouble - (double)maxTimeHour) * 60);

                            //время отправления поезда
                            TimeSpan startTime = new TimeSpan();

                            if (currentFirstStation.Distance > currentSecondStation.Distance)
                            {
                                startTime = new TimeSpan(d.DepartureHours + maxTimeHour, 
                                                        d.DepartureMinutes + maxTimeMinute + 20, 0);

                                currentFirstStation.Distance = maxStationDistance - (maxStationDistance - currentFirstStation.Distance);
                                currentSecondStation.Distance = maxStationDistance - (maxStationDistance - currentSecondStation.Distance);

                                int temp = 0;
                                temp = currentFirstStation.Distance;
                                currentFirstStation.Distance = currentSecondStation.Distance;
                                currentSecondStation.Distance = temp;
                            }
                            else
                                startTime = new TimeSpan(d.DepartureHours, d.DepartureMinutes, 0);

                            
                            double firstTimeAsDouble = (double)currentFirstStation.Distance / (double)speedTrain;
                            int firstTimeHour = (int)firstTimeAsDouble;
                            int firstTimeMinute = (int)((firstTimeAsDouble - (double)firstTimeHour) * 60);

                            double secondTimeAsDouble = (double)currentSecondStation.Distance / (double)speedTrain;
                            int secondTimeHour = (int)secondTimeAsDouble;
                            int secondTimeMinute = (int)((secondTimeAsDouble - (double)secondTimeHour) * 60);

                            TimeSpan currentFirstTime = startTime.Add(new TimeSpan(firstTimeHour, firstTimeMinute, 0));
                            //время прибытия на первую выбранную станцию
                            departureTime = String.Format("{0:hh\\:mm}", currentFirstTime);
                            TimeSpan timeOfFirstStation = new TimeSpan(firstTimeHour, firstTimeMinute, 0);


                            TimeSpan currentSecondTime = startTime.Add(new TimeSpan(secondTimeHour, secondTimeMinute, 0));
                            //время прибытия на конечную выбранную станцию
                            arrivalTime = String.Format("{0:hh\\:mm}", currentSecondTime);
                            TimeSpan timeOfSecondStation = new TimeSpan(secondTimeHour, secondTimeMinute, 0);

                            //время в пути
                            TimeSpan travelTimeAsTimeSpan = timeOfSecondStation.Subtract(timeOfFirstStation);
                            travelTime = String.Format("{0:hh\\:mm}", travelTimeAsTimeSpan);


                            List<TypeWagon> types = new List<TypeWagon>();

                            //заполнения коллекции типов вагонов
                            foreach(string s in GetWagonTypeName())
                            {
                                types.Add(new TypeWagon() { Name = s });
                            }

                            int resultDistance = 0;
                            //заполнение значениями коллекции из типов вагонов
                            foreach(TypeWagon tw in types)
                            {
                                foreach(Wagon ws in t.Wagons)
                                {
                                    if(tw.Name == ws.Type.WagonName)
                                    {
                                        if (currentFirstStation.Distance > currentSecondStation.Distance)
                                            resultDistance = currentFirstStation.Distance - currentSecondStation.Distance;
                                        else
                                            resultDistance = currentSecondStation.Distance - currentFirstStation.Distance;

                                        tw.Price = resultDistance *
                                                  (t.Type.PriceForKilometer + ws.Type.PriceForKilometer);
                                        tw.Count += ws.Type.SeatSectors.ToList()[0].NumberOfLastSeat;
                                    }
                                        
                                }
                            }

                            //получения данных о типе вагона. цене и количестве свободных мест
                            foreach(TypeWagon tw in types)
                            {
                                if (tw.Price != 0 && tw.Count != 0)
                                    infoAboutSeats += String.Format("{0}-{1} руб. Свободно {2} шт\n",
                                                      tw.Name, tw.Price, tw.Count);
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


        //метод возваращающий название обратного маршрута
        static string ReturnNewRoute(string nameRoute)
        {
            string firstNameStation = nameRoute.Substring(0, nameRoute.IndexOf('-'));
            string secondNameStation = nameRoute.Substring(nameRoute.IndexOf('-') + 1);
            return String.Format("{0}-{1}", secondNameStation, firstNameStation);
        }


        //метод возвращающий коллекцию названий типов вагонов
        static List<string> GetWagonTypeName()
        {
            List<string> NewListOfWagonTypeNames = new List<string>();
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
            {
                NewListOfWagonTypeNames = CurrentDBContext.ListOfWagonTypes.Select(s => s.WagonName).ToList();
            }
            return NewListOfWagonTypeNames;
        }
       
        //метод возвращающий коллекцию станций 
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
            public int Price { get; set; }
            public int Count { get; set; }
        }


        static public bool RegisterNewUser(string UserLogin, string UserEmail, string UserPassword)
        {
            return true;
        }
    }
}
