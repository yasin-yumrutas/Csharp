using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class Class1 : IProduct
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Id { get; set; }

        public void Info(string name,string description,int id)
        {
            this.Name = name;
            this.Description = description;
            this.Id = id;
            Console.WriteLine($"Id:{this.Id},Name:{this.Name},Description:{this.Description}");
        }

        public void Info()
        {
            Console.WriteLine("Neden böyle");
        }
    }
}
