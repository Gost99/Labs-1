#include <iostream>
using namespace std;
int main()
{
	int i,m=0,n=0;
	char z[100];
	i = rand() % 100;
	cout << "The number of leters which we would check:"<<i<<endl;
	cout << "Please enter your string"<<endl; cin >> z;
	for (int y = 0; y < i; y++) {
		if(z[y]=='*'){
			m++;
		}
		if (z[y] == '+') {
			n++;
		}
	}
	cout << "Number of + :" << n << endl;
	cout << "Number of * :" << m << endl;
	system("pause");
}
//#include <iostream>
//using namespace std;
//char s[100];
//int c(int);
//int i, m = 0, n = 0;
//char z[100];
//int main()
//{
//
//	i = rand() % 100;
//	cout << "The number of leters which we would check:" << i << endl;
//	cout << "Please enter your string" << endl; cin >> z;	
//	c(i);
//	cout << "Number of + :" << n << endl;
//	cout << "Number of * :" << m << endl;
//	system("pause");
//}
//int c(int i) {
//	if (z[i] == '*') {
//		 m++;
//	}
//	else if (z[i] == '+') {
//		 n++;
//	}
//	i--;
//	if (i != 0) {
//		c(i);
//	}
//	else {
//		return m, n;
//	}
//}