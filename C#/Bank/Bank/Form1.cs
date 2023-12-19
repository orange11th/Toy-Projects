using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            this.lbResult.Text = "" + Calc(Decimal.ToDouble(this.nudAmount.Value),
                Decimal.ToDouble(this.nudRate.Value), Decimal.ToInt32(this.nudYear.Value)).ToString();
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.nudAmount.Value = (decimal)(double)200000;
            this.nudRate.Value = (decimal)4.5M;
            this.nudYear.Value = (decimal)2M;
            this.lbResult.Text = "";
        }
        public static int Calc(double a, double r, int n)
        {
            double result = a;
            double tmp = a;
            for (int i = 0; i < n; i++)
            {
                result*=(100.0 + r)/100.0;
            }
            return (int)result;
        }
    }
}
