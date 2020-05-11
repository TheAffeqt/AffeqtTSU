#include "stdafx.h"
#include <fstream>
#include <iostream>
#include "cmath"
#include <stdio.h>
using namespace std;


double det(double **arr, int n)
{
	int i = 0, r = n, p = 1, v;
	double eps = 0.00001, z, c;
	while (i < r)
	{
		v = i;
		for (int j = i + 1; j < n; j++)

			if (abs(arr[j][i]) > abs(arr[v][i])) v = j;

		if (abs(arr[v][i]) < eps) r = i; 
		else
		{
			if (v != i)
			{
				p = -p;
				for (int j = i; j <= n; j++)
				{
					z = arr[i][j];
					arr[i][j] = arr[v][j];
					arr[v][j] = z;
				}
			}

			for (int k = i + 1; k < n; k++)
			{
				c = arr[k][i] / arr[i][i];
				for (int j = i; j < n; j++) arr[k][j] = arr[k][j] - c*arr[i][j];
			}
			i = i + 1;
		}
	}

	double x;
	if (r < n)
	{
		x = 0;
	}
	else
	{
		x = p*arr[0][0];
		for (int i = 1; i < n; i++) x *= arr[i][i];
	}
	return x;
}


void inv(float **A, float** D, int n) {
	int i = 0, r = n, v;
	float z, eps = 0.00001;
	float aii, c;
	while (i < r)
	{
		v = i;
		for (int j = i + 1; j < n; j++)
			if (abs(A[j][i]) > abs(A[v][i])) v = j;
		if (abs(A[v][i]) < eps) r = i;
		else
		{
			if (v != i)
			{
				for (int j = i; j < n; j++)
				{
					z = A[i][j]; A[i][j] = A[v][j]; A[v][j] = z;
				}
				for (int j = 0; j < n; j++)
				{
					z = D[i][j]; D[i][j] = D[v][j]; D[v][j] = z;
				}
			}

			aii = A[i][i];
			for (int j = i; j < n; j++)
				A[i][j] /= aii;
			for (int j = 0; j < n; j++)
				D[i][j] /= aii;

			for (int k = 0; k < n; k++)
				if (k != i)
				{
					c = A[k][i];
					for (int j = i; j < n; j++)
						A[k][j] -= c*A[i][j];
					for (int j = 0; j < n; j++)
						D[k][j] -= c*D[i][j];
				}

			i++;
		}
	}
	for (i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			cout << (round(D[i][j] * 1000) / 1000) << "  ";
		}
		cout << endl;
	}

}

int main()
  
{
	setlocale(LC_ALL, "ru");
	int n, m;
	cout << "Выберете действие: 1 (определитель) или 2 (обратная матрица)\n";
	cin >> m;
	switch (m)
	{
	case 1:
	{
		string path = "det_tests";
		fstream fs;
		fs.open(path, fstream::in | fstream::out | fstream::app);
		fs >> n;
		double **arr;
		arr = new double*[n];
		for (int i = 0; i < n; i++)
		{
			arr[i] = new double[n];
		}
		if (!fs.is_open())
		{
			cout << "Проблема с запуском файла\n";
			break;
		}
		else
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					fs >> arr[i][j];
				}
			}


			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					cout << arr[i][j] << " ";
				}
				cout << endl;
			}
			fstream fs;
			fs.open(path, fstream::in | fstream::out | fstream::app);
			double deter = det(arr, n);
			if (deter == 0) { 
			cout << "==========" << "\n";
			cout << "Матрица вырождена" << "\n";
			fs << "==========" << "\n";
			fs << "Матрица вырождена" << "\n";
			fs.close();
			break;
			}
		
			else { 	
				
				cout << "==========" << "\n";
				cout << " " << det(arr, n) << "\n";
				fs << "==========" << "\n";
				fs << " " << deter << "\n";
				fs.close();
			}

		}
		for (int i = 0; i < n; i++)
		{
			delete[] arr[i];
		}
		delete[] arr;
	}
	break;
	case 2:
	{
		string path = "reverse-test.txt";
		fstream fs;
		fs.open("reverse-test.txt", fstream:: in | fstream:: out | fstream:: app);
		fs >> n;
		float **z = new float*[n];
		for (int a = 0; a < n; a++) z[a] = new float[n];
		  for (int i = 0; i < n; i++) {
			for (int j = 0; j < n; j++) {
				fs >> z[i][j];
			}
		}
		
		float **D = new float*[n];
		for (int a = 0; a < n; a++) D[a] = new float[n];
		for (int i = 0; i < n; i++) {

			for (int j = 0; j < n; j++) {
				if (i == j) { D[i][j] = 1; }
				else {
					D[i][j] = 0;
				}
			}
		}
		
		cout << endl;
	    inv(z, D, n);
	}

	return 0;
	}
}
