using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Taxi_depot
{
    class Client : Person
    {
        int money { get; set; }
        public int order_status { get; set; }
        public static List<Client> Clients = new List<Client>();

        public Client(string name, string surname, int age, int money, int id = 0, int order_status = 0)
            : base(id, name, surname, age)
        {
            this.id = base.id;
            this.money = money;
            this.order_status = order_status;
            Clients.Add(this);
        }

        public override string Describe()
        {
            return "Client " + id + " " + surname + " " + name + " " + age + " years old. Amount of money: " + money + ". Order: " + order_status;
        }
        public int GetId()
        {
            return id;
        }
        public int SpendMoney(int cost)
        {
            return this.money -= cost;
        }
        public void AddMoney(int cost)
        {
            this.money += cost;
        }

        public void CallTaxi()
        {
            int x =  new Random().Next(0, 100);
            if ( x > 90)
            {
                if (Driver.Drivers.Exists(driver => driver.sick == 0)
                    && Taxi.Taxis.Exists(taxi => taxi.damage == 0))
                {

                    int distance = new Random().Next(3, 15);
                    Order order = new Order("econom", distance, id_client: this.id);
                    
                    if (this.money > order.GetFare())
                    {
                        this.SpendMoney(order.GetFare());
                        Company.CompanyList[0].AddMoney(order.GetFare());
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("*************************************");
                        Console.WriteLine("Client does not have money to pay. You won't earn anything.");
                        Console.WriteLine("*************************************");
                        Console.ResetColor();
                        Points.Fines.Add(order.GetFare());
                        System.Threading.Thread.Sleep(1000);
                    }
                    
                }
            }
        }
    }
}
