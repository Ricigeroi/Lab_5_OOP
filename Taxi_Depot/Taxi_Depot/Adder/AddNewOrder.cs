using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Meniu;

namespace Taxi_depot.Adder
{
    public class AddNewOrder
    {
        public static void AddOrder(MenuItem menuItem)
        {
            Console.Clear();
            Console.Write("Enter type, distance: ");
            string[] input = Console.ReadLine().Split();
            Order order = new Order(input[0], Convert.ToInt16(input[1]));
            Console.Clear();
        }
        public static void AddOrder(int id_client)
        {
            int distance = new Random().Next(3, 15);
            Order order = new Order("econom", distance, id_client: id_client);
        }
    }
}
