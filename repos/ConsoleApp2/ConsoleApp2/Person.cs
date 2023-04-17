using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public Person(string name,string surname)
        {
            this.Name = name;
            this.SurName = surname;
            Console.WriteLine("Person nesenesi oluşturuldu!");


         
        }
        public virtual void Intro()
        {
            Console.WriteLine($"name:{this.Name}");
            Console.WriteLine($"surname:{this.SurName}");
        
            //Console.WriteLine($"student_number:{this.StudentNumber}");

        }
    }
    
}
