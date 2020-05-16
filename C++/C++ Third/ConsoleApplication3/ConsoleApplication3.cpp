
#include "stdafx.h"
#include <iostream>
#include <string.h>
#include <ctime>
#include <sstream>
#include <stdlib.h>

template <typename T>
struct el
{
	T val;
	el *next = NULL;
};

template <typename T>
class List
{
private:
	el<T> * head;
public:
	List()
	{
		head = NULL;
	}

	el<T> * getHead()
	{
		return head;
	}

	void addElem(T arg)
	{
		if (head == NULL)
		{
			head = new el<T>;
			head->val = arg;
		}
		else
		{
			el<T> * temp = head;
			while (temp->next != NULL)
				temp = temp->next;
			temp->next = new el<T>;
			temp = temp->next;
			temp->val = arg;
		}
	}

	void merge(List& C)
	{
		if (head == NULL)
		{
			head = C.getHead();
		}
		else
		{
			el<T> * temp = head;
			while (temp->next != NULL)
				temp = temp->next;
			temp->next = C.getHead();
		}
	}
};

class Hash
{
private:
	int counter;
	int q;
	List<char**> *Table;

	int function(char* S)
	{
		int res = 0, n = strlen(S);
		for (int i = 0; i < n; i++)
			res = (res * 31 + S[i]) % q;
		return res;
	}
public:
	Hash(int n)
	{
		counter = 0;
		q = n;
		Table = new List<char**>[n];
	}

	int getCounter()
	{
		return counter;
	}

	void AddString(char** S)
	{
		int n = function(*S);
		auto temp = Table[n].getHead();
		if (temp == NULL)
			Table[n].addElem(S);
		else
		{
			bool elemNotExsists = true;
			while (elemNotExsists && temp != NULL)
			{
				counter++;
				if (strcmp(*(temp->val), *S) == 0)
					elemNotExsists = false;
				temp = temp->next;
			}
			if (elemNotExsists)
				Table[n].addElem(S);
		}
	}

	List<char**>& uniqueStrings()
	{
		for (int i = q - 1; i > 0; i--)
			Table[i - 1].merge(Table[i]);
		return Table[0];
	}
};

int main()
{
	srand(time(NULL));
	setlocale(LC_ALL, "Russian");
	int max, min, m, n, q;
	char beg, end;
	std::cout << "¬ведите число строк (не более 100000)\n";
	std::cin >> m;
	std::cout << "¬ведите минимальную и максимальную длину строки\n";
	std::cin >> min;
	std::cin >> max;
	std::cout << "¬ведите диапазон символов (в алфавитном пор€дке)\n";
	std::cin >> beg;
	std::cin >> end;

	char** S = new char*[m];
	for (int i = 0; i < m; i++)
	{
		n = rand() % (max - min + 1) + min;
		S[i] = new char[n + 1];
		int diap = end - beg + 1;
		for (int j = 0; j < n; j++)
			S[i][j] = beg + rand() % diap;
		S[i][n] = 0;
	}

	int prime_numbers[] =
	{ 1009,5003,10007,15013,
		20011,30011,35023,40009,
		45007,50021,55001,60013,
		65003,70001,75011,80021,
		85009,90001,95003,100003 };
	int i;
	for (i = 0; prime_numbers[i] < m; i++);
	q = prime_numbers[i];

	Hash H(q);
	for (int i = 0; i < m; i++)
		H.AddString(&S[i]);

	auto RES = H.uniqueStrings();
	auto temp = RES.getHead();
	int c = 0;
	while (temp != NULL)
	{
		c++;
		std::cout << *(temp->val) << std::endl;
		temp = temp->next;
	}
	std::cout << "”никальных строк - " << c << "\n";
	std::cout << "—равнений  строк - " << H.getCounter();
}
