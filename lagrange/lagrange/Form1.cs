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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // переходим по адресу
            webBrowser1.Navigate("http://www.mathsolution.ru/math-task/simplifi-polynom");

            // ждём конца загрузки страници
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            } // страница полностью загружена

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // переходим по адресу
            webBrowser1.Navigate("http://ru.numberempire.com/simplifyexpression.php");

            // ждём конца загрузки страници
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            } // страница полностью загружена


            webBrowser1.Document.GetElementById("function").SetAttribute("value", Settings1.Default.result);

            // жмём на кнопку поиск <input id="find" type="submit" value="Найти!" class="button" tabindex="2"/>
           // 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           

            

          

            //string a = he.InnerText;
        }
    }
}
