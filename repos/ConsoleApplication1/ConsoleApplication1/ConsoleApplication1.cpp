#include<iostream>
#include<string>


using namespace std;

class Teacher {
	string name;
	int numOfStudents;
public:
	Teacher(const string& new_name, int nos) {
		name = new_name;
		numOfStudents = nos;
	}
	virtual void print() const;
};
void Teacher::print() const {
	cout << "Name:" << name << endl;
	cout << "Num of Students:" << numOfStudents << endl;
}

class Principal :public Teacher {
	string SchoolName;
public:
	Principal(const string& new_name, int nos, const string& sn)
		:Teacher(new_name, nos)
	{
		SchoolName = sn;
	}
	void print() const;
};

void Principal::print() const
{
	Teacher::print();
	cout << "Name of School:" << SchoolName << endl;
}

void show(const Teacher* tp)
{
	tp->print();
}

int main()
{
	Teacher t1("Teacher 1", 50);
	Principal p1("Principal 1", 40, "School");
	Teacher* ptr;
	char c;
	cout << "Teacher or Principal";
	cin >> c;
	if (c == 't') ptr = &t1;
	else ptr = &p1;
	show(ptr);
	return 0;
}





