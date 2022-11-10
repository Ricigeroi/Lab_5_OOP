using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Adder;
using Taxi_depot.Meniu;

namespace Taxi_depot
{
    public class RecruitmentAgency : Company
    {
        int balance;
        public RecruitmentAgency(int balance)
        {
            this.balance = balance;
        }

        
        public static void hireToretto(MenuItem menuItem)
        {
            Console.Clear();
            AddNewDriver.hireDriver("Dominic", "Toretto", 55, 55-21, salary: 40);
            Console.Clear();
            Company.CompanyList[0].spendMoney(300);
        }
        public static void hireBrian(MenuItem menuItem)
        {
            Console.Clear();
            AddNewDriver.hireDriver("Brian", "O'Conner", 40, 15, salary: 20);
            Console.Clear();
            Company.CompanyList[0].spendMoney(300);
        }
        public static void hireStatham(MenuItem menuItem)
        {
            Console.Clear();
            AddNewDriver.hireDriver("Jason", "Statham", 55, 20, salary: 30);
            Console.Clear();
            Company.CompanyList[0].spendMoney(300);
        }

        public static void hireToretto()
        {
            Console.Clear();
            AddNewDriver.hireDriver("Dominic", "Toretto", 55, 55 - 21, salary: 40);
            Console.Clear();
            Company.CompanyList[0].spendMoney(300);
        }
        public static void hireBrian()
        {
            Console.Clear();
            AddNewDriver.hireDriver("Brian", "O'Conner", 40, 15, salary: 20);
            Console.Clear();
            Company.CompanyList[0].spendMoney(300);
        }
        public static void hireStatham()
        {
            Console.Clear();
            AddNewDriver.hireDriver("Jason", "Statham", 55, 20, salary: 30);
            Console.Clear();
            Company.CompanyList[0].spendMoney(300);
        }
    }
}

