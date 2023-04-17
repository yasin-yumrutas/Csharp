using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Teacher:Person
    {
        public string Branch { get; set; }
        public Teacher(string name,string surname,string branch):base(name,surname)
        {
            this.Branch= branch;
        }
        public void Teaching()
        {
            Console.WriteLine("I am teaching");
        }
        public override void Intro()
        {
            Console.WriteLine($"oğretmen_name:{this.Name}");
            Console.WriteLine($"oğretmen_surname:{this.SurName}");
            Console.WriteLine($"öğretmen_branş:{this.Branch}");
        }
    }
}
