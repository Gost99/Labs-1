#include <iostream>
using namespace std;
int main()
{
	int n,m, max ,i;
	cin >> n;
	int **Array = new int *[n];
	for (i = 0; i < n; i++) {
		Array[i] = new int[n];
	}
	for (int z = 0; z < n; z++) {
		for (int s= 0; s < n; s++) {
			Array[z][s]= rand() % 20;
		}
	}
	for (int y = 0; y < n; y++) {
		for (int u = 0; u < n; u++) {
			cout << Array[y][u]<<"    ";
		}
		cout << endl;
	}
	max = Array[0][0];
	for (int y = 0; y < n; y++) {
		for (int u = 0; u < n; u++) {

			if ((y >= u&&u <= n / 2 && y <= n / 2) || (u >= y && u <= n / 2 && y >= n / 2) || (y >= u&&u >= n / 2 && y >= n / 2) || (y <= u &&u >= n / 2 && y <= n / 2)) {
				if (Array[y][u] > max) {
					max = Array[y][u];
				}
			}

		}
	}
		cout << "MAX element :" << max;
	system("pause");
}