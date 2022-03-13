using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lagrange
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.dataGridView1.ColumnCount = Convert.ToInt32(textBox1.Text)+1;
            form3.dataGridView1.RowCount = 3;
            form3.dataGridView1.Rows[0].Cells[0].Value = "k";
            form3.dataGridView1.Rows[1].Cells[0].Value = "Xk";
            form3.dataGridView1.Rows[2].Cells[0].Value = "Yk";
            for (int i = 1; i < form3.dataGridView1.ColumnCount; i++)
            {
                form3.dataGridView1.Rows[0].Cells[i].Value = i-1;
            }

            Settings1.Default.h =  Convert.ToInt32(textBox1.Text) + 1;
            form3.Show();
            this.Hide();
        }
    }
}
