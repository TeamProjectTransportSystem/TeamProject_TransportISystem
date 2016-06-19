using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.TransportSystemLogicClasses
{
    public class TrainWithDaysOfCruising : ITrainInfo
    {
        //Содержит номер поезда и Первую и Последнюю станцию маршрута (зависит от того в какую сторону едет поезд) Пример - '665А Эконом Минск - Орша'
        public string TrainFullName { get; set; }
        //Время прибытия на выбранную начальную остановку. Пример - "12:40"
        public string DepartureTime { get; set; }
        //Время прибытия на выбранную конечную остановку. Пример - "12:40"
        public string ArrivalTime { get; set; }
        //Время езды от выбранной начальной до выбранной конечной остановки. Пример - "12:40"
        public string TravelTime { get; set; }
        //Дни курсирования. Пример - "понедельник,\n суббота"
        public string DaysOfCruising { get; set; }

        public TrainWithDaysOfCruising(string CurrentTrainFullName, string CurrentDepartureTime, string CurrentArrivalTime, string CurrentTravelTime, string CurrentDaysOfCruising)
        {
            TrainFullName = CurrentTrainFullName;
            DepartureTime = CurrentDepartureTime;
            ArrivalTime = CurrentArrivalTime;
            TravelTime = CurrentTravelTime;
            DaysOfCruising = CurrentDaysOfCruising;
        }
    }
}
