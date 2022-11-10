using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_depot
{
    public class Fare : Depo
    {
        public static int GetFareEconom()
        {
            return 150;
        }

        public static int GetFareComfort()
        {
            return 200;
        }
    }

}
