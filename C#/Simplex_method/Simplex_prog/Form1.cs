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
           
            calculationForm.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

	}
}
