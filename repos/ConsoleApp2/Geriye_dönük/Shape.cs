using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geriye_dönük
{
    internal class Shape : Person
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public void Draw()
        {
            Console.WriteLine("Draw a shape");
        }
        public Shape()
        {
            Console.WriteLine("Constrak yapı çalıştı");
        }

        public override void Intro()
        {
            Console.WriteLine("ıntro methodu çalıştı");
        }
    }
}
