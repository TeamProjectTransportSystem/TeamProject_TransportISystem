using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportInfoService.DatabaseClasses;
using TransportInfoService.Resources;

namespace TransportInfoService
{
    public sealed class Model
    {
        private static volatile Model instance;
        private static object syncRoot = new Object();

        private Model() { }

        public static Model Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Model();
                    }
                }

                return instance;
            }
        }

        
    }
}
