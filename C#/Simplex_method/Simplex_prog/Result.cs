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
    public partial class Result : Form
    {  
        public Result()
        {
            InitializeComponent();
        }

        public Result(string ans)
        {
            InitializeComponent();
            this.answer.Text = ans;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtCalculate_Click(object sender, EventArgs e)
        {
            this.Hide();

            StartForm startForm = new StartForm();
            startForm.Show();
        }
    }
}
