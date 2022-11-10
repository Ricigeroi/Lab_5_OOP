using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Meniu;

namespace Taxi_depot.Viewer
{
    internal class ViewOrders
    {
        public static void viewOrders(MenuItem menuItem)
        {
            if (Points.Actions[0].amount == 0)
            {
                int sum = 0;
                int sum_distance = 0;
                int salary = 0;
                int fines = 0;
                Console.Clear();
                Console.WriteLine("You have no actions points.");
                Console.WriteLine();
                foreach (Order item in Order.Orders)
                {
                    Console.WriteLine(item.inform());
                    sum_distance += item.GetDistance();
                    sum += item.GetFare();

                }
                foreach (Driver driver in Driver.Drivers)
                {
                    salary += driver.salary * 50;
                }
                foreach (int fine in Points.Fines)
                {
                    fines += fine;
                }
                int total = (sum - fines - salary);

                Statics statics = new Statics(sum, salary, fines, Convert.ToInt32(total * 0.13));

                Console.WriteLine("______________________________________________________________");
                Console.WriteLine("Earned today: " + sum + "$. Passed km: " + sum_distance);
                Console.WriteLine("Salary: " + salary + "$");
                Console.WriteLine("Fines: " + fines + "$");
                Console.WriteLine("Taxes + fees (13%): " + 0.13 * total + "$");
                Company.CompanyList[0].spendMoney(Convert.ToInt32(total * 0.13));
                Console.WriteLine("______________________________________________________________");
                Console.WriteLine("TOTAL: " + total + "$" );
                Console.ReadKey();
                Depo.nextDay();
                Console.Clear();
            }
            else
            {
                if (Order.Orders.Count() != 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 5);
                    Points.Actions[0].spend();
                    if (!(Driver.Drivers.Exists(driver => driver.sick == 0)
                    && Taxi.Taxis.Exists(taxi => taxi.damage == 0)))
                    {
                        Points.Actions[0].amount = 0;
                    }
                    foreach (Order order in Order.Orders)
                    {
                        Taxi taxi = Taxi.Taxis.Find(taxi => taxi.GetStatus() == order.GetId());
                        Driver driver = Driver.Drivers.Find(driver => driver.id_order == order.GetId());
                        Client client = Client.Clients.Find(client => client.GetId() == order.id_client);
                        if (order.progress < 100)
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.WriteLine(order.inform());
                            if (client != null)
                            {
                                Console.WriteLine(client.Describe());
                            }
                            else
                            {
                                Console.WriteLine("Undefined client");
                            }
                            if (driver != null)
                            {
                                Console.WriteLine(driver.inform());
                            }
                            else
                            {
                                Console.WriteLine("Undefined driver");
                            }
                            if (taxi != null)
                            {
                                Console.WriteLine(taxi.Describe());
                            }
                            else
                            {
                                Console.WriteLine("Undefined car");
                            }
                            Console.WriteLine("___________________________________________________________________");
                        }
                    }
                }

            }
        }

    }
}
