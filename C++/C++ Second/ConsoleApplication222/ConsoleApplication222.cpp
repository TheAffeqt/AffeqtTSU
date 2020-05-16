#include "stdafx.h"
#include <iostream>
#include <string.h>
#include <ctime>
#include <fstream>
#include <map>
using namespace std;

class SuppBase
{
public:
	virtual int get() = 0;
};

class SuppKbrd : public SuppBase
{
public:
	int get() { int i; cin >> i; return i; }
};

class SuppFile : public SuppBase
{
	ifstream f;
public:
	SuppFile(char *fname) { f.open(fname, ios_base::in); }
	~SuppFile() { f.close(); }
	int get() { int i; f >> i; return i; }
};

class SuppQueue : public SuppBase
{
	int *que, pos;
public:
	SuppQueue(int n)
	{
		pos = 0;
		que = new int[n + 1];
		for (int j = 0; j < n; j++)
			que[j] = 1 + rand() % 30;
		que[n] = 0;
	}
	~SuppQueue() { delete[] que; }
	int get()
	{
		int i;
		i = que[pos];
		pos++;
		return i;
	}
};

class Freq
{
	map<int, int> m;
public:
	void Calc(SuppBase &sup)
	{
		int get = sup.get();
		for (int j = 1; j < 31; j++)
			m[j] = 0;
		while (get != 0)
		{
			m[get]++; get = sup.get();
		}
	}
	friend  ostream& operator<<(ostream& os, Freq &obj) {
		map<int, int> ::iterator it = obj.m.begin();
		for (it; it != obj.m.end(); it++)
			os << "Value " << it->first << " - Count " << it->second << endl;
		return os;
	}
};

class Diap : public Freq
{
	int min, max, sum;
public:
	void Calc(SuppBase &sup)
	{
		int get2 = sup.get();
		min = get2;
		max = get2;
		sum = 0;
		while (get2 != 0)
		{
			if (min > get2) min = get2;
			if (max < get2) max = get2;
			sum = sum + get2;
			get2 = sup.get();
		}
	}
	friend ostream& operator<<(ostream& os, Diap &obj) {
		os << "min = " << obj.min << " max = " << obj.max << " sum = " << obj.sum << endl;
		return os;
	}
};

int main()
{
	srand(time(0));
	Freq f; Diap d;
	SuppKbrd sk, sk2;
	SuppFile sf("file.txt"), sf2("file2.txt");
	SuppQueue sq(50), sq2(50);
	cout << "FREQUENCY KEYBOARD" << endl;
	f.Calc(sk);
	cout << f;
	cout << "FREQUENCY FILE" << endl;
	f.Calc(sf);
	cout << f;
	cout << "FREQUENCY MASSIV" << endl;
	f.Calc(sq);
	cout << f;
	cout << "AGREGAT KEYBOARD" << endl;
	d.Calc(sk2);
	cout << d;
	cout << "AGREGAT FILE" << endl;
	d.Calc(sf2);
	cout << d;
	cout << "AGREGAT MASSIV" << endl;
	d.Calc(sq2);
	cout << d;
	system("pause");
	return 0;

}