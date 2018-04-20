
#include <iostream>

using namespace std;

int main() {

	int n;
	do {
		cout << "n = ";
		cin >> n;
	} while (n < 1);

	for (int i = 2; i < n; ++i) {

		int flag = 1;
		for (int j = 2; j < i; ++j)
			if (i%j == 0 && i != j) {
				flag = 0;
				break;
			}

		if (flag == 1 && n%i == 0) {
			cout << i << endl;
			n /= i;
		}
	}
	system("pause");
}