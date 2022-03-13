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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string unit = "mm";
        private void Form3_Load(object sender, EventArgs e)
        {
            int Chetchick = 0;
            dataGridView1.RowCount = Convert.ToInt32(Settings1.Default.Do);
            for(int i=Convert.ToInt32(Settings1.Default.Ot);i<=Convert.ToInt32(Settings1.Default.Do);i++)
            {
                 
                 double temp = V1(Convert.ToDouble(Settings1.Default.R), Convert.ToDouble(Settings1.Default.H), i);
                 dataGridView1.Rows[Chetchick].Cells[0].Value = Convert.ToString(i);
                 dataGridView1.Rows[Chetchick].Cells[1].Value = Convert.ToString(temp);
                 Chetchick++;
                 
            }
        }
        double Vl;
        double V1(double R, double H, double m)
        {
            
            //double percent;
            double V;

            double Vtotal = Math.PI * R * R * H;
            V = Vtotal;
            if (m > 2 * R)
            {
                MessageBox.Show("Ошибка ввода обьем жидкости больше чем обьем бочки");
            }

            else
            {
                double M;
                if (m > R)
                {
                    M = 2 * R - m;
                }
                else
                {
                    M = m;
                }

                double Ssect = Math.Acos((R - M) / R) * R * R;
                double sideX = 2 * Math.Sqrt(R * R - (R - M) * (R - M));
                double p = (R + R + sideX) / 2;
                double Stri = Math.Sqrt(p * (p - R) * (p - R) * (p - sideX));
                double Sx = Ssect - Stri;

                double Vtemp;
                if (M != m)
                {
                    Vtemp = Vtotal - Sx * H;
                }
                else
                {
                    Vtemp = Sx * H;
                }
                Vl = Vtemp;
                
            }
            return Vl;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Resize(object sender, EventArgs e)
        {
          
        }

       //Сантиметры
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //если были милиметры
            if(unit=="mm")
            {
                for(int i=0;i<dataGridView1.RowCount;i++)
                {
                    for(int j=0;j<dataGridView1.ColumnCount;j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) / 10;
                    }
                }
            }

            if(unit=="m")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) * 100;
                    }
                }
            }
            unit = "sm";
            toolStripLabel1.Text = "Сантиметры";
        }
        //метры
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //были милиметры
            if(unit=="mm")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) / 1000;
                    }
                }
            }
            //были сантиметры
            if(unit=="sm")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) / 100;
                    }
                }
            }
            unit = "m";
            toolStripLabel1.Text = "Метры";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(unit=="sm")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) * 10;
                    }
                }
            }

            if (unit == "m")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) * 1000;
                    }
                }
            }

            unit = "mm";
            toolStripLabel1.Text = "Милиметры";
        }

    }
}
