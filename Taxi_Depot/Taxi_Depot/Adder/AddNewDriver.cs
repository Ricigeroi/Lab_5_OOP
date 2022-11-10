using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Meniu;

namespace Taxi_depot.Adder
{
    internal class AddNewDriver
    {
        public static void AddDriver(MenuItem menuItem)
        {
            Console.Clear();
            Console.Write("Enter name, surname, age, years driving: ");
            string[] input = Console.ReadLine().Split();
            Driver cabdriver = new Driver(input[0], input[1], Convert.ToInt16(input[2]), Convert.ToInt16(input[3]));
            Console.Clear();
        }
        public static void AddDriver()
        {
            Console.Clear();
            Console.Write("Enter name, surname, age, years driving: ");
            string[] input = Console.ReadLine().Split();
            Driver cabdriver = new Driver(input[0], input[1], Convert.ToInt16(input[2]), Convert.ToInt16(input[3]));
            Console.Clear();
        }

        public static void hireDriver(string name, string surname, int age, int years_driving, int salary)
        {
            Driver driver = new Driver(name, surname, age, years_driving, salary: salary);
        }
    }
}
