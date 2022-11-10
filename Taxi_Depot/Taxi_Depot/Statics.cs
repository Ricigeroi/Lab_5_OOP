using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Meniu;

namespace Taxi_depot
{
    public class Statics
    {
        int income { get; }
        int salary { get; }
        int fines { get; }
        int taxes { get; }
        int total { get; }

        public static List<Statics> Statistics = new List<Statics>();
        public Statics(int income, int salary, int fines, int taxes)
        {
            this.income = income;
            this.salary = salary;
            this.fines = fines;
            this.taxes = taxes;
            this.total = income - (salary + fines + taxes);
            Statistics.Add(this);
        }

        public static void show(MenuItem menuItem)
        {
            Console.Clear();
            Console.Write("Enter day numer to show stats: ");
            int index = Convert.ToInt16(Console.ReadLine()) - 1;
            Console.WriteLine("Report on day " + (index - 1) + ":");
            Console.WriteLine("Earned: " + Statistics[index].income);
            Console.WriteLine("Salary paid: " + Statistics[index].salary);
            Console.WriteLine("Fines paid: " + Statistics[index].fines);
            Console.WriteLine("Taxes: " + Statistics[index].taxes);
            Console.WriteLine("Total: " + Statistics[index].total);
            Console.WriteLine("********************");
            Console.ReadKey();
            Console.Clear();
        }

        public static void showTotal(MenuItem menuItem)
        {
            Console.Clear();
            int totalIncome = 0;
            int totalSalary = 0;
            int totalFines = 0;
            int totalTaxes = 0;
            int totalTotal = 0;
            foreach (Statics item in Statistics)
            {
                totalIncome += item.income;
                totalSalary += item.salary;
                totalFines += item.fines;
                totalTaxes += item.taxes;
                totalTotal += item.total;
            }

            int days = Statistics.Count();
            Console.WriteLine("Report on " + days + " days:");
            Console.WriteLine("Earned: " + totalIncome);
            Console.WriteLine("Salary paid: " + totalSalary);
            Console.WriteLine("Fines paid: " + totalFines);
            Console.WriteLine("Taxes: " + totalTaxes);
            Console.WriteLine("Total: " + totalTotal);
            Console.WriteLine("********************");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
