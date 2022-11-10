using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Meniu;
using Taxi_depot.Viewer;

namespace Taxi_depot
{
    public class Points : Depo
    {
        public int amount { get; set; }
        public static List<Points> Actions = new List<Points>();
        public static List<int> Fines = new List<int>();
        public Points(int amount)
        {
            this.amount = amount;
            Actions.Add(this);
        }
        public void spend()
        {
            amount -= 1;
            GenerateOrders();
            foreach (Order order in Order.Orders)
            {
                Taxi taxi = Taxi.Taxis.Find(taxi => taxi.GetStatus() == order.GetId());
                Driver driver = Driver.Drivers.Find(driver => driver.id_order == order.GetId());
                Client client = Client.Clients.Find(client => client.order_status == order.GetId());

                if (order.id_car != 0 && order.id_driver != 0)
                {
                    order.Progress();
                   
                    if (taxi != null && driver != null && order.progress < 100 && order != null)
                    {
                        if (Accident(driver.years_driving))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("*************************************");
                            Console.WriteLine(taxi.info() + " got in an accident!");
                            int fine = new Random().Next(order.GetFare(), 20000);
                            Fines.Add(fine);
                            Console.WriteLine("Taxi-company has been fined by " + fine + " dollars.");
                            Company.CompanyList[0].spendMoney(fine);
                            int period = new Random().Next(1, 4);
                            Console.WriteLine("Car will be unavailable for " + period + " day(s)!");
                            taxi.damage = period;
                            Console.WriteLine("*************************************");
                            Console.ResetColor();
                            order.progress = 100;
                            System.Threading.Thread.Sleep(1000);
                        }
                        if (GotSick(driver.age) && driver.sick == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("*************************************");
                            Console.WriteLine(driver.inform() + " got sick!");
                            int period = new Random().Next(3, 7);
                            Console.WriteLine("Driver finishes his order and will be unavailable for " + period + " day(s)!");
                            driver.sick = period;
                            Console.WriteLine("*************************************");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(1000);
                        }
                        if (Break(2022 - taxi.year_of_issue))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("*************************************");
                            Console.WriteLine(taxi.info() + " just broke!");
                            int period = new Random().Next(1, 3);
                            Console.WriteLine("Car will be unavailable for " + period + " day(s)!");
                            taxi.damage = period;
                            Console.WriteLine("*************************************");
                            Console.ResetColor();
                            order.progress = 100;
                            order.id_car = 0;
                            order.id_driver = 0;
                            order.id_client = 0;
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                }
                else
                {
                    order.assign();
                }

                if (order.progress == 100)
                {
                    if (taxi != null) { taxi.status = 0; }
                    if (driver != null) { driver.id_order = 0; }
                    if (client != null) { client.order_status = 0; }
                    order.id_car = 0;
                    order.id_driver = 0;
                    order.id_client = 0;
                }
            }
            foreach (Driver driver in Driver.Drivers)
            {
                Company.CompanyList[0].spendMoney(driver.salary);
            }

        }

        private static bool Accident(int multiplier)
        {
            double chance = new Random().Next(1, 1000) * (Convert.ToDouble(multiplier) / Convert.ToDouble(10));
            chance = Math.Floor(chance) + 1;
            if (chance < 5)
            {
                return true;
            }
            return false;
        }

        private static bool Break(int multiplier)
        {

            double chance = new Random().Next(1, 1000) * (Convert.ToDouble(multiplier)/Convert.ToDouble(15));
            chance = Math.Floor(chance);
            if (chance < 10)
            {
                return true;
            }
            return false;
        }

        private static bool GotSick(int multiplier)
        {
            double chance = new Random().Next(1, 1000) * (Convert.ToDouble(multiplier) / Convert.ToDouble(40));
            chance = Math.Floor(chance) + 1;
            if (chance < 10)
            {
                return true;
            }
            return false;
        }

        private static void GenerateOrders()
        {
            foreach (Client client in Client.Clients)
            {
                if (client.order_status == 0)
                {
                    client.CallTaxi();
                    Order order = Order.Orders.Find(order => order.id_client == client.GetId());
                    if (order != null)
                    {
                        client.order_status = order.GetId();
                        order.assign();
                        Taxi taxi = Taxi.Taxis.Find(taxi => taxi.GetStatus() == order.GetId());
                        Driver driver = Driver.Drivers.Find(driver => driver.id_order == order.GetId());
                        if (taxi != null && driver != null)
                        {
                            order.id_driver = driver.GetId();
                            order.id_car = taxi.GetId();
                        }
                    }
                }
            }
        }
    }
}
