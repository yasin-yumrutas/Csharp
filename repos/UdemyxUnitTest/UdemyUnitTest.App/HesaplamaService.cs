using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyUnitTest.App
{
    public class HesaplamaService : IHesaplamaService
    {
        public int Add(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            return a + b;
        }
        
        public int Multip(int a,int b)
        {
            if(a==0)
            {
                throw new Exception("(a=0) olamaz");
            }
            return a * b;
        }
    }
}
