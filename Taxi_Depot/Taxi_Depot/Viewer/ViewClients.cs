using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Meniu;

namespace Taxi_depot.Viewer
{
    internal static class ViewClients
    {
        public static void viewClients(MenuItem menuItem)
        {
            if (Client.Clients.Count() != 0)
                foreach (Client item in Client.Clients)
                    Console.WriteLine(item.Describe());
            else
                Console.WriteLine("There are no clients yet!");
        }
    }
}
