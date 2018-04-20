#include <iostream>
#include <stdio.h>
using namespace std;
int main()
{
	int t, i = 2;
	cout<<"imput integer number : ";
	cin >> t;
	printf("%d=1", t);
	while (t % 2 == 0)
	{
		printf("*%d", 2);
		t = t / 2;
	}
	while (i <= t)
	{
		if (t%i == 0)
		{
			printf("*%d", i);
			t = t / i;
		}
		else
			i = i + 1;
	}
	cout << endl;
	system("pause");
}