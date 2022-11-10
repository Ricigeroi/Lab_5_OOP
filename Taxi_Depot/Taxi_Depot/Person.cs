using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_depot
{
    abstract class Person : Depo
    {
        protected int id;
        protected string name;
        protected string surname;
        public int age { get; set; }
        public static List<Person> People = new List<Person>();
        public Person(int id, string name, string surname, int age)
        {
            this.id = People.Count() + 1;
            this.name = name;
            this.surname = surname;
            this.age = age;
            People.Add(this);
        }

        public virtual string Describe()
        {
            return "Person " + id + " " + surname + " " + name + " " + age + " years old";
        }
    }
}
