using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Meniu;

namespace Taxi_depot.Remover
{
    internal static class RemoveTaxis
    {
        public static void RemoveTaxi(MenuItem menuItem)
        {
            Console.Clear();
            Console.Write("Enter ID to remove: ");
            int input = Convert.ToInt16(Console.ReadLine());
            Taxi.Taxis.RemoveAt(input - 1);
            Car.Cars.RemoveAt(input - 1);
            Console.Clear();
        }
        public static void RemoveTaxi()
        {
            Console.Clear();
            Console.Write("Enter ID to remove: ");
            int input = Convert.ToInt16(Console.ReadLine());
            Taxi.Taxis.RemoveAt(input - 1);
            Car.Cars.RemoveAt(input - 1);
            Console.Clear();
        }
    }
}
