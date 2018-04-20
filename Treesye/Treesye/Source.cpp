#include <iomanip>
#include <iostream>
#include<stdio.h>
#include<stdlib.h>
#include<time.h>
#include<memory.h>
#include <cstdlib>
#include <ctime>
using namespace std ;
class RBtree {
	struct node_st { node_st *p1, *p2; int value; bool red; }; // структура узла
	node_st *tree_root;                 //!< корень
	int nodes_count;                    //!< число узлов дерева
private:
	node_st *NewNode(int value);        //!< выделение новой вешины
	void DelNode(node_st*);             //!< удаление вершины
	void Clear(node_st*);               //!< снос дерева (рекурсивная часть)
	node_st *Rotate21(node_st*);        //!< вращение влево
	node_st *Rotate12(node_st*);        //!< вращение вправо
	void BalanceInsert(node_st**);      //!< балансировка вставки
	bool BalanceRemove1(node_st**);     //!< левая балансировка удаления
	bool BalanceRemove2(node_st**);     //!< правая балансировка удаления
	bool Insert(int, node_st**);         //!< рекурсивная часть вставки
	bool GetMin(node_st**, node_st**);   //!< найти и убрать максимальный узел поддерева
	bool Remove(node_st**, int);         //!< рекурсивная часть удаления
public: // отладочная часть
	enum check_code { error_balance, error_struct, ok }; // код ошибки
	void Show();                        //!< вывод дерева
	//check_code Check();                 //!< проверка дерева
	//bool TreeWalk(bool*, int);           //!< обход дерева и сверка значений с массивом
private: // отладочная часть
	void Show(node_st*, int, char);       //!< вывод дерева, рекурсивная часть
	check_code Check(node_st*, int, int&);//!< проверка дерева (рекурсивная часть)
	//bool TreeWalk(node_st*, bool*, int);  //!< обход дерева и сверка значений с массивом (рекурсивная часть)
public:
	RBtree();
	~RBtree();
	void Clear();           //!< снести дерево              
	bool Find(int);         //!< найти значение
	void Insert(int);       //!< вставить значение
	void Remove(int);       //!< удалить значение
	int GetNodesCount();    //!< узнать число узлов
};
RBtree::RBtree()
{
	tree_root = 0;
	nodes_count = 0;
}
RBtree::~RBtree()
{
	Clear(tree_root);
}
int RBtree::GetNodesCount()
{
	return nodes_count;
}
// выделение новой вешины
RBtree::node_st *RBtree::NewNode(int value)
{
	nodes_count++;
	node_st *node = new node_st;
	node->value = value;
	node->p1 = node->p2 = 0;
	node->red = true;
	return node;
}
// удаление вершины
void RBtree::DelNode(node_st *node)
{
	nodes_count--;
	delete node;
}
// снос дерева (рекурсивная часть)
void RBtree::Clear(node_st *node)
{
	if (!node) return;
	Clear(node->p1);
	Clear(node->p2);
	DelNode(node);
}
// вывод дерева, рекурсивная часть
//! \param node узел
//! \param depth глубина
//! \param dir   значёк
//! \code Show(root,0,'*'); \endcode
void RBtree::Show(node_st *node, int depth, char dir)
{
	int n;
	if (!node) return;
	for (n = 0; n<depth; n++) putchar(' ');
	printf("%c[%d] (%s)\n", dir, node->value, node->red ? "red" : "black");
	Show(node->p1, depth + 2, '-');
	Show(node->p2, depth + 2, '+');
}
// вращение влево
//! \param index индеск вершины
//! \result новая вершина дерева
RBtree::node_st *RBtree::Rotate21(node_st *node)
{
	node_st *p2 = node->p2;
	node_st *p21 = p2->p1;
	p2->p1 = node;
	node->p2 = p21;
	return p2;
}
// вращение вправо
//! \param index индеск вершины
//! \result новая вершина дерева
RBtree::node_st *RBtree::Rotate12(node_st *node)
{
	node_st *p1 = node->p1;
	node_st *p12 = p1->p2;
	p1->p2 = node;
	node->p1 = p12;
	return p1;
}
// балансировка вершины
void RBtree::BalanceInsert(node_st **root)
{
	node_st *p1, *p2, *px1, *px2;
	node_st *node = *root;
	if (node->red) return;
	p1 = node->p1;
	p2 = node->p2;
	if (p1 && p1->red) {
		px2 = p1->p2;             // задача найти две рядом стоящие крастне вершины
		if (px2 && px2->red) p1 = node->p1 = Rotate21(p1);
		px1 = p1->p1;
		if (px1 && px1->red) {
			node->red = true;
			p1->red = false;
			if (p2 && p2->red) { // отделаемся перекраской вершин
				px1->red = true;
				p2->red = false;
				return;
			}
			*root = Rotate12(node);
			return;
		}
	}
	// тоже самое в другую сторону
	if (p2 && p2->red) {
		px1 = p2->p1;             // задача найти две рядом стоящие крастне вершины
		if (px1 && px1->red) p2 = node->p2 = Rotate12(p2);
		px2 = p2->p2;
		if (px2 && px2->red) {
			node->red = true;
			p2->red = false;
			if (p1 && p1->red) { // отделаемся перекраской вершин
				px2->red = true;
				p1->red = false;
				return;
			}
			*root = Rotate21(node);
			return;
		}
	}
}
bool RBtree::BalanceRemove1(node_st **root)
{
	node_st *node = *root;
	node_st *p1 = node->p1;
	node_st *p2 = node->p2;
	if (p1 && p1->red) {
		p1->red = false; return false;
	}
	if (p2 && p2->red) { // случай 1
		node->red = true;
		p2->red = false;
		node = *root = Rotate21(node);
		if (BalanceRemove1(&node->p1)) node->p1->red = false;
		return false;
	}
	unsigned int mask = 0;
	node_st *p21 = p2->p1;
	node_st *p22 = p2->p2;
	if (p21 && p21->red) mask |= 1;
	if (p22 && p22->red) mask |= 2;
	switch (mask)
	{
	case 0:     // случай 2 - if((!p21 || !p21->red) && (!p22 || !p22->red))
		p2->red = true;
		return true;
	case 1:
	case 3:     // случай 3 - if(p21 && p21->red)
		p2->red = true;
		p21->red = false;
		p2 = node->p2 = Rotate12(p2);
		p22 = p2->p2;
	case 2:     // случай 4 - if(p22 && p22->red)
		p2->red = node->red;
		p22->red = node->red = false;
		*root = Rotate21(node);
	}
	return false;
}
bool RBtree::BalanceRemove2(node_st **root)
{
	node_st *node = *root;
	node_st *p1 = node->p1;
	node_st *p2 = node->p2;
	if (p2 && p2->red) { p2->red = false; return false; }
	if (p1 && p1->red) { // случай 1
		node->red = true;
		p1->red = false;
		node = *root = Rotate12(node);
		if (BalanceRemove2(&node->p2)) node->p2->red = false;
		return false;
	}
	unsigned int mask = 0;
	node_st *p11 = p1->p1;
	node_st *p12 = p1->p2;
	if (p11 && p11->red) mask |= 1;
	if (p12 && p12->red) mask |= 2;
	switch (mask) {
	case 0:     // случай 2 - if((!p12 || !p12->red) && (!p11 || !p11->red))
		p1->red = true;
		return true;
	case 2:
	case 3:     // случай 3 - if(p12 && p12->red)
		p1->red = true;
		p12->red = false;
		p1 = node->p1 = Rotate21(p1);
		p11 = p1->p1;
	case 1:     // случай 4 - if(p11 && p11->red)
		p1->red = node->red;
		p11->red = node->red = false;
		*root = Rotate12(node);
	}
	return false;
}
bool RBtree::Find(int value)
{
	node_st *node = tree_root;
	while (node) {
		if (node->value == value) return true;
		node = node->value>value ? node->p1 : node->p2;
	}
	return false;
}
// рекурсивная часть вставки
//! \result true если изменений небыло или балансировка в данной вершине не нужна
bool RBtree::Insert(int value, node_st **root)
{
	node_st *node = *root;
	if (!node) *root = NewNode(value);
	else {
		if (value == node->value) return true;
		if (Insert(value, value<node->value ? &node->p1 : &node->p2)) return true;
		BalanceInsert(root);
	}
	return false;
}
// найти и убрать максимальный узел поддерева
//! \param root корень дерева в котором надо найти элемент
//! \retval res эелемент который был удалён
//! \result true если нужен баланс
bool RBtree::GetMin(node_st **root, node_st **res)
{
	node_st *node = *root;
	if (node->p1) {
		if (GetMin(&node->p1, res)) return BalanceRemove1(root);
	}
	else {
		*root = node->p2;
		*res = node;
		return !node->red;
	}
	return false;
}
bool RBtree::Remove(node_st **root, int value)
{
	node_st *t, *node = *root;
	if (!node) return false;
	if (node->value<value) {
		if (Remove(&node->p2, value)) return BalanceRemove2(root);
	}
	else if (node->value>value) {
		if (Remove(&node->p1, value)) return BalanceRemove1(root);
	}
	else {
		bool res;
		if (!node->p2) {
			*root = node->p1;
			res = !node->red;
		}
		else {
			res = GetMin(&node->p2, root);
			t = *root;
			t->red = node->red;
			t->p1 = node->p1;
			t->p2 = node->p2;
			if (res) res = BalanceRemove2(root);
		}
		DelNode(node);
		return res;
	}
	return 0;
}
void RBtree::Show()
{
	printf("[tree]\n");
	Show(tree_root, 0, '*');
}

