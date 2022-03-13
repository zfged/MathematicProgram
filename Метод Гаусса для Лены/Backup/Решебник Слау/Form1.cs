using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        TextBox[,] t;
        int n;
        int m;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(comboBox1.SelectedItem.ToString());
                m = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                if (comboBox1.SelectedItem.ToString() == null || comboBox2.SelectedItem.ToString() == null)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Ошибка!!!\nЗадайте значение входных параметров");
            }
            m += 1;
            int i, j, c, d;
            int x = 18, y = 18;
            t = new TextBox[n, m];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    t[i, j] = new TextBox();
                    tabPage2.Controls.Add(t[i, j]);
                    t[i, j].Location = new Point(x += 50, y);
                    t[i, j].Size = new Size(25, 20);
                    t[i, j].TabStop = false;
                }
                y += 40;
                x = 18;
            }
            y = 16;
            x = 45;
            Label[,] l = new Label[n, m];
            for (c = 0; c < n; c++)
            {
                for (d = 0; d < m - 1; d++)
                {
                    l[c, d] = new Label();
                    tabPage2.Controls.Add(l[c, d]);
                    l[c, d].Location = new Point(x += 50, y);
                    l[c, d].Size = new Size(40, 40);
                    int z = d + 1;
                    if (d == m - 2)
                        l[c, d].Text = "x" + z + " =";
                    else
                        l[c, d].Text = "x" + z + " +";
                    l[c, d].TabStop = false;
                }
                y += 41;
                x = 45;
            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
        }
        public string Gauss(int Rows, int Column, double[,] matr)
        {
            int i, k, q;
            double v;
            string answer = "";
            for (q = 0; q < Rows; q++)
            {
                //делаем главную диогональ единицами  
                v = matr[q, q];
                for (k = 0; k < Column; k++)
                    matr[q, k] /= v;
                //обнуляем числа под единицами главной диогoнали
                for (i = q + 1; i < Rows; i++)
                {
                    v = matr[i, q];
                    for (k = q; k < Column; k++)
                        matr[i, k] = matr[i, k] - matr[q, k] * v;
                }
            }
            for (q = 0; q < Rows; q++)
                for (i = 0; i < (Rows - 1) - q; i++)
                {
                    v = matr[i, (Column - 1) - q - 1];
                    for (k = Column - 1 - q - 1; k < Column; k++)
                        matr[i, k] = matr[i, k] - matr[(Rows - 1) - q, k] * v;
                }
            for (i = 0; i < Rows; i++)
                answer += "x_" + i + " = " + matr[i, Column - 1] + "\r\n";
            return answer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i, j;
            string[,] v = new string[n, m];
            double[,] v1 = new double[n, m];
            for (i = 0; i < n; i++)
                for (j = 0; j < m; j++)
                {
                    v1[i, j] = Convert.ToDouble(t[i, j].Text);
                    v[i, j] = Convert.ToString(t[i, j].Text);
                }
            richTextBox1.AppendText("Задача :\nНайти решение системы уравнений :\n");
            for (i = 0; i < n; i++)
            {
                string s = "";
                for (j = 0; j < m; j++)
                {

                    if (t[i, j].Text == null)
                    {
                        try
                        {
                            throw new Exception();
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка!!!\nЗадайте значение входных параметров");
                        }
                    }
                    if (j == m - 1)
                        s += v[i, j];
                    else
                    {
                        int z = j + 1;
                        if (v1[i, j] < 0)
                            s += v[i, j] + "x" + z + " - ";
                        if (v1[i, j] == 0)
                            s += "   ";
                        if (j == m - 2)
                            s += v[i, j] + "x" + z + " = ";
                        if (v1[i, j] > 0)
                            s += v[i, j] + "x" + z + " + ";
                    }
                }
                richTextBox1.AppendText(s + "\n");
            }
            richTextBox1.AppendText("Шаг 1:\nСформируем расширенную матрицу :\n");
            for (i = 0; i < n; i++)
            {
                string s = "";
                for (j = 0; j < m; j++)
                {
                    if (j == m - 1)
                        s += "  " + (v[i, j]).PadRight(2);
                    else
                        s += (v[i, j].PadRight(3)) + " ";
                }
                richTextBox1.AppendText(s + "\n");
            }
            richTextBox1.AppendText("Применяя к расширенной матрице последовательность элементарных операций, стремимся, чтобы каждая строка, кроме, быть может, первой, начиналась с нулей, и число нулей до первого ненулевого элемента в каждой следующей строке было больше, чем в предыдущей.\n");
            richTextBox1.AppendText("Шаг:2\nРазделим строку 1 на a1,1 =	" + (v[0, 0]).ToString() + "\n" + "Получим матрицу :\n");
            richTextBox1.AppendText(Gauss(n, m, v1));
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}