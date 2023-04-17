// C++_Deneme_1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

using namespace std;

class Nokta {
	int x, y;
public:
	Nokta(int, int);
	bool git(int, int);
	void göster();
};

Nokta::Nokta(int ilk_x, int ilk_y)
{
	cout << "Kurucu fonsiyon çalýþýyor" << endl;
	if (ilk_x < 0)
		x = 0;
	else
		x = ilk_x;
	if (ilk_y < 0)
		y = 0;
	else
		y = ilk_y;

}




bool Nokta::git(int yeni_x, int yeni_y)
{
	if (yeni_x >= 0 && yeni_y>=0)
	{
		x = yeni_x;
		y = yeni_y;
		return true;
	}
	return false;
}



void Nokta::göster()
{
	cout << "X=" << x << ",Y=" << y << endl;

}


int main()
{
	Nokta n1(20, 100), n2(-10, 45);
	Nokta* pn = new Nokta(10, 50);

	n1.göster();
	n2.göster();
}





// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
