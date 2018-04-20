#include <iostream>
#include <math.h>
using namespace std;
void solution(int, int, int, int, int, int, int, int, int);
void solution(int, int, int, int, int, int);

int main()
{
	int x, y, z, x1, y1, z1, x2, y2, z2, c;
	cout << "If you want to work in: two-demension system please put  0 ,three-demension system please put 1"  <<endl;
	cin >> c;
		if (c == 0)
		{
			cout << "Put coordinates of your first point: " << endl; cin >> x >> y;
			cout << "Put coordinates of your second point : " << endl;cin >> x1 >> y1;
			cout << "Put coordinates of your third point : " << endl;cin >> x2 >> y2;
			solution(x, y, x1, y1, x2, y2);
		}
	else if (c == 1)
	{
		cout << "Put coordinates of your first point : " << endl; cin >> x >> y >> z;
		cout << "Put coordinates of your second point : " << endl; cin >> x1 >> y1 >> z1;
		cout << "Put coordinates of your third point : " << endl; cin >> x2 >> y2 >> z2;
		solution(x, y, z, x1, y1, z1, x2, y2, z2);
	}
	if (c != 0 && c != 1)
	{
		cout << "Your data in not correct,please start this program again" << endl;
	}

	system("pause");
}
void solution(int x, int y, int z, int x1, int y1, int z1, int x2, int y2, int z2)
{
	double a;
	a = sqrt(pow((x1 - x), 2) + pow((y1 - y), 2) + pow((z1 - z), 2)) + sqrt(pow((x2 - x1), 2) + pow((y2 - y1), 2) + pow((z2 - z1), 2)) + sqrt(pow((x - x2), 2) + pow((y - y2), 2) + pow((z - z2), 2));
	cout <<"\n\n"<< "perimeter of your triangle : " << a << endl;
}
void solution(int x, int y, int x1, int y1, int x2, int y2)
{
	double a;
	a = sqrt(pow((x1 - x), 2) + pow((y1 - y), 2) ) + sqrt(pow((x2 - x1), 2) + pow((y2 - y1), 2) ) + sqrt(pow((x - x2), 2) + pow((y - y2), 2));
	cout << "\n\n" << "perimeter of your triangle : " << a << endl;
}