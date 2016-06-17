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
        public static List<object> ReturnTrain(DateTime? time, string firstStation, string secondStation)
        {
            string CurrentTrainFullName, CurrentDepartureTime, CurrentArrivalTime, CurrentTravelTime, CurrentDaysOfCruising;
            List<object> listOfTrains = new List<object>();
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
            {
                //CurrentTrainFullName = ReturnTrainFullName(firstStation, secondStation);
                foreach (Route r in CurrentDBContext.ListOfRoutes)
                {
                    Station currentFirstStation = r.ListOfStations.Where(s => s.Name == firstStation).FirstOrDefault();
                    Station currentSecondStation = r.ListOfStations.Where(s => s.Name == secondStation).FirstOrDefault();

                    if (currentFirstStation != null && currentSecondStation != null)
                    {
                        //поиск полного имени поезда с маршрутом
                        string trainName = CurrentDBContext.ListOfTrains.
                                           Where(s => s.Route.RouteName == r.RouteName).
                                           Select(t => t.TrainIDAsString).FirstOrDefault();
                        CurrentTrainFullName = string.Format("{0} {1}", trainName, r.RouteName);
                        //поиск времени прибытия на начальную станцию
                        int speedTrain = CurrentDBContext.ListOfTrains.
                                         Where(t=>t.TrainIDAsString == trainName).
                                         Select(s=>s.Type.Speed).FirstOrDefault();
                        List<DepartureTimeAndDayOfCruising> departureTime = new List<DepartureTimeAndDayOfCruising>();
                        foreach(Train t in r.ListOfTrains)
                        {
                            if(t.TrainIDAsString == trainName)
                            {
                                departureTime = (List<DepartureTimeAndDayOfCruising>)t.ListOfDepartureTimeAndDaysOfCruising;
                            }
                        }
 
                        foreach(DepartureTimeAndDayOfCruising d in departureTime)
                        {
                            TimeSpan startTime = new TimeSpan(d.DepartureHours, d.DepartureMinutes, 0);
                            string firstTimeAsString = (currentFirstStation.Distance / speedTrain).ToString();
                            int firstTimeHour = Int32.Parse(firstTimeAsString.Substring(firstTimeAsString.IndexOf('.')));
                            int firstTimeMinute = Int32.Parse(firstTimeAsString.Substring(firstTimeAsString.LastIndexOf('.'))) * 60;
                            //TimeSpan timeOfFirstStation = 
                        }
                    }
                }
                if (time == null)
                {
                    
                }
                else
                {

                }
            }
            return listOfTrains;

        }

        static string ReturnTrainFullName(string firstStation, string secondStation)
        {
            string trainFullName = null;
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
            {
                foreach (Route r in CurrentDBContext.ListOfRoutes)
                {

                    if (r.ListOfStations.Where(s => s.Name == firstStation).FirstOrDefault() != null &&
                        r.ListOfStations.Where(s => s.Name == secondStation).FirstOrDefault() != null)
                    {
                        string trainName = CurrentDBContext.ListOfTrains.
                                           Where(s => s.Route.RouteName == r.RouteName).
                                           Select(t => t.TrainIDAsString).FirstOrDefault();
                        trainFullName = string.Format("{0} {1}", trainName, r.RouteName);
                    }
                }
            }
            return trainFullName;
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
