
#include "stdafx.h"
#include <iostream>
#include <ctime>

using namespace std;

void Sort(int* a, int size)
{
	for (int i = 0; i < size - 1; ++i) 
	{
		for (int j = 0; j < size - 1; ++j) 
		{
			if (a[j + 1] < a[j])
			{
				int t = a[j + 1];
				a[j + 1] = a[j];
				a[j] = t;
			}
		}
	}
}

int Check(int *a, int size)
{
	int i;
	for (i = 1; i < size && a[i - 1] <= a[i]; i++);
	return i >= size;
}

int main()
{
	setlocale(LC_ALL, "ru");

	int size;
	cout << "Введите длинну массива: " << endl;
	cin >> size;

	int* a = new int[size];
	srand(time(NULL));
	for (int i = 0; i < size; i++)
	{
		a[i] = -999 + rand() % (999 + 999 + 1);
	}

	cout << "\nСоздание массива:";
	for (int i = 0; i < size; i++)
	{
		
			cout << a[i]  << " ";
	}

	cout << endl;
	cout << "\nСортировка массива:" << endl;
	Sort (a, size);
	for (int i = 0; i < size; i++)
	{
		cout << a[i] << " ";
	}
	
	if (Check(a, size))
		cout << "\nМассив отсортирован верно" << endl;
	else
		cout << "\nМассив отсортирован не верно или вовсе не отсортирован" << endl;
	cout << endl;
	return 0;
}