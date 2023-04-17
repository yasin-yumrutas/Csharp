using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal interface IProduct
    {
        string Name { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        //void Info(string name,string description,int id)
        //{
        //    this.Name = name;   
        //    this.Description = description; 
        //    this.Id = id;   
        //}
        void Info();
    }
}
