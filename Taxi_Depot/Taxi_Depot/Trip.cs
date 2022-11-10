using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_depot
{
    public class Trip : Depo
    {
        int id_order;
        double speed;
        double distance;
        double traffic;
        public double progress { get; set; }
        double x = 0;
        public Trip(int id_order, double distance, double traffic = 1, double speed = 2)
        {
            this.id_order = id_order;
            this.distance = distance;
            this.traffic = traffic;
            this.speed = speed;
        }
        public int move()
        {
            if (progress < 100)
            {
                x += speed / traffic;
                progress = (x / distance) * 100;
                if (progress > 100)
                {
                    progress = 100;
                }
            }
            return Convert.ToInt32(progress);

        }
        public string Describe()
        {
            return "Trip #" + id_order + ". Distance = " + distance + ". Progress: " + progress + "%";
        }
    }
}
