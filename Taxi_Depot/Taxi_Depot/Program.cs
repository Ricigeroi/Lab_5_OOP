using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Taxi_depot.Adder;
using Taxi_depot.Remover;
using Taxi_depot.Meniu;
using static System.Reflection.Metadata.BlobBuilder;
using Taxi_depot.Viewer;

namespace Taxi_depot
{
    class Program
    {
        public static void Main(string[] args)
        {
            Depo depo = new Depo();
            depo.depo();
        }   
    }
}
            

