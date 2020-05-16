#include "iostream" 
#include "math.h" 
#include "stdafx.h"


using namespace std;


float fun(float x)
{
	float F = x/1+x;
	return F;
}

int main()
{
	setlocale(LC_ALL, "rus");
	float h, epsR, epsC;
	int n;
	cout << "Количество точек: "; cin >> n;
	h = 2 / (n - 1);                                                                           //шаг 


	float** ravn = new float* [n];
	for (int i = 0; i < n; i++) ravn[i] = new float[3];
	float** cheb = new float* [n];
	for (int i = 0; i < n; i++) cheb[i] = new float[3];

	for (int i = 0; i < n; i++)                                                              //вычисление Х
	{
		ravn[i][0] = -1 + i * h;
		ravn[i][1] = fun(ravn[i][0]);
		cheb[i][0] = cos((2 * i + 1) * 3.141598 / 2 / n);
		cheb[i][1] = fun(cheb[i][0]);
	}

	for (int i = 0; i < n; i++)                                                                   //вычисление y/лямбду (3 столбец)
	{
		float P = 1;
		for (int j = 0; j < n; j++) { if (i != j) { P *= (ravn[i][0] - ravn[j][0]); } }
		ravn[i][2] = ravn[i][1] / P;
		P = 1;
		for (int j = 0; j < n; j++) { if (i != j) { P *= (cheb[i][0] - cheb[j][0]); } }
		cheb[i][2] = cheb[i][1] / P;
	}

	cout << "\n\n P1(x) = ";                                                             //вывод полиномов
	for (int i = 0; i < n; i++)
	{
		if (ravn[i][2] > 0) cout << "+";
		cout << ravn[i][2] << "*";
		for (int j = 0; j < n; j++) { if (i != j) { cout << "(x-" << ravn[j][0] << ")"; } }
	}
	cout << "\n\n\n P2(x) = ";
	for (int i = 0; i < n; i++)
	{
		cout << cheb[i][2] << "*";
		for (int j = 0; j < n; j++) { if (i != j) { cout << "(x-" << cheb[j][0] << ")"; } }
	}

	for (float i = -1; i < 1.1; i += 0.1)                                                                   //погрешность
	{
		float P = 0, C = 0, Q;
		for (int j = 0; j < n; j++)
		{
			Q = 1;
			for (int k = 0; k < n; k++) { if (k != j) { Q *= (i - ravn[j][0]); } }
			P += ravn[j][2] * Q;
			Q = 1;
			for (int k = 0; k < n; k++) { if (k != j) { Q *= (i - cheb[j][0]); } }
			C += cheb[j][2] * Q;
		}
		if (i == -1)
		{
			epsR = abs(fun(i) - P);
			epsC = abs(fun(i) - C);
		}
		else
		{
			if (epsR < abs(fun(i) - P)) epsR = abs(fun(i) - P);
			if (epsC < abs(fun(i) - C)) epsC = abs(fun(i) - C);
		}
	}
	cout << "\n\nПогрешность на равномерной сетке: " << epsR;
	cout << "\nПогрешность на Чебышевской сетке: " << epsC;

	system("pause");
}