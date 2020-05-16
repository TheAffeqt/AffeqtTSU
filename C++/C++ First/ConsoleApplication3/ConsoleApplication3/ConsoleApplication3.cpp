#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <map>
#include <ctime>

using namespace std;

class SuppBase {
public:
	virtual int get() = 0;
};



class SuppFile : public SuppBase {
	ifstream fin;
	char* name;
public:
	SuppFile(char* fileName)
	{
		name = fileName;
		fin.open(name, ios::in);
	}
	int get() {
		if (!fin.eof())
		{
			int i;
			fin >> i;
			return i;
		}
		else
		{
			fin.close();
			fin.open(name, ios::in);
			return -1;
		}
	}
	~SuppFile() { fin.close(); }
};



class SuppKbrd : public SuppBase {
	int get() { int i; cin >> i; return i; }
};



class SuppQueue : public SuppBase {
	int *que, pos, len;
public:
	SuppQueue(int n) {
		pos = 0;
		len = n;
		que = new int[len];
		for (int i = 0; i < len; i++)
			que[i] = rand() % 20 + 1;
	}
	int get() {
		if (pos != len) { pos++; return que[pos - 1]; }
		else { pos = 0; return -1; }
	}
	~SuppQueue() { delete[] que; }
};



class Freq {
	map<int, int> m;
public:
	void Calc(SuppBase &sup) {
		int temp = sup.get();
		while (temp > 0) {
			m[temp]++;
			temp = sup.get();
		}
	}
	friend  ostream& operator<<(ostream& os, Freq &obj) {
		std::map<int, int>::iterator it;
		for (it = obj.m.begin(); it != obj.m.end(); it++)
			os << it->first << " - " << it->second << endl;
		return os;
	}
};


class Diap : public Freq {
	int min, max, sum;
public:
	Diap() { max = sum = 0; }
	void Calc(SuppBase &sup) {
		int temp = sup.get();
		min = temp;
		while (temp > 0) {
			sum += temp;
			if (temp < min) min = temp;
			else if (temp > max) max = temp;
			temp = sup.get();
		}
	}
	friend  ostream& operator<<(ostream& os, Diap &obj) {
		os << "min = " << obj.min << endl << "max = " << obj.max << endl << "sum = " << obj.sum << endl;
		return os;
	}
};


int main()
{
	srand(time(0));
	SuppKbrd KeyB;
	SuppFile File("DataFile.txt");
	SuppQueue Que(10);
	Diap D1, D2, D3;
	Freq F1, F2, F3;
	//------------------------------------
	cout << "Queue Diap Calc" << endl;
	D1.Calc(Que);
	cout << D1;
	//------------------------------------
	cout << "Queue Freq Calc" << endl;
	F1.Calc(Que);
	cout << F1;
	//------------------------------------
	cout << "File Diap Calc" << endl;
	D2.Calc(File);
	cout << D2;
	//------------------------------------
	cout << "File Freq Calc" << endl;
	F2.Calc(File);
	cout << F2;
	//------------------------------------
	cout << "Keyboard Diap Calc" << endl;
	D3.Calc(KeyB);
	cout << D3;
	//------------------------------------
	cout << "Keyboard Freq Calc" << endl;
	F3.Calc(KeyB);
	cout << F3;
	return 0;
}

