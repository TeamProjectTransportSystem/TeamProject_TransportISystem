using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    public class TransportDBseeder : CreateDatabaseIfNotExists<TransportDBContext>
    {
        protected override void Seed(TransportDBContext context)
        {
            context.ListOfStationTypes.Add(new StationType() { Name = "FirstType" });
            context.ListOfStationTypes.Add(new StationType() { Name = "SecondType" });
            context.ListOfStationTypes.Add(new StationType() { Name = "ThirdType" });

            base.Seed(context);
        }
    }
}
