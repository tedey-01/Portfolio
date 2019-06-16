#include "stdafx.h"
#include <iostream>

using namespace std;
int limit = INT_MAX-1;


class node
{
public:
	int key;					//ключ
	node *rbro;					//праваый брат 
	node *lson;					//левый сын
	node *par;					//родитель 
};

class tree
{
private:
	node * root;
	int count;
public:
	tree() { root = NULL; count = 0; }							//конструктор по умолчанию 
	void add(int data);											//добавление эл в дерево
	void pre_order(node *p = NULL);								//прямой обход
	void in_order(node *p = NULL);								//симметричный обход
	void post_order(node *p = NULL);							//обратный обход 
	void remove(int data);										//удаление эл
	void intersection(tree *A, tree *B, node *p = NULL);		//пересечение  
	void pumping(tree *A = NULL, node *p = NULL);				//объединение 
	bool check(int data, node  *p = NULL, bool *flag = NULL);	//проверка дерева на наличие определённого узла 
};

//data-добавляемое значение
void tree::add(int data)
{
	node *p = new node;
	if (root == NULL)
	{
		root = p; root->key = data;	root->par = NULL;
		root->rbro = NULL; root->lson = NULL;
	}
	else
	{
		p = root;
		node *temp = p;
		while (p != NULL)
		{
			if (data < p->key)
			{
				if (p->lson != NULL && p->lson->key == limit)
				{

					temp = p;
					p = p->lson->lson;

				}
				else
				{
					temp = p;
					p = p->lson;
				}
			}
			else if (data > p->key)
			{
				temp = p;
				if (p->lson != NULL)
					p = p->lson->rbro;
				else
				{
					node *bug = new node;
					bug->key = limit; bug->lson = NULL; bug->par = p; bug->rbro = NULL;
					p->lson = bug;
					p = p->lson->rbro;
				}
			}
			else if (data == p->key)
			{
				temp = NULL;
				p = NULL;
			}
		}

		if (temp != NULL && temp->key > data)
		{
			node *t = new node;
			t->key = data; t->par = temp; t->lson = NULL; t->rbro = NULL;
			if (temp->lson != NULL && temp->lson->rbro != NULL) t->rbro = temp->lson->rbro;
			temp->lson = t;
			
		}
		else if (temp != NULL && temp->key < data)
		{
			node *t = new node;
			t->key = data; t->par = temp; t->lson = NULL; t->rbro = NULL;
			temp->lson->rbro = t;
			
		}
	}
	count++;
}

//p-указатель предназначенный для правильной работы рикурсивных вызовов (метод вызывается без параметров)
void tree::pre_order(node *p)
{
	if (p == NULL)
		p = root;
	if (p != NULL)
	{
		if (p->key != limit)
			cout << p->key << endl;
		if (p->lson != NULL)
			pre_order(p->lson);
		if (p->lson != NULL && p->lson->rbro != NULL)
			pre_order(p->lson->rbro);
	}
}

//p-указатель предназначенный для правильной работы рикурсивных вызовов (метод вызывается без параметров)
void tree::in_order(node *p)
{
	if (p == NULL)
		p = root;
	if (p != NULL)
	{
		if (p->lson != NULL)
			in_order(p->lson);
		if (p->key != limit)
			cout << p->key << endl;
		if (p->lson != NULL && p->lson->rbro != NULL)
			in_order(p->lson->rbro);
	}
}

//p-указатель предназначенный для правильной работы рикурсивных вызовов (метод вызывается без параметров)
void tree::post_order(node *p)
{
	if (p == NULL)
		p = root;
	if (p != NULL)
	{
		if (p->lson != NULL)
			post_order(p->lson);
		if (p->lson != NULL && p->lson->rbro != NULL)
			post_order(p->lson->rbro);
		if (p->key != limit)
			cout << p->key << endl;
	}
}

