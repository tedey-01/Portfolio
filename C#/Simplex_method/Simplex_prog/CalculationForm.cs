using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplex_prog
{
    public partial class CalculationForm : Form
    {
        DataGridView dgvA = new DataGridView();
        DataGridView dgvB = new DataGridView();
        DataGridView dgvC = new DataGridView();
        int m, n;

        public CalculationForm()
        {
			this.Height = 1200;
			this.Width = 1000;
            InitializeComponent();
        }

        public CalculationForm(int m, int n)
        {
            
            this.m = m;
            this.n = n;
            dgvA.Name = "dvgA";
            dgvA.Parent = this;
        
            for (int i = 1; i <= n; i++)
            {
                dgvA.Columns.Add(Convert.ToString(i), Convert.ToString(i));
            }
            if (m != 1)
                dgvA.Rows.Add(m);
            dgvA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvA.Width = n*50+40;
            dgvA.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			dgvA.Height = 28 * (m + 1);
        
            var x = this.Location.X + (dgvA.Width) / 4+20;
			x = 10;
			var y = this.Location.Y + this.Height+100;
            dgvA.Location = new Point(x, y);
            
            dgvA.AllowUserToAddRows = false;

            this.Controls.Add(dgvA);


            //-------------------------------------------------------
            dgvB.Name = "dvgB";
            dgvB.Parent = this;

            for (int i = 1; i <= m; i++)
            {
                dgvB.Columns.Add(Convert.ToString(i), Convert.ToString(i));
            }
            dgvB.Rows.Add(1);
            dgvB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			dgvB.Width = m * 50 + 40;
			dgvB.Height = 28*2;

            var xb = x + dgvA.Width + 250;
			xb = 620;
            var yb = this.Location.Y + this.Height+100;
            dgvB.Location = new Point(xb, yb);

            dgvB.AllowUserToAddRows = false;

            this.Controls.Add(dgvB);

            //-------------------------------------------------------
            dgvC.Name = "dvgC";
            dgvC.Parent = this;

            for (int i = 1; i <= n; i++)
            {
                dgvC.Columns.Add(Convert.ToString(i), Convert.ToString(i));
            }
            dgvC.Rows.Add(1);
            dgvC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			dgvC.Width = n * 50 + 40;
			dgvC.Height = 28 * 2;

            var xc = xb + dgvB.Width +250;
			xc = 1053;
            var yc = this.Location.Y + this.Height+100;
            dgvC.Location = new Point(xc, yc);

            dgvC.AllowUserToAddRows = false;

            this.Controls.Add(dgvC);



            InitializeComponent();
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Alan the best");
            Application.Exit();
        }

        private void CalculationForm_Load(object sender, EventArgs e)
        {

        }

        private void ButtCalculate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Alan the best man");
            Console.WriteLine(dgvA.Name);
            n += m;
            int[,] A = new int[m, n];
            int[] B = new int[m];
            int[] C = new int[n];

            for (int rows = 0; rows < m; rows++)
                for (int col = 0; col < n; col++)
                    if (col < n - m)
                        A[rows, col] = Int32.Parse(dgvA.Rows[rows].Cells[col].Value.ToString());
                    else
                    {
                        if (col - rows == 4)
                            A[rows, col] = 1;
                        else
                            A[rows, col] = 0;
                    }
            for (int col = 0; col < m; col++)
                B[col] = Int32.Parse(dgvB.Rows[0].Cells[col].Value.ToString());

            for (int col = 0; col < n; col++)
                if (col < n - m)
                    C[col] = Int32.Parse(dgvC.Rows[0].Cells[col].Value.ToString());
                else
                    C[col] = 0;

            //---------------------------------------------------------------------------
			
            bool extr = true;
            int[] P = new int[m];                //базисные переменные
            int[] D = new int[n];                //дельты 
            
			for (int i =0; i<m; i++)
			{
				P[i] = n - m + i + 1;
			}

           
            for (int i = 0; i < n; i++)
                D[i] = 0;

            //решение
            //определение таблицы
            float[,] table = new float[m + 1, n + 1];
            float[,] new_table = new float[m + 1, n + 1];
            for (int i = 0; i < m + 1; i++)
            {
                if (i != m)
                {
                    table[i,0] = B[i];

                    for (int j = 1; j < n + 1; j++)
                    {
                        table[i,j] = A[i, j - 1];
                    }
                }
                else
                {
                    for (int j = 1; j < n + 1; j++)
                    {
                        table[i, j] = 0;
                    }
                }
            }

            //нахождение дельт
            int flag = 0;

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    int k = P[i] - 1;
                    D[j] += C[k] * A[i, j];
                }
                D[j] -= C[j];
                if (extr && D[j] < 0) flag = 1;
                if (!extr && D[j] > 0) flag = 1;
                Console.WriteLine( "D[" + j + "] = " + D[j] );
                table[m, j + 1] = D[j];
            }

            while (flag != 0)
            {
                //--------------------------------------------
                for (int i = 0; i < m + 1; i++) {
                	for (int j = 0; j < n + 1; j++)	
                		if (i==m && j==0)
                			Console.Write( 0 +"\t");
                		else
                            Console.Write(table[i, j] + "\t");
                    Console.WriteLine();
                }
                
                Console.WriteLine("-----" );
                for (int i = 0; i < m + 1; i++) {
                	for (int j = 0; j < n + 1; j++)
                		if (i == m && j == 0)
                			Console.Write( 0 +"\t");
                		else
                			Console.Write( new_table[i,j] + "\t");
                	Console.WriteLine();
                }
                //----------------------------------------------


                int s = 1;
                float tmp_d = table[m, 1];

                if (extr)
                {                                       //если максимизация функции
                    for (int i = 1; i < n + 1; i++)
                    {
                        if (table[m, i] > 0)                    //Не совпадение 
                            flag = 1;

                        if (table[m, i] < tmp_d)
                        {
                            s = i;
                            tmp_d = table[m, i];
                        }
                    }
                }
                else
                {                                           //если минимизаця ункции
                    for (int i = 1; i < n + 1; i++)
                    {
                        if (table[m, i] < 0)                    //Не совпадение 
                            flag = 1;

                        if (table[m, i] > tmp_d)
                        {
                            s = i;
                            tmp_d = table[m, i];
                        }
                    }
                }

                //пересраиваем таблицу
                int k = 0;
                while (table[k, s] <= 0) k++;

                float tmp_b = table[k, 0] / table[k, s];
                int r = k;

                for (int i = k; i < m; i++)
                {
                    if (table[i, 0] / table[i, s] < tmp_b && table[i, s] > 0)
                    {
                        tmp_b = table[i, 0] / table[i, s];
                        r = i;
                    }
                }
                P[r] = s;

                //заполнение новой таблицы new_table 
                for (int j = 0; j < n + 1; j++)
                {
                    new_table[r, j] = table[r, j] / table[r, s];
                }

                for (int i = 0; i < m + 1; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        if (i != r)
                            new_table[i, j] = table[i, j] - table[i, s] * (table[r, j] / table[r, s]);
                    }
                }


                //проверка корректности новой таблицы 
                flag = 0;
                Console.WriteLine( "---------------" );
                for (int j = 1; j < n + 1; j++)
                {
                    if (extr && (new_table[m, j] < 0))
                        flag = 1;
                    if (!extr && (new_table[m, j] > 0))
                        flag = 1;
                    Console.WriteLine( "D[" + j + "] = " + new_table[m, j]);
                }

                for (int i = 0; i < m + 1; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        int cell = Convert.ToInt32(table[i, j]);
                        table[i, j] = new_table[i, j];
                        new_table[i, j] = cell;
                    }
                }
            }

            //подсчёт характеристик таблицы 
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine("P[" + (i + 1) + "]=  " +P[i] );
            }
            //----------------------------------------------------------------------------
            //Console.WriteLine("--------------------------------------------");
            //for (int i = 0; i < m + 1; i++)
            //{
            //    for (int j = 0; j < n + 1; j++)
            //    {
            //        Console.Write(table[i,j]+" ");
            //    }
            //    Console.WriteLine("\n");
            //}

            string answer = "";
            float F = 0;
            for (int i=0; i<m; i++)
            {
                F += table[i,0] * C[P[i]-1];
            }

            float[] rez = new float [n];
            for (int i = 0; i < n; i++)
                rez[i] = 0;
            for (int i=0; i<m; i++)
                rez[P[i] - 1] = table[i, 0];

            for (int i = 0; i < n ; i++)
            {	if (i >= n - m)
				{
					if (rez[i]!= 0)
					{
						answer += "x" + Convert.ToString(i + 1) + "=" + Convert.ToString(rez[i]) + ";  ";
					}
				}
				else
				{
					Console.Write(rez[i] + "\t");
					answer += "x" + Convert.ToString(i + 1) + "=" + Convert.ToString(rez[i]) + ";  ";
				} 
            }
            answer += "\nF =    " + Convert.ToString(F);
           // MessageBox.Show(
           //     answer,
           //     "Результат",
           //     MessageBoxButtons.YesNo,
           //     MessageBoxIcon.Information,
           //     MessageBoxDefaultButton.Button1,
           //     MessageBoxOptions.DefaultDesktopOnly);
           //
            Console.WriteLine("F= "+F);

            this.Hide();

            Result result = new Result(answer);
            result.Show();
        }
    }
}
