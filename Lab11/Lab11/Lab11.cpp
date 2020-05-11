#include "stdafx.h"
#include <string.h>
#include <iostream>

#define MAXLEN 20

using namespace std;

class CStr
{
	char * s;
	void gen(int l) { for (int i = 0; i < l; i++) s[i] = 'a' + rand() % 26; s[l] = 0; }
public:
	CStr() { s = NULL; }
	CStr(char *str) { s = new char[strlen(str) + 1]; strcpy(s, str); }
	CStr(int);
	CStr(const CStr &C) { if (C.s) { s = new char[strlen(C.s) + 1]; strcpy(s, C.s); } else s = NULL; }
	CStr& operator=(CStr&);
	CStr& operator=(char*);
	CStr& operator+(CStr&);
	bool operator<(CStr &C) { if (strcmp(s, C.s) < 0) return true; return false; }
	bool operator>(CStr &C) { if (strcmp(s, C.s) > 0) return true; return false; }
	friend ostream& operator<< (ostream& os, const CStr& C) { if (C.s) os << C.s; return os; };
	int get_len() { if (s) return strlen(s); else return 0; }
	~CStr() { if (s) delete[] s; }
};

CStr::CStr(int len) {
	if ((len <= MAXLEN) && (len >= 0))
	{
		if (len > 0)
		{
			s = new char[len + 1];
			gen(len);
		}
		else s = NULL;
	}
	else
	{
		cout << "¬веденное число не входит в диапозон допустимых значений" << endl;
		exit(1);
	}
};

CStr& CStr::operator=(CStr& C) {
	delete[] s;
	s = NULL;
	if (C.s) {
		s = new char[strlen(C.s) + 1];
		strcpy(s, C.s);
	}
	return *this;
}

CStr& CStr::operator=(char* str) {
	delete[] s;
	s = NULL;
	if (str) {
		s = new char[strlen(str) + 1];
		strcpy(s, str);
	}
	return *this;
}

CStr& CStr::operator+(CStr& C) {
	if (s)
	{
		if (C.s)
		{
			char* temp = new char[strlen(s) + strlen(C.s) + 1];
			strcpy(temp, s);
			strcpy(temp + strlen(s), C.s);
			return *(new CStr(temp));
		}
		else return *this;
	}
	else return C;
};

template <class T> class TVector
{
	T * data;
	int size;
public:
	TVector() { size = 0; data = NULL; }

	TVector(int n) { data = new T[n]; size = n; }

	TVector(TVector&v) {
		size = v.size;
		data = new T[size];
		for (int i = 0; i < size; i++) data[i] = v.data[i];
	}

	T& operator[](int i) {
		if (i < 0) i = 0;
		if (i >= size) i = size;
		return data[i];
	}

	TVector<T>& operator=(TVector<T>& C) {
		if (this == &C) return *this;
		if (size == C.size)
			for (int i = 0; i < size; i++) data[i] = C.data[i];
		return *this;
	}

	TVector<T> operator+(TVector<T>& C) {
		TVector temp(size);
		for (int i = 0; i < size; i++) temp[i] = data[i] + C[i];
		return temp;
	}

	void setLength(int n)
	{
		if (data) delete[] data;
		size = n;
		data = new T[n];
	}

	friend ostream& operator<<(ostream &os, TVector<T> &TV) {
		for (int i = 0; i < TV.size; i++) os << TV[i] << " ";
		os << endl;
		return os;
	}

	~TVector() { delete[] data; }
};


template <class T> class TMatrix
{
	int row, col;
	TVector<T> *data;
public:
	TMatrix(int r, int c) {
		row = r; col = c;
		data = new TVector<T>[row];
		for (int i = 0; i < row; i++)
			data[i].setLength(col);
	}

	TMatrix(TMatrix &m) {
		row = m.row; col = m.col;
		data = new TVector<T>[row];
		for (int i = 0; i < row; i++)
		{
			data[i].setLength(col);
			data[i] = m.data[i];
		}
	}

	TVector<T>& operator[](int i) {
		if (i < 0) i = 0;
		if (i >= row) i = row;
		return data[i];
	}

	TMatrix operator+(TMatrix& M) {
		TMatrix<T> temp(row, col);
		for (int i = 0; i < row; i++) temp[i] = data[i] + M[i];
		return temp;
	}

	TMatrix& operator=(TMatrix& M) {
		if (this == &M) return *this;
		for (int i = 0; i < row; i++) data[i] = M[i];
		return *this;
	}

	template <class T>
	friend ostream& operator<<(ostream &os, TMatrix<T> &m) {
		os << "TMatrix row=" << m.row << " col=" << m.col << endl << ' ';
		for (int i = 0; i < m.row; i++) os << m[i] << " ";
		os << endl;
		return os;
	}

	~TMatrix() { delete[] data; }
};




int main()
{
	TMatrix<int> M1(5, 5), M2(5, 5), M3(5, 5);
	for (int i = 0; i < 5; i++)
		for (int j = 0; j < 5; j++) {
			M1[i][j] = rand() % 10 + 1;
			M2[i][j] = 1;
		}
	M3 = M1 + M2;//M1 - матрица случайных чисел от 1 до 10, M2 - матрица из единиц
	cout << M1 << M2 << M3;
	TVector<char> V1(10), V2(10), V3(10);
	for (int i = 0; i < 10; i++)
	{
		V1[i] = 'a' + rand() % 26;
		V2[i] = '1';
	}
	V3 = V1 + V2;
	cout << V1 << V2 << V3 << endl;//V1 - вектор случайных символов английского алфавита, V2 - вектор из "1"

	TVector<CStr> C1(3), C2(3), C3(3);
	C1[0] = "qwe"; C2[0] = "123";
	C1[1] = "rty"; C2[1] = "456";
	C1[2] = "asd"; C2[2] = "789";
	C3 = C1 + C2;
	cout << C1 << C2 << C3;
	return 0;
}