// функция вставки
void RBtree::Insert(int value)
{
	Insert(value, &tree_root);
	if (tree_root) tree_root->red = false;
}
void RBtree::Remove(int value)
{
	Remove(&tree_root, value);
}
void RBtree::Clear()
{
	Clear(tree_root);
	tree_root = 0;
}
 int main()
{
	int r = 10;
	RBtree tree1;
	RBtree tree2;
     tree1.Insert(10);
	 tree1.Insert(15);
	 tree1.Insert(9);
	 tree1.Insert(3);
	 tree1.Insert(5);
	 tree1.Insert(89);
	 tree1.Insert(101);
	 tree1.Insert(108);
	 tree1.GetNodesCount();
	 tree1.Show();
	 tree1.Remove(10);
	 tree1.Show();
	int i =  tree1.Find(15);
	if (i == 1)
		printf("Thanks for found    ");
	cout << endl;
	//clock_t cl;     //initializing a clock type
	//cl = clock();   //starting time of clock
	int arr[10000];
	for (int i = 0; i < 10000; i++)
		arr[i] = rand() % 100000;
	srand(time(0));
	for (int i = 0; i < 10000; i++)
	tree2.Insert(arr[i]);
	long double sy = clock();
	cout << "Time elapsed with inserting : " << sy/1000  << endl;
	for (int i = 0; i < 10000; i++)
		tree2.Find(arr[i]);
	long double time1 = clock();
	cout << "Time elapsed with searching : " << (time1-sy) / 1000 << endl;
	for (int i = 0; i < 10000; i++)
	tree2.Remove(arr[i]);
	long double time = clock();
	cout << "Time elapsed with deleting : " << (time-time1) / 1000 << endl;
	//for (int i = 0; i < 10000; i++)
	//	arr[i] = rand() % 100000;
	//long double sy = clock();
//	unsigned int search_time = end_time - start_time; 
	//cout << "Time elapsed with inserting" << search_time << endl;
	system("pause");
}