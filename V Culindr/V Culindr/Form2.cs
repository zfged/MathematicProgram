using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace V_Culindr
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void посчитатьДиапазонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings1.Default.Ot = textBox3.Text;
            Settings1.Default.Do = textBox4.Text;
            Settings1.Default.R = textBox1.Text;
            Settings1.Default.H = textBox2.Text;
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