//data-удаляемое значение
void tree::remove(int data)
{
	node *p = new node;
	p = root;
	//находим эл., который надо удалить
	while (p != NULL && p->key != data)
	{
		if (p->lson != NULL && data > p->key)
			p = p->lson->rbro;
		else
			p = p->lson;
	}
	if (p == NULL)
		return;
	//поиск кандидатов на замену. Самый правый потомок левого сына и заменяем
	if (p->lson != NULL && p->lson->key != limit)
	{
		node *temp = new node;
		temp = p->lson;
		while (temp->lson != NULL && temp->lson->rbro != NULL)
		{
			temp = temp->lson->rbro;
		}

		//если нашёлся правый потомок
		if (temp->key > temp->par->key)
		{
			p->key = temp->key;
			temp->par->lson->rbro = NULL;
		}
		//если и леевых потомков нет создаём фейкового левого потомка и создаём вязь с прывым братом левого сына удаляемого эл, чтобы связь не нарушилась
		else
		{
			if (temp->lson == NULL)							 
			{							
				node *t = new node;
				t->key = limit;
				t->lson = NULL;
				t->par = temp;
				t->rbro = temp->rbro;
				temp->lson = t;
			}
			//создаём cвязь с прывым братом левого сына удаляемого эл, чтобы связь не нарушилась
			else								
			{
				temp->lson->rbro = temp->rbro;
			}
			temp->rbro = p->rbro;
			temp->par = p->par;
			if (p->key > p->par->key)
				p->par->lson->rbro = temp;
			else
				p->par->lson = temp;
		}
	}
	else if (p->lson != NULL && p->lson->key == limit)
	{
		if (p->key > p->par->key)
		{
			p->par->lson->rbro = p->lson->rbro;
			p->lson->rbro->par = p->par;
		}
		else
		{
			p->par->lson = p->lson->rbro;
			p->lson->rbro = p->rbro;
			p->lson->rbro->par = p->par;
		}
	}
	else
	{
		if (p->rbro != NULL)
			p->key = limit;
		else if (p->key > p->par->key)
		{
			p->par->lson->rbro = NULL;
			p = NULL;
		}
		else
		{
			p->par->lson = NULL;
			p = NULL;
		}
	}

}

//дерео A-очищаемое дерево (над которым проводятся действия), дерево B-содержит множество элементов, с которым проводится сравнение , p-указатель предназначенный для правильной работы рикурсивных вызовов (метод вызывается без эотго параметра)
void tree::intersection(tree *A, tree *B, node *p)
{
	if (p == NULL)
		p = root;
	if (p != NULL)
	{
		if (p->lson != NULL)
			intersection(A, B, p->lson);

		if (p->lson != NULL && p->lson->rbro != NULL)
			intersection(A, B, p->lson->rbro);
		if (p->key != limit)
		{
			int temp = 0;
			temp = B->check(p->key);
			if (!(temp))
				A->remove(p->key);
		}
	}

}

//A-дерево в которое требуется сохранить результат объединения,  p-указатель предназначенный для правильной работы рикурсивных вызовов (метод вызывается без эотго параметра)
void tree::pumping(tree *A, node *p)
{
	if (p == NULL)
		p = root;
	if (p != NULL)
	{
		if (p->key != limit)
			A->add(p->key);
		if (p->lson != NULL)
			pumping(A, p->lson);
		if (p->lson != NULL && p->lson->rbro != NULL)
			pumping(A, p->lson->rbro);
	}
}

//data-значение которое необходимо проверить,  p и flag -указатели предназначенные для правильной работы рикурсивных вызовов (метод вызывается без эотих параметров) 
bool tree::check(int data, node *p, bool *flag)
{
	if (p == NULL)
	{
		p = root;
		bool fl = 0;
		flag = &fl;
	}
	if (p != NULL)
	{
		if (p->lson != NULL)
			check(data, p->lson, flag);
		if (p->lson != NULL && p->lson->rbro != NULL)
			check(data, p->lson->rbro, flag);
		if (data == p->key)
		{
			*flag = true;
		}
	}
	if (p->key == root->key)
	{
		return *flag;
	}
}


int main()
{
	setlocale(LC_ALL, "rus");
	tree kedr, dub;
	int n, m;
	cout << "Ввелите количество элементов в первом дереве: ";
	cin >> n;
	cout << "Введите элементы первого дерева: ";
	for (int temp, i = 0; i < n; i++)
	{
		cin >> temp;
		kedr.add(temp);
	}
	cout << "Ввелите количество элементов во втором дереве: ";
	cin >> m;
	cout << "Введите элементы второго дерева: ";
	for (int temp, i = 0; i < m; i++)
	{
		cin >> temp;
		dub.add(temp);
	}
	cout << "kedtr----------------------" << endl;
	kedr.in_order();
	cout << "dub----------------------" << endl;
	dub.post_order();
	cout << "NEWkedtr----------------------" << endl;
	kedr.intersection(&kedr, &dub);
	kedr.in_order();

	system("pause");
	return 0;
}

