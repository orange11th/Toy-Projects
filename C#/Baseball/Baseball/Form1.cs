using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baseball
{
    public partial class Form1 : Form
    {
        int inning=1;
        List<int> pitchList = new List<int>();
        List<int> hitList = new List<int>();
        List<Button> btnList = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnList.Add(btn0);
            btnList.Add(btn1);
            btnList.Add(btn2);
            btnList.Add(btn3);
            btnList.Add(btn4);
            btnList.Add(btn5);
            btnList.Add(btn6);
            btnList.Add(btn7);
            btnList.Add(btn8);
            btnList.Add(btn9);
            btnHit.Enabled = false;
            btnEnable(false);
        }
        public void setPitch()
        {
            pitchList.Clear();
            Random r = new Random(DateTime.Now.Millisecond);
            while (pitchList.Count < 3)
            {
                int tmp = r.Next(10);
                if (!pitchList.Contains(tmp))
                    pitchList.Add(tmp);
            }
        }
        public void setHit(int number, Button btn)
        {
            if (hitList.Count < 3)
            {
                hitList.Add(number);
                btn.Visible = false;
            }
            if (hitList.Count == 3)
                btnHit.Enabled = true;
        }
        public void refree()
        {
            int strike = 0;
            int ball = 0;
            for (int i = 0; i < 3; i++)
            {
                if (pitchList.Contains(hitList[i]))
                {
                    if (hitList[i] == pitchList[i])
                        strike++;
                    else
                        ball++;
                }
            }
            richTextBox1.AppendText(inning+"이닝: "+hitList[0] +"-"+ hitList[1] +"-"+ hitList[2]+" ["
                +strike+" Strike "+ball+" Ball]\n");
            lbResult.Text="["+strike+" Strike "+ball+" Ball]";
            if (strike == 3){
                MessageBox.Show("You Win!");
                btnEnable(false);
                btnHit.Enabled=false;
                lbResult.Text = "   You Win!";
                return;
            }
            inning++;
            if (inning == 10)
            {
                MessageBox.Show("You Lose.");
                btnEnable(false);
                btnHit.Enabled = false;
                lbResult.Text = "   You Lose.";
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            hitList.Clear();
            setPitch();
            btnVisible(true);
            btnEnable(true);
            btnHit.Enabled = false;
            inning = 1;
            lbResult.Text = "   Play Ball!";
        }
        private void btnHit_Click(object sender, EventArgs e)
        {
            refree();
            hitList.Clear();
            btnVisible(true);
            btnHit.Enabled = false;
        }
        private void btnNum_Click(object sender, EventArgs e)
        {
            if (sender as Button == btn0) {setHit(0,btn0);}
            else if (sender as Button == btn1) {setHit(1,btn1);}
            else if (sender as Button == btn2) {setHit(2,btn2);}
            else if (sender as Button == btn3) {setHit(3,btn3);}
            else if (sender as Button == btn4) {setHit(4,btn4);}
            else if (sender as Button == btn5) {setHit(5,btn5);}
            else if (sender as Button == btn6) {setHit(6,btn6);}
            else if (sender as Button == btn7) {setHit(7,btn7);}
            else if (sender as Button == btn8) {setHit(8,btn8);}
            else if (sender as Button == btn9) {setHit(9,btn9);}
        }
        public void btnVisible(bool v)
        {
            foreach (Button b in btnList)
            {
                b.Visible = v;
            }
        }
        public void btnEnable(bool v)
        {
            foreach (Button b in btnList)
            {
                b.Enabled = v;
            }
        }
    }
}