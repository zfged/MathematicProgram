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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void V1(double R,double H,double m)
        {
            double Vl;
            double percent;
            double V;

            double Vtotal=Math.PI * R * R * H;
            V=Vtotal;
            if(m>2*R)
            {
                MessageBox.Show("Ошибка ввода обьем жидкости больше чем обьем бочки");
            }

            else
            {
                double M;
                if(m>R)
                {
                    M=2*R-m;
                }
                else
                {
                    M=m;
                }

                double Ssect= Math.Acos( ( R - M ) / R ) * R * R;
                double sideX=2 * Math.Sqrt( R * R - ( R - M ) * ( R - M ) );
                double p=( R + R + sideX ) / 2;
                double Stri=Math.Sqrt( p * ( p - R ) * ( p - R ) * ( p - sideX ) );
                double Sx = Ssect - Stri;

                double Vtemp;
                if(M!=m)
                {
                    Vtemp=Vtotal - Sx * H;
                }
                else
                {
                    Vtemp=Sx * H;
                }
                Vl=Vtemp;
                MessageBox.Show("Обьем Жидкости: " + Convert.ToString(Vtemp) + "\n" + "Обьем Бочки: " + Convert.ToString(V) + "\n" + "Процент жидкости от Всей бочки :" + Convert.ToString(Vtemp/Vtotal*100) + "%");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            V1(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
        }

        private void подсчитаДиапазонЖидкостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"Main.txt", true))
            {
                file.WriteLine("Fourth line");
            }
        }

       


          
        }
    
}
