#include<iostream>
#include<cmath>

//
//int Hesaplama(int);
//void Hesaplama01(int *a);
//void Fonk01(int &a);







using namespace std;
int main()
{
	/*
	string isim00 = "Hello World";
	string isim01;
	float notort = 2.95;
	isim01 = "Yasin Yumrutas";
	double pi = 3.152485624;

	cout << isim00 << "\n" << " nasil yani" << endl;

	cout << isim01 << " " << "Adli ogrencinin mezuniyet ortalamasi: " << notort << endl;

	cout << pi++;


	int alan, boy, en;
	cout << "Merhaba" << endl << "Lütfen dikdötgenin boyunu giriniz" << endl;
	cin >> boy;
	cout << "Lütfen dikdötgenin boyunu giriniz" << endl;
	cin >> en;
	alan = boy * en;
	cout << "Dikdörtgenin alani " << alan<<"metrekaredir";

	double y = ceil(2.4);
	cout << y;
	

	int sayi1, sayi2;
	cin >> sayi1 >> sayi2;
	if (sayi1 == 1)
		cout << "seçilen sayi=1";
	if (sayi2 == 2)
		cout << "seçilen sayi=2";
	else
		cout << "sayi seçilmedi";
		*/

	/*
	int x = 7;
	int* p;
	p = &x;
	
	cout << p<< endl;
	cout << *p << endl<<endl;

	x=Hesaplama(x);
	cout <<"Int fonk degeri: " << x << endl;

	Hesaplama01(p);
	cout << "Void fonk degeri: " << x << endl;

	Fonk01(x);
	cout << "main icindeki x: " << x << endl;
	*/

	/*
	int* p = new int;
	*p = 7;
	cout << p << endl;
	cout << *p << endl;
	delete p;
	*/
	//cout << *p << endl;  -----------> Burayý aktif edersen hata verir 


	/*
	int x;
	cout << "Kullanýcý dizinin kaç tane olmasini istiyorsa girsin "<<endl;
	cin >> x;
	int* p = new int[x];
	cout << "Simdide kullanici dizinin degerlerini girsin: " << endl;
	int result = 0;
	for (int i = 0;i < x;i++)
	{
		cout << "dizinin " << i << ". degerini giriniz: ";
		cin >> p[i];
		result = result + p[i];
	}
	for (int i = 0;i < x;i++)
	{
		cout<<"dizinin "<<i<<". degeri: " << p[i]<<endl;
	}
	cout << "Girilen sayilarin toplamý " << result << " dur";
	delete p;
	*/








	return 0;
}

/*

int Hesaplama(int x_)
{
	// ...
	x_ = 79;
	return x_;
}

void Hesaplama01(int *p)
{
	*p = 43;
}

void Fonk01(int &x)
{
	x = x * 2;
	cout <<"Fonk01 icindeki x: " << x << endl;
}

*/

