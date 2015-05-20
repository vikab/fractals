using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fractals
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Close();
            if (radioButton1.Checked)
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
            else if (radioButton2.Checked)
            {
                Form3 f3 = new Form3();
                f3.Show();
            }
            else if (radioButton3.Checked)
            {
                Form4 f4 = new Form4();
                f4.Show();
            }
            else
            {
                MessageBox.Show("Choose something!");
            }

        }
    }
}
