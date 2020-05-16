#include <iostream>
#include <math.h>
using namespace std;

double f(double x)
{
	return x / (1 + x);
}

int main() {
	setlocale(LC_ALL, "Russian");
	double a, b, eps;
	cout << "Введите нижний и верхний пределы интегрирования:\n";
	cin >> a >> b;
	eps = 0.001;
	double I = eps + 1, I1 = 0;
	for (int N = 2; (N <= 4) || (fabs(I1 - I) > eps); N *= 2)
	{
		double h, sum2 = 0, sum4 = 0, sum = 0;
		h = (b - a) / (2 * N);
		for (int i = 1; i <= 2 * N - 1; i += 2)
		{
			sum4 += f(a + h * i);
			sum2 += f(a + h * (i + 1));
		}
		sum = f(a) + 4 * sum4 + 2 * sum2 - f(b);
		I = I1;
		I1 = (h / 3) * sum;
	}
	cout << I1 << endl;
	return 0;
}