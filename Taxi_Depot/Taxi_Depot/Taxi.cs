using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Taxi_depot.Meniu;

namespace Taxi_depot
{
    class Taxi : Car
    {
        public int status { get; set; }
        public static List<Taxi> Taxis = new List<Taxi>();
 
        public Taxi(string make, string model, int year_of_issue, int status = 0, int id_car = 0, int damage = 0) 
            : base(make, model, year_of_issue, id_car, damage)
        {
            this.id_car = base.id_car;
            this.make = base.make;
            this.model = base.model;
            this.year_of_issue = base.year_of_issue;
            this.status = status;
            this.damage = damage;
            Taxis.Add(this);
        }
        
        public override string Describe()
        {
            return id_car + " | Damage: " + damage + " day(s). " + make.ToUpper() + ' ' + model.ToUpper() + ' ' + year_of_issue + " Order: " + status;
        }
        public string info()
        {
            return make.ToUpper() + " " + model.ToUpper() + ' ' + year_of_issue;
        }
 
        public int GetStatus()
        {
            return status;
        }

        public int GetId()
        {
            return id_car;
        }

    }
}
