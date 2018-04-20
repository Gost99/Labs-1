#include <iostream>
#include <conio.h>
#include <clocale>

using namespace std;

struct elem {
	int data;
	elem *next;
};
////////////////
class spisok {
private:
	elem *first;
public:
	spisok()
	{
		first = NULL;
	}
	void add(int d);
	void display();

};
void spisok::add(int d) {
	elem *newelem = new elem;
	newelem->data = d;
	newelem->next = first;
	first = newelem;
}
void spisok::display() {
	elem *n = first;//from first
	while (n) {
		cout << n->data << endl;
		n = n->next;
}
}

int main() {
	spisok s;
	s.add(1);
	s.add(3);
	s.add(5);
	s.add(7);
	s.add(9);

	s.display();
	system("pause");

}