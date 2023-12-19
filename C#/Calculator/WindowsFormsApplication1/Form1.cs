using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            textNum1.Clear();
            textNum2.Clear();
            textResult.Clear();
        }

        private void Calc(String op)
        {
            try
            {
                if(string.IsNullOrEmpty(textNum1.Text) || string.IsNullOrEmpty(textNum2.Text)){
                    MessageBox.Show("공백이 입력되었습니다.");
                    Clear();
                }
                else{
                    switch(op){
                        case "+": textResult.Text = (double.Parse(textNum1.Text) + double.Parse(textNum2.Text)).ToString(); break;
                        case "-": textResult.Text = (double.Parse(textNum1.Text) - double.Parse(textNum2.Text)).ToString(); break;
                        case "*": textResult.Text = (double.Parse(textNum1.Text) * double.Parse(textNum2.Text)).ToString(); break;
                        case "/": textResult.Text = (double.Parse(textNum1.Text) / double.Parse(textNum2.Text)).ToString(); break;
                    }
                    lbResult.Text = op;
            }
            }
            catch { MessageBox.Show("숫자를 입력하세요."); Clear(); };
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Calc("+");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Calc("-");
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            Calc("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Calc("/");
        }
    }
}