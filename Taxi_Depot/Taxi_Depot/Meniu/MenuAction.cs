using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_depot.Meniu
{
    public class MenuAction : MenuItem
    {
        public Action<MenuItem> Action { get; }

        public MenuAction(string name, Action<MenuItem> action) : base(name)
        {
            Action = action;
        }
    }
}
