using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_depot
{
    class Driver : Person
    {
        public int years_driving { get; set; }
        double rating;
        int id_car;
        public int id_order { get; set; }
        public int salary { get; set; }
        public int sick { get; set; }
        public static List<Driver> Drivers = new List<Driver>();
        public Driver(string name, string surname, int age, int years_driving, double rating = 0, int id = 0, int id_car = 0, int id_order = 0, int salary = 0, int sick = 0)
            : base(id, name, surname, age)
        {
            this.id = base.id;
            this.years_driving = years_driving;
            this.rating = rating;
            this.id_car = id_car;
            Drivers.Add(this);
            this.id_order = id_order;
            this.salary = salary;
            this.sick = sick;
        }

        public override string Describe()
        {
            return  id + " | Day(s) sick: " + sick + " | " + surname + " " + name + " " + age + " years old, " + years_driving + " years pro" + ". ORDER: " + id_order;
        }
        public string inform()
        {
            return id + " " + surname + " " + name + " " + age + " years old";
        }
        public int GetId()
        {
            return id;
        }
        public void AddRating(int multiplier)
        {
            if (rating < 5)
            {
                rating += 0.05 * multiplier;
            }
            else
            {
                rating = 5;
            }
        }
    }
}
