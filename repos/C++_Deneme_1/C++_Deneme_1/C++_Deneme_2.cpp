#include<iostream>
using namespace std;

class ComplexT {
	float re, im;
	static unsigned int sayac;
public:
	ComplexT(float re_in = 0, float im_in = 1);
	ComplexT(const ComplexT&);
	ComplexT topla(const ComplexT&)const;
	void g�ster()const;
	static void sifirla() { sayac = 0; }
	ComplexT(); //--->K�vr�ml� i�areti unuttun ba�taki //Yok edici
};




ComplexT::ComplexT(float re_in, float im_in)
{
	re = re_in;
	im = im_in;
	sayac++;
	cout << endl << "Kurucu Cal�sti";
	cout << "Nesne sayisi=" << sayac;
}



ComplexT::ComplexT(const ComplexT& c)
{
	re = c.re;
	im = c.im;
	sayac++;
	cout << endl << "Kopyalama kurucu �al��t�";
	cout << "Nesne �al��t�"<<sayac;

}



ComplexT ComplexT::topla(const ComplexT& z)const
{
	cout << endl << "Toplama methodu cal���yor";
	float gecici_re, gecici_im;
	gecici_re = re + z.re;
	gecici_im = im + z.im;
	return ComplexT(gecici_re, gecici_im);
}



void ComplexT::g�ster()const
{
	cout << endl << "re=" << re << ",im=" << im;
	cout << "Nesne sayisi=" << sayac;

}


