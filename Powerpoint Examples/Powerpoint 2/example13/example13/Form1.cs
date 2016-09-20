using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int num1 = Int32.Parse(txtInput1.Text);
            int num2 = Int32.Parse(txtInput2.Text);
            int total = num1 + num2;
            lblTotal.Text = total.ToString();
        }
    }
}
