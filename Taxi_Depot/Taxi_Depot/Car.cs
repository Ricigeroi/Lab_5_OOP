using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_depot
{
    public class Car : Depo
    {
        protected int id_car;
        protected string make;
        protected string model;
        protected string color;
        public int damage { get; set; }
        public int year_of_issue { get; set; }
        public static List<Car> Cars = new List<Car>();
        public Car(string make, string model, int year_of_issue, int id_car, int damage)
        {
            this.id_car = Cars.Count() + 1;
            this.make = make;
            this.model = model;
            this.year_of_issue = year_of_issue;
            Cars.Add(this);
            this.damage = damage;
        }
        public virtual string Describe()
        {
            return id_car + " " + make.ToUpper() + ' ' + model.ToUpper() + ' ' + year_of_issue;
        }
    }
}
