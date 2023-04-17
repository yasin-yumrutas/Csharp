using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1() {10 };
            Console.WriteLine(   class1.MyProperty);
            Console.WriteLine("söyle içinden geçeni");
            Console.ReadKey();

        }
    }
}
