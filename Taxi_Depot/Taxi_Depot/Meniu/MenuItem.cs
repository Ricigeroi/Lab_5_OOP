using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_depot.Meniu
{
    public abstract class MenuItem
    {
        public string Name { get; }

        public MenuItem(string name)
        {
            Name = name;
        }
    }
}
