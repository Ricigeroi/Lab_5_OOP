using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Adder;
using Taxi_depot.Meniu;
using Taxi_depot.Remover;
using Taxi_depot.Viewer;

namespace Taxi_depot
{
    public class Depo
    {
        public void depo()
        {
            MenuCategory main = new MenuCategory("Menu: ", new MenuItem[]
            {
                new MenuAction("Points", ViewPoints),
                new MenuAction("View balance", viewBalance),
                new MenuCategory("Taxi cars", new MenuItem[]
                {
                    new MenuAction("View taxi cars", ViewTaxis.viewTaxi),
                    new MenuCategory("Buy car", new MenuItem[]
                    {
                        new MenuAction("Toyota Prius30 2012     10.000$", AutoDealear.buyPrius),
                        new MenuAction("Toyota Corolla 2007      5.000$", AutoDealear.buyCorolla),
                        new MenuAction("Mercedes E190 1989       3.000$", AutoDealear.buyE190),
                        new MenuBack()
                    }),
                    new MenuBack()
                }),

                new MenuCategory("Drivers", new MenuItem[]
                {
                    new MenuAction("View drivers", ViewDrivers.viewDrivers),
                    new MenuCategory("Hire drivers", new MenuItem[]
                    {
                        new MenuAction("Dominic Toretto     300$ + 40$/action point", RecruitmentAgency.hireToretto),
                        new MenuAction("Brian O'Conner      300$ + 20$/action point", RecruitmentAgency.hireBrian),
                        new MenuAction("Jasom Statham       300$ + 30$/ation point", RecruitmentAgency.hireStatham),
                        new MenuBack()
                    }),
                    new MenuBack()
                }),

                new MenuAction("View clients", ViewClients.viewClients),
                new MenuCategory("Simulation", new MenuItem[]
                {
                    new MenuAction("Start simulate day", skipPoint),
                    new MenuAction("Next day", nextDay),
                    new MenuBack()
                }),
                new MenuCategory("Statitics", new MenuItem[]
                {
                    new MenuAction("Show one day date statistics", Statics.show),
                    new MenuAction("Show all time statics", Statics.showTotal),
                    new MenuBack()
                }),
                new MenuCategory("Options", new MenuItem[]
                {
                    new MenuCategory("Taxi cars", new MenuItem[]
                    {
                        new MenuAction("Add taxi car", AddTaxiCar.AddTaxi),
                        new MenuAction("Remove taxi car", RemoveTaxis.RemoveTaxi),
                        new MenuBack()
                    }),
                    new MenuCategory("Drivers", new MenuItem[]
                    {
                        new MenuAction("Add driver", AddNewDriver.AddDriver),
                        new MenuAction("Remove driver", RemoveDrivers.RemoveDriver),
                        new MenuBack()
                    }),
                    new MenuCategory("Clients", new MenuItem[]
                    {
                        new MenuAction("Add client", AddNewCLient.AddClient),
                        new MenuAction("Remove client", RemoveClients.RemoveClient),
                        new MenuBack()
                    }),
                    new MenuCategory("Orders", new MenuItem[]
                    {
                        new MenuAction("Add order", AddNewOrder.AddOrder),
                        new MenuAction("Remove order", RemoveOrders.RemoveOrder),
                        new MenuBack()
                    }),
                    new MenuAction("Clear all data", RemoveAll.Remove),
                    new MenuBack()
                }),
                new MenuBack("Exit")
            });
            Company company = new Company();
            Points points = new Points(25);
            company.AddMoney(50000);
            AddClients(10);
            Menu menu = new Menu(main);
            menu.Run();
            Console.WriteLine("Выход из приложения, нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void SomeActionMethod(MenuItem menuItem)
        {
            Console.WriteLine($"Вы нажали: {menuItem.Name}");
        }

        private static void AddClients(int number)
        {
            List<string> names = new List<string>() { "Andrei", "Ecaterina", "Egor", "Alina", "Danila", "Alisa", "Pavel", "Anna" };
            List<string> surnames = new List<string>() { "Bardier", "Racicovscii", "Mocrenco", "Zacatov", "Cojuhari", "Nedelcev", "Gordeev" };

            for (int i = 0; i < number; i++)
            {
                Client client = new Client(names[new Random().Next(names.Count())], surnames[new Random().Next(surnames.Count())], new Random().Next(16, 70), new Random().Next(1000, 25000));
            }
        }

        public void skipPoint(MenuItem menuItem)
        {

            int k = 0;
            while ((Order.Orders.Count == 0 || !Order.Orders.Exists(item => item.progress < 100)) && Points.Actions[0].amount > 0)
            {
                Points.Actions[0].spend();
                k++;
            }
            while (Points.Actions[0].amount > 0)
            {
                System.Threading.Thread.Sleep(500);
                ViewOrders.viewOrders(menuItem);
            }
            if (Points.Actions[0].amount == 0)
            {
                ViewOrders.viewOrders(menuItem);
            }
        }
        public static void nextDay(MenuItem menuItem)
        {
            int salary = 0;
            Console.WriteLine("NEW DAY STARTED");
            if (Points.Actions[0].amount > 0)
            {
                for (int i = 0; i < Points.Actions[0].amount; i++)
                {
                    foreach (Driver driver in Driver.Drivers)
                    {
                        Company.CompanyList[0].spendMoney(driver.salary);
                        salary += driver.salary;
                    }
                }
            }
            Points.Fines.Clear();
            foreach (Driver driver1 in Driver.Drivers)
            {
                driver1.id_order = 0;
                if (driver1.sick > 0)
                {
                    driver1.sick--;
                }
            }
            foreach (Taxi taxi in Taxi.Taxis)
            {
                taxi.status = 0;
                if (taxi.damage > 0)
                {
                    taxi.damage--;
                }
            }

            foreach (Client client in Client.Clients)
            {
                client.order_status = 0;
                client.AddMoney(new Random().Next(500, 3000));
            }
            Points.Actions[0].amount = 50;
            Order.Orders.Clear();

            Statics statics = new Statics(0, salary, 0, 0);
        }
        public static void nextDay()
        {
            int salary = 0;
            Console.WriteLine("NEW DAY STARTED");
            if (Points.Actions[0].amount > 0)
            {
                for (int i = 0; i < Points.Actions[0].amount; i++)
                {
                    foreach (Driver driver in Driver.Drivers)
                    {
                        Company.CompanyList[0].spendMoney(driver.salary);
                        salary += driver.salary;
                    }
                }
            }
            Points.Fines.Clear();
            foreach (Driver driver1 in Driver.Drivers)
            {
                driver1.id_order = 0;
                if (driver1.sick > 0)
                {
                    driver1.sick--;
                }
            }
            foreach (Taxi taxi in Taxi.Taxis)
            {
                taxi.status = 0;
                if (taxi.damage > 0)
                {
                    taxi.damage--;
                }
            }

            foreach (Client client in Client.Clients)
            {
                client.order_status = 0;
                client.AddMoney(new Random().Next(500, 3000));
            }
            Points.Actions[0].amount = 25;
            Order.Orders.Clear();
        }

        private static void ViewPoints(MenuItem menuItem)
        {
            Console.Clear();
            Console.WriteLine(Points.Actions[0].amount + " available points!");
            Console.ReadKey();
            Console.Clear();
        }

        private static void viewBalance(MenuItem menuItem)
        {
            Console.WriteLine("Your balance is " + Company.CompanyList[0].GetBalance() + "$");
        }
    }
}
