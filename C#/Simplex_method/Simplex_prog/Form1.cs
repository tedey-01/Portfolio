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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void ButtNext_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.ResourseField.Text);
            Console.WriteLine(this.ProductField.Text);
            //Console.WriteLine(this.ProductField.Text.GetType());

            this.Hide();
            int m = Int32.Parse(this.ResourseField.Text);
            int n = Int32.Parse(this.ProductField.Text);


            CalculationForm calculationForm = new CalculationForm(m, n);
            //DataGridView dgv = new DataGridView();
            //dgv.Name = "dvg";
            //
            //for (int i = 1; i <= n; i++)
            //{
            //    dgv.Columns.Add(Convert.ToString(i), Convert.ToString(i));
            //}
            //dgv.Rows.Add(m - 1);
            //dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            ////dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            //dgv.Height = 22 * (m + 1);
            //
            //var x = calculationForm.Location.X + (dgv.Width) / 2;
            //var y = calculationForm.Location.Y + (calculationForm.Height - dgv.Height) / 2;
            //dgv.Location = new Point(x, y);
            //
            //
            //calculationForm.Controls.Add(dgv);
            calculationForm.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

	}
}
