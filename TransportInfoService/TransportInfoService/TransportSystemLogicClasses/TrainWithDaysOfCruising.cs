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
        //Содержит номер поезда и Первую и Последнюю станцию маршрута (зависит от того в какую сторону едет поезд) Пример - '665А Минск - Орша'
        public string TrainFullName { get; set; }

        public TrainWithDaysOfCruising(string CurrentTrainFullName)
        {
            TrainFullName = CurrentTrainFullName;
        }
    }
}
