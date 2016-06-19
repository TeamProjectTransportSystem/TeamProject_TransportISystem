using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.TransportSystemLogicClasses
{
    public interface ITrainInfo
    {
        //Содержит номер поезда и Первую и Последнюю станцию маршрута (зависит от того в какую сторону едет поезд) Пример - '665А Эконом Минск - Орша'
        string TrainFullName { get; set; }
        //Время прибытия на выбранную начальную остановку. Пример - "12:40"
        string DepartureTime { get; set; }
        //Время прибытия на выбранную конечную остановку. Пример - "12:40"
        string ArrivalTime { get; set; }
        //Время езды от выбранной начальной до выбранной конечной остановки. Пример - "12:40"
        string TravelTime { get; set; }
    }
}
