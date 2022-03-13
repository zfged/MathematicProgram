using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace linear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string result = "";
            double a=0;
            double[]xarr=new double[7];
            double[]yarr=new double[7];
            xarr[0]=0;

            xarr[1] = 0.2;
            xarr[2] = 0.4;
            xarr[3] = 0.6;
            xarr[4] = 0.8;
            xarr[5] = 1.0;
            xarr[6] = 1.1;

            yarr[0] = -0.0005;
            yarr[1] = -0.0008;
            yarr[2] = 0.00095;
            yarr[3] = -0.001;
            yarr[4] = -0.0012;
            yarr[5] = -0.0014;
            yarr[6] = -0.0016;

            for(int i=0;i<xarr.Length;i++)
            {
               
                
                result += "CY" +Convert.ToInt32( i+1 )+"="+ yarr[i] + "+" + "(x-" + xarr[i] + ")\n";
            }
            
            MessageBox.Show(result);

            double t = 0.6;

            for(int i=0;i<xarr.Length-1;i++)
            {
                if (t < xarr[i])
                {
                    a = yarr[i] + (t - xarr[i]) / (xarr[i + 1] - xarr[i]) * (yarr[i + 1] - yarr[i]);
                }
            }
            MessageBox.Show(Convert.ToString(a));
        }

        }
        

    
}
