using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Student:Person
    {
        public int StudentNumber { get; set; }
        public Student(string name,string surname,int studentnumber) :base(name,surname)
        {
        StudentNumber = studentnumber;
            Console.WriteLine("Student nesnesi oluşturuldu");
        }
        public override void Intro()
        {
            //base.Intro();
            Console.WriteLine($"student_name:{this.Name}");
            Console.WriteLine($"student_surname:{this.SurName}");
            Console.WriteLine($"öğrenci no:{this.StudentNumber}");
        }
    }
}
