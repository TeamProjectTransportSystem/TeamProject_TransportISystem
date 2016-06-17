using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.TransportSystemLogicClasses
{
    public class TrainWithoutDaysOfCruising
    {
        //Содержит номер поезда и Первую и Последнюю станцию маршрута (зависит от того в какую сторону едет поезд) Пример - '665А Эконом Минск - Орша'
        public string TrainFullName { get; set; }
        //Время прибытия на выбранную начальную остановку. Пример - "12:40"
        public string DepartureTime { get; set; }
        //Время прибытия на выбранную конечную остановку. Пример - "12:40"
        public string ArrivalTime { get; set; }
        //Время езды от выбранной начальной до выбранной конечной остановки. Пример - "12:40"
        public string TravelTime { get; set; }
        //Содержит описание количества СВОБОДНЫХ мест в вагонах различного типа и их стоимость
        //Пример - "Купе - 150000 руб. Свободно 50 шт.\nПлацкартный - 100000 руб. свободно 80 шт."
        public string InfoAboutSeats { get; set; }

        public TrainWithoutDaysOfCruising(string CurrentTrainFullName, string CurrentDepartureTime, string CurrentArrivalTime, string CurrentTravelTime, string CurrentInfoAboutSeats)
        {
            TrainFullName = CurrentTrainFullName;
            DepartureTime = CurrentDepartureTime;
            ArrivalTime = CurrentArrivalTime;
            TravelTime = CurrentTravelTime;
            InfoAboutSeats = CurrentInfoAboutSeats;
        }
    }
}
