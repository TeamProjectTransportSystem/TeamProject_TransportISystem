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
        public static List<object> ReturnTrain(DateTime? time, string firatStation, string secondStation)
        {

            List<object> listOfTrains = new List<object>();
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
            {
                if (time == null)
                {
                    foreach (Route r in CurrentDBContext.ListOfRoutes)
                    {

                        if(r.ListOfStations.Where(s=>s.Name == firatStation).FirstOrDefault() != null && r.ListOfStations.Where(s=>s.Name == secondStation).FirstOrDefault() != null)
                        {

                        }
                    }
                }
                else
                {

                }
     
                

            }
            return listOfTrains;

        }

    }
}
