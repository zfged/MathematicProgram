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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void подсчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

            Form1 form1 = new Form1();

            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = Convert.ToInt32(textBox1.Text) + 1;
            dataGridView1.RowCount = 3;
            dataGridView1.Rows[0].Cells[0].Value = "k";
            dataGridView1.Rows[1].Cells[0].Value = "Xk";
            dataGridView1.Rows[2].Cells[0].Value = "Yk";
            for (int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = i - 1;
            }

            Settings1.Default.h = Convert.ToInt32(textBox1.Text) + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] XkChisl = new string[Settings1.Default.h - 1];
            int[] XkZnam = new int[Settings1.Default.h - 1];
            for (int i = 0; i < XkZnam.Length; i++) XkZnam[i] = 1;



            int[] xk = new int[Settings1.Default.h - 1];

            for (int i = 0; i < xk.Length; i++)
            {
                xk[i] = Convert.ToInt32(dataGridView1.Rows[1].Cells[i + 1].Value);
            }


            for (int j = 0; j < XkZnam.Length; j++)
            {
                for (int i = 0; i < XkZnam.Length; i++)
                {
                    if (j != i)
                    {
                        XkZnam[j] = XkZnam[j] * (xk[j] - xk[i]);
                    }

                }

            }





            for (int i = 1; i < Settings1.Default.h; i++)
            {

                if (Convert.ToInt32(dataGridView1.Rows[1].Cells[i].Value) > 0)
                {
                    XkChisl[i - 1] = "(x-" + dataGridView1.Rows[1].Cells[i].Value + ")";
                }

                if (Convert.ToInt32(dataGridView1.Rows[1].Cells[i].Value) < 0)
                {
                    XkChisl[i - 1] = "(x+" + Math.Abs(Convert.ToDouble(dataGridView1.Rows[1].Cells[i].Value)) + ")";
                }
                if (Convert.ToInt32(dataGridView1.Rows[1].Cells[i].Value) == 0)
                {
                    XkChisl[i - 1] = "(x-" + dataGridView1.Rows[1].Cells[i].Value + ")";
                }

            }

            string[] XkresultChisl = new string[Settings1.Default.h - 1];
            int incrementChisl = 0;

            for (int j = 0; j < Settings1.Default.h - 1; j++)
            {

                for (int i = 0; i < Settings1.Default.h - 1; i++)
                {
                    if (i != incrementChisl)
                    {
                        XkresultChisl[j] = XkresultChisl[j] + XkChisl[i] + "*";
                    }
                }
                XkresultChisl[j] = XkresultChisl[j].Substring(0, XkresultChisl[j].Length - 1);

                XkresultChisl[j] = "(" + XkresultChisl[j] + "*" + dataGridView1.Rows[2].Cells[j + 1].Value + ")";

                incrementChisl++;
            }

            string[] Xkresult = new string[Settings1.Default.h - 1];
            for (int i = 0; i < Settings1.Default.h - 1; i++)
            {
                Xkresult[i] = XkresultChisl[i] + "/" + Convert.ToString(XkZnam[i]);
                Xkresult[i] = "(" + Xkresult[i] + ")";
            }

            string[] Xkresult2 = new string[1];

            for (int i = 0; i < Settings1.Default.h - 1; i++)
            {
                Xkresult2[0] += Xkresult[i] + "+";
            }

            Xkresult2[0] = Xkresult2[0].Substring(0, Xkresult2[0].Length - 1);

            Settings1.Default.result = Xkresult2[0];

            // переходим по адресу
            webBrowser1.Navigate("http://ru.numberempire.com/simplifyexpression.php");

            // ждём конца загрузки страници

            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            } // страница полностью загружена

            webBrowser1.Document.GetElementById("function").SetAttribute("value", Settings1.Default.result);


            timer1.Enabled = true;

           


            

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }


        int a = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            a++;

            if(a==3)
            {
                webBrowser1.Document.GetElementById("form1").InvokeMember("submit");
            }

            if(a==8)
            {
                HtmlElement he = webBrowser1.Document.GetElementById("result1");
                MessageBox.Show( he.InnerText );
                a = 0;
                timer1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
