// ConsoleApplication2.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include <iostream>
#include <string.h>
#include <ctime>
using namespace std;

class CStr
{
private:
	char *s;

	//private-����� ��� ��������� ��������� �����
	void rndm(int n)
	{
		for (int i = 0; i < n; i++)
			s[i] = 97 + rand() % 26;
		s[n] = 0;
	}

public:
	CStr() { s = NULL; } //����������� �� ���������

    //����������� � ���������� �������
	CStr(char *str)
	{
		s = new char[strlen(str) + 1];
		strcpy(s, str);
	}

	//����������� � ���������� ������ ������ ������������ private-�����
	CStr(int n)
	{
		s = new char[n + 1];
		rndm(n);
	}

	//����������� �����
	CStr(CStr &str)
	{
		s = new char[strlen(str.s) + 1];
		strcpy(s, str.s);
	}

	//�������� ��������� �� �� ����������� 
	bool operator > (CStr &b)
	{
		if (strcmp(s, b.s) > 0) return true;
		return false;
	}

	//�������� ������������ �������
	CStr& operator=(CStr &b)
	{
		if (this != &b) {
			delete[] s;
			s = new char[strlen(b.s) + 1];
			strcpy(s, b.s);
			return *this;
		}
	}

	//�������� ������������ ������
	CStr& operator=(char *str)
	{
		if (s != str)
			delete[] s;
		s = new char[strlen(str) + 1];
		strcpy(s, str);
		return *this;
	}

	int gl()
	{
		return strlen(s);
	}

	//friend-�������� ������ � �����
	friend ostream& operator << (ostream& os, const CStr& b) { os << b.s; return os; }

	//����������
	~CStr() { if (s) delete[]s; }
};


class CStrArray
{
private:
	CStr **Mass; int len;
public:
	
	//����������� � ���������� ����� �������
	CStrArray(int l) 
	{
		Mass = new CStr*[l]; len = l; for (int i = 0; i < l; i++) 
																  
		{
			Mass[i] = new CStr(1 + rand() % 20);
		} 
	}
	
	//���������� ������ 
	void add() 
	{
		CStr **tmp = new CStr*[len + 1];
		for (int i = 0; i < len; i++) { tmp[i] = Mass[i]; }
		tmp[len] = new CStr(1 + rand() % 20);
		len++;
		delete[] Mass; Mass = tmp;
	}
	
	//�������� ����������
	CStr*& CStrArray::operator[](int i) { return Mass[i]; }
	
	friend ostream& operator<< (ostream& os, CStrArray& b)
	{
		if (b.len <= 50) { for (int i = 0; i < b.len; i++) os << *b[i] << endl; }
		else os << "Mass > 50"; return os;
	}
	
	//���������� �� ��������
	void sortV() 
	{
		int j; CStr *z;
		for (int i = 0; i < (len - 1); i++) {
			
			j = i; z = Mass[i + 1]; while (j >= 0 && *Mass[j] > *z)
			{
				Mass[j + 1] = Mass[j]; j = j - 1;
			}
			Mass[j + 1] = z;
		}
	}
	
	//���������� �� �����
	void sortL() 
	{
		int j; CStr *z;
		for (int i = 0; i < (len - 1); i++) {
			
			j = i; z = Mass[i + 1]; while (j >= 0 && Mass[j]->gl() > z->gl())
			{
				Mass[j + 1] = Mass[j]; j = j - 1;
			}
			Mass[j + 1] = z;
		}
	}
	
	//�������� ��������������� �� ��������
	bool TestV() 
	{
		for (int i = 0; i < (len - 1); i++)
			if (*Mass[i] > *Mass[i + 1]) return false;
		return true;
	}
	
	//�������� ��������������� �� �����
	bool TestL() 
	{
		for (int i = 0; i < (len - 1); i++)
			if (Mass[i]->gl() > Mass[i + 1]->gl()) return false;
		return true;
	}
	
	~CStrArray() { delete[] Mass; }
};


int main()
{
	srand(time(NULL));
	CStrArray a(10);
	a.add();
	a.sortL();
	cout << "Length sort" << endl;
	if (a.TestL())
		cout << a; else cout << "ERROR" << endl;
	a.sortV();
	cout << "Value sort" << endl;
	if (a.TestV())
		cout << a; else cout << "ERROR" << endl;
	cin.get();
	return 0;
}

