#include "stdafx.h"
#include <iostream>
#include <time.h>
#define type int

using namespace std;

template<typename T>
class Array
{
public:
	static void Shell(T **A, int n)
	{
		int h;
		for (h = 1; h <= n / 9; h = h * 3 + 1);
		while (h >= 1)
		{
			for (int i = h; i < n; i++)
			{
				for (int j = i - h; j >= 0 && *A[j] > *A[j + h]; j -= h)
					swap(A[j], A[j + h]);
			}
			h = (h - 1) / 3;
		}
	}

	static void quicksort(T **A, T b, T e)
	{
		T x;
		int i, j, c = b, d = e;
		while (c < d)
		{
			x = *A[(c + d) / 2];
			i = c;
			j = d;
			while (i < j)
			{
				while (*A[i] < x)
					i++;
				while (*A[j] > x)
					j--;
				if (i <= j)
				{
					swap(A[i], A[j]);
					i++;
					j--;
				}
			}
			if (j - c < d - i)
			{
				if (c < j)
					quicksort(A, c, j);
				c = i;
			}
			else
			{
				if (i < d)
					quicksort(A, i, d);
				d = j;
			}
		}
	}

	static void SiftDown(T **A, T i, T m)
	{
		T j = i, k = i * 2 + 1;
		while (k <= m)
		{
			if (k < m && *A[k] < *A[k + 1])
				k++;
			if (*A[j] < *A[k])
			{
				swap(A[j], A[k]);
				j = k;
				k = k * 2 + 1;
			}
			else break;
		}
	}

	static void HeapSort(T **A, int n)
	{
		for (int i = n / 2; i >= 0; i--)
			SiftDown(A, i, n - 1);
		for (int m = n - 1; m >= 1; m--)
		{
			swap(A[0], A[m]);
			SiftDown(A, 0, m - 1);
		}
	}

	static void Reverso(T **A, int n)
	{
		T count = n;
		for (int i = 0; i < n / 2; i++)
		{
			T *buff = A[i];
			A[i] = A[--count];
			A[count] = buff;
		}
	}

	static void ShowMass(T **A, int n)
	{
		for (int i = 0; i < n; i++)
		{
			cout << *A[i] << "  ";
		}
		cout << endl;
	}

	static void ShowMass1(T **A, int n)
	{
		for (int i = 0; i < n; i++)
		{
			cout << A[i] << endl;;
		}
		cout << endl;
	}

	static bool TestV(T **A, int n)  //Проверка упорядоченности по значению
	{
		for (int i = 0; i < (n - 1); i++)
			if (*A[i] > *A[i + 1])
				return false;
		return true;
	}
};

