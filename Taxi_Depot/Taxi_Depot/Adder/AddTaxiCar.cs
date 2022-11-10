using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Meniu;

namespace Taxi_depot.Adder
{
    public class AddTaxiCar
    {
        public void AddTaxi()
        {
            Console.Clear();
            Console.Write("Enter make, model, year: ");
            string[] input = Console.ReadLine().Split();
            Taxi car = new Taxi(input[0], input[1], Convert.ToInt16(input[3]));
            Console.Clear();
        }
        public static void AddTaxi(MenuItem menuItem)
        {
            Console.Clear();
            Console.Write("Enter make, model, year: ");
            string[] input = Console.ReadLine().Split();
            Taxi car = new Taxi(input[0], input[1], Convert.ToInt16(input[3]));
            Console.Clear();
        }
        public static void buyCar(string make, string model, int year_of_issue)
        {
            Taxi taxi = new Taxi(make, model, year_of_issue);
        }
    }
}
