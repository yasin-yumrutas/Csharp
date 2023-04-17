using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyUnitTest.App
{
    public class Hesaplama
    {

   
        public IHesaplamaService _hesaplamaService { get; set; }

        public Hesaplama(IHesaplamaService hesaplamaService)
        {
            this._hesaplamaService = hesaplamaService;
            
        }
        public int Add(int a, int b)
        {
            return _hesaplamaService.Add(a, b);
        }
        public int Multip(int a,int b)
        {
            return _hesaplamaService.Multip(a,b);
        }

    }
}