int main()
{
	srand(time(NULL));
	setlocale(LC_ALL, "ru");
	int N;
	cout << "Введите длину массива:";
	cin >> N;
	cout << endl;
	//Сортировка Шелла
	int *arr = new int[N];
	for (int i = 0; i < N; i++)
	{
		arr[i] = rand();
	}
	int **index = new int*[N];
	for (int i = 0; i < N; i++)
	{
		index[i] = &arr[i];
	}
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;
	cout << "Сортировка Шелла для неупорядоченного массива" << endl;

	unsigned int start_time = clock();
	Array<type>::Shell(index, N);
	unsigned int end_time = clock();
	cout << endl;
	bool Check = Array<type>::TestV(index, N);
	if (Check)
		cout << "Массив отсортирован по возрастанию" << endl;
	else
		cout << "Ошибка" << endl;

	cout << "Время работы алгоритма: " << end_time - start_time << " мс" << endl;
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;
	cout << "Сортировка Шелла для массива упорядоченного по возрастанию" << endl;

	start_time = clock();
	Array<type>::Shell(index, N);
	end_time = clock();
	cout << endl;
	Check = Array<type>::TestV(index, N);
	if (Check)
		cout << "Массив отсортирован по возрастанию" << endl;
	else
		cout << "Ошибка" << endl;

	cout << "Время работы алгоритма: " << end_time - start_time << " мс" << endl;
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;
	cout << "Сортировка Шелла для массива упорядоченного по убыванию" << endl;

	Array<type>::Reverso(index, N);
	start_time = clock();
	Array<type>::Shell(index, N);
	end_time = clock();
	cout << endl;
	Check = Array<type>::TestV(index, N);
	if (Check)
		cout << "Массив отсортирован по возрастанию" << endl;
	else
		cout << "Ошибка" << endl;
	cout << "Время работы алгоритма: " << end_time - start_time << " мс" << endl;
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;


	//Пирамидальная сортировка

	for (int i = 0; i < N; i++)
	{
		index[i] = &arr[i];
	}
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;
	cout << "Пирамидальная сортировка для неупорядоченного массива" << endl;

	start_time = clock();
	Array<type>::HeapSort(index, N);
	end_time = clock();
	cout << endl;
	Check = Array<type>::TestV(index, N);
	if (Check)
		cout << "Массив отсортирован по возрастанию" << endl;
	else
		cout << "Ошибка" << endl;

	cout << "Время работы алгоритма: " << end_time - start_time << " мс" << endl;
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;
	cout << "Пирамидальная сортировка для массива упорядоченного по возрастанию" << endl;

	start_time = clock();
	Array<type>::HeapSort(index, N);
	end_time = clock();
	cout << endl;
	Check = Array<type>::TestV(index, N);
	if (Check)
		cout << "Массив отсортирован по возрастанию" << endl;
	else
		cout << "Ошибка" << endl;

	cout << "Время работы алгоритма: " << end_time - start_time << " мс" << endl;
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;
	cout << "Пирамидальная сортировка для массива упорядоченного по убыванию" << endl;

	Array<type>::Reverso(index, N);
	start_time = clock();
	Array<type>::HeapSort(index, N);
	end_time = clock();
	cout << endl;
	Check = Array<type>::TestV(index, N);
	if (Check)
		cout << "Массив отсортирован по возрастанию" << endl;
	else
		cout << "Ошибка" << endl;

	cout << "Время работы алгоритма: " << end_time - start_time << " мс" << endl;
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;



	//Быстрая сортировка

	for (int i = 0; i < N; i++)
	{
		index[i] = &arr[i];
	}
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;
	cout << "Быстрая сортировка для неупорядоченного массива" << endl;

	start_time = clock();
	Array<type>::quicksort(index, 0, N - 1);
	end_time = clock();
	cout << endl;
	Check = Array<type>::TestV(index, N);
	if (Check)
		cout << "Массив отсортирован по возрастанию" << endl;
	else
		cout << "Ошибка" << endl;

	cout << "Время работы алгоритма: " << end_time - start_time << " мс" << endl;
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;
	cout << "Быстрая сортировка для массива упорядоченного по возрастанию" << endl;

	start_time = clock();
	Array<type>::quicksort(index, 0, N - 1);
	end_time = clock();
	cout << endl;
	Check = Array<type>::TestV(index, N);
	if (Check)
		cout << "Массив отсортирован по возрастанию" << endl;
	else
		cout << "Ошибка" << endl;

	cout << "Время работы алгоритма: " << end_time - start_time << " мс" << endl;
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;
	cout << "Быстрая сортировка для массива упорядоченного по убыванию" << endl;

	Array<type>::Reverso(index, N);
	start_time = clock();
	Array<type>::quicksort(index, 0, N - 1);
	end_time = clock();
	cout << endl;
	Check = Array<type>::TestV(index, N);
	if (Check)
		cout << "Массив отсортирован по возрастанию" << endl;
	else
		cout << "Ошибка" << endl;

	cout << "Время работы алгоритма: " << end_time - start_time << " мс" << endl;
	cout << "//////////////////////////////////////////////////////////////////////////////////////////" << endl;

	delete[] arr;
	delete[] index;
}