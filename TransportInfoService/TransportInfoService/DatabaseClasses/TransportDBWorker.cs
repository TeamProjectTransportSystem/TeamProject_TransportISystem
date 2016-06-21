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
            string trainFullName, departureTime, arrivalTime, travelTime, daysOfCruising;
            List<TrainWithDaysOfCruising> listOfTrains = new List<TrainWithDaysOfCruising>();
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringNewVersion))
            {
                Station currentFirstStation = null, currentSecondStation = null;
                foreach (Station s in CurrentDBContext.ListOfStations)
                {
                    if (s.Name == firstStation)
                        currentFirstStation = s;
                    if (s.Name == secondStation)
                        currentSecondStation = s;
                }
               
                foreach(Route r in currentSecondStation.Routes)
                {
                    foreach (Train t in r.ListOfTrains)
                    {
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
                            daysOfCruising = d.DayOfCruisingInfo.DayInfo;

                            TrainWithDaysOfCruising trainCruising =
                                    new TrainWithDaysOfCruising(trainFullName, departureTime, arrivalTime, travelTime, daysOfCruising);

                            listOfTrains.Add(trainCruising);
                        }
                    }
                } 
            }
            return listOfTrains;
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
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringNewVersion))
            {
                NewListOfStations = CurrentDBContext.ListOfStations.OrderBy(p=>p.Name).Select(s => s.Name).ToList();
            }

            return NewListOfStations;
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
