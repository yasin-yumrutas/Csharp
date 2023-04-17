using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geriye_dönük
{
    abstract class Person
    {
        public Person()
        {
            Console.WriteLine("bu ilginçmiş");
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public Person(string name, string surname)
        {
            this.SurName = surname;
            this.Name = name;
        }
        public void greeting()
        {
            Console.WriteLine("ı am person");
        }
        public abstract void Intro();

    }
}
