using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.TransportSystemLogicClasses
{
    public class TrainWithDaysOfCruising
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
        //Значение этого поля зависит от количества станций, где останавливается поезд. Это поле не должно включать в себя введенные пользователем станции 
        //Примеры - "Везде","Кроме Мозырь,\n Гродно", "Мозырь,\n Гродно"
        public string Stations { get; set; }
        //Если пользователем не указана конкретная дата, то содержит описание количества мест в вагонах различного типа и их стоимость
        //Пример - "Купе - 150000 руб. 50 шт.\nПлацкартный - 100000 руб. 80 шт."
        //Если пользователем УКАЗАНА конкретная дата, то содержит описание количества СВОБОДНЫХ мест в вагонах различного типа и их стоимость
        //Пример - "Купе - 150000 руб. Свободно 50 шт.\nПлацкартный - 100000 руб. свободно 80 шт."
        public string InfoAboutSeats;

        public TrainWithDaysOfCruising(string CurrentTrainFullName, string CurrentDepartureTime, string CurrentArrivalTime, string CurrentTravelTime, string CurrentDaysOfCruising, string CurrentStations,
             string CurrentInfoAboutSeats)
        {
            TrainFullName = CurrentTrainFullName;
            DepartureTime = CurrentDepartureTime;
            ArrivalTime = CurrentArrivalTime;
            TravelTime = CurrentTravelTime;
            DaysOfCruising = CurrentDaysOfCruising;
            Stations = CurrentStations;
            InfoAboutSeats = CurrentInfoAboutSeats;
        }
    }
}
