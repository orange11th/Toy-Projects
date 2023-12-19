using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Drawing.Imaging;
using System.IO;

namespace Webdownlaod
{
    public partial class Form1 : Form
    {
        WebFile wf;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wf = new WebFile();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string url = txtRead.Text;
            try
            {
                pictureBox1.Image = wf.DownloadBitmap(url);
            }
            catch (Exception) { MessageBox.Show("이미지를 읽어오는데 실패했습니다."); }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            string url = txtRead.Text;
            string fname = txtSave.Text;
            try
            {
                Bitmap bit = wf.DownloadBitmap(url);
                MessageBox.Show(bit.Size.ToString());
                wf.SaveMemoryStream(bit, fname);
                MessageBox.Show("이미지 저장에 성공했습니다.");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public class WebFile
        {
            public Bitmap DownloadBitmap(string url)
            {
                WebClient web = new WebClient();
                byte[] downs = web.DownloadData(url);
                Bitmap bit = null;
                using (MemoryStream ms = new MemoryStream(downs))
                {
                    bit = new Bitmap(ms);
                }
                return bit;
            }
            public void SaveMemoryStream(Bitmap bit, string fname)
            {
                MemoryStream ms = new MemoryStream();
                bit.Save(ms, ImageFormat.Bmp);
                using (FileStream outStream = File.OpenWrite(fname))
                {
                    ms.WriteTo(outStream);
                    outStream.Close();
                }
            }
        }
    }
}