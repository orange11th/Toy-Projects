using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            webBrowser1.CanGoBackChanged += new EventHandler(webBrowser1_CanGoBackChanged);
            webBrowser1.CanGoForwardChanged += new EventHandler(webBrowser1_CanGoForwardChanged);
            webBrowser1.Navigate("https://ggaebap.tistory.com/");
        }
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)Keys.Enter == e.KeyChar)
            {
                webBrowser1.Navigate(toolStripTextBox1.Text);
            }
        }
        private void webBrowser1_CanGoBackChanged(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack == true)
                toolStripButton1.Enabled = true;
            else
                toolStripButton1.Enabled = false;
        }
        private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward == true)
                toolStripButton2.Enabled = true;
            else
                toolStripButton2.Enabled = false;
        }
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            long total = e.MaximumProgress;
            long current = e.CurrentProgress;
            toolStripProgressBar1.Value = (int)(100.0 * current / total);
        }
        private void toolStripButton1_Click(object sender, EventArgs e) //뒤로가기
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
                toolStripTextBox1.Text = webBrowser1.Url.ToString();
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e) //앞으로가기
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
                toolStripTextBox1.Text = webBrowser1.Url.ToString();
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e) //새로고침
        {
            webBrowser1.Refresh();
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripTextBox1.Text = webBrowser1.Url.ToString();
        }
    }
}