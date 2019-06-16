#include "stdafx.h"
#include <iostream>
#include <fstream>

using namespace std;


int main()
{
	int  n=0;					//кол-во вершин в гарфе 
	ifstream F;
	F.open("mat.txt", ios::in);		//в файле хранится инф. о 1) кол-ве вершин в графе; 2)сам граф. 
	F >> n;							//Граф описывается в воде списка смежности 
	if (!n)
	{
		cout << "graph not set correctly";
		system("pause");
		return 0;
	}
	bool **arr = new  bool*[n];
	int *colors = new int[n];			//массив сопоставляющий вершине цвет. 

	for (int i = 0; i < n; i++)			//считывание
	{
		arr[i] = new bool[n];
		for (int j = 0; j < n; j++)
		{
			int temp;
			F >> temp;
			arr[i][j] = bool(temp);
		}
		if (arr[i][i] == 0)
			arr[i][i] = 1;
		colors[i] = 0;
	}
	int colorNumber = 0;
	for (int i = 0; i < n; i++)						//обработка посредствомы стягивания вершин
	{
		if (colors[i] == 0)
		{
			colorNumber++;
			colors[i] = colorNumber;
			for (int j = 0; j < n; j++)
			{
				if (arr[i][j] == 0 && arr[j][i] == 0 && colors[j] == 0)
				{
					colors[j] = colorNumber;
					for (int k = 0; k < n; k++)
						arr[i][k] += arr[j][k];
				}
			}
		}
	}

	//вывод результатов 
	cout << "Basic graph:" << endl;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
			cout << arr[i][j] << "\t";
		cout << endl;
	}
	cout << "colorNumber= " << colorNumber << endl;
	cout << "V(i)\t" << "color" << endl;
	for (int i = 0; i < n; i++)
	{
		cout << i + 1 << "\t" << colors[i] << endl;
	}
	system("pause");
	return 0;
}
