using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    public partial class Form1 : Form
    {
        private List<int> lot;
        int result;
        Lotto lotto;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ball.Visible=false;
            lbBall.Visible=false;
            lotto = new Lotto();
            lot = new List<int>();
            btnChoose.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Ball.Visible=false;
            lbBall.Visible=false;
            lbNum.Text="";
            lot.Clear();
            btnChoose.Enabled = true;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            Ball.Visible = false;
            lbBall.Visible = false;
            result = lotto.choose(lot);
            lot.Add(result);
            lbBall.Text = result.ToString();
            lbNum.Text = lbNum.Text + result.ToString()+" ";
            Thread.Sleep(500);
            Ball.Visible = true;
            lbBall.Visible = true;
            if (lot.Count >= 6)
                btnChoose.Enabled = false;
        }
    }
    public class Lotto
    {
        static int SEED=17;
        Random r;
        public Lotto()
        {
            r = new Random(SEED + System.DateTime.Now.Millisecond);
        }
        public int rand(){
            return r.Next(45)+1;
        }
        public int choose(List<int> list)
        {
            int result;
            while (true)
            {
                result = rand();
                if (list.Contains(result))
                    continue;
                else
                    return result;
            }
        }
    }
}