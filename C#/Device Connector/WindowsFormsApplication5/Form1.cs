using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)  //폼 로드
        {
            comboBox1.Items.Clear();
            comboBox1.DataSource = SerialPort.GetPortNames();   //연결 포트 종류 확인용
        }
        //연결 시작
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!(serialPort1.IsOpen && serialPort2.IsOpen))  
            {
                serialPort1.Close();  //시리얼포트 닫기
                serialPort2.Close();  

                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.BaudRate = 38400;
                serialPort1.PortName = "COM19"; //모터 연결 포트
                serialPort1.DtrEnable = true;

                serialPort1.Open();  //시리얼포트 열기

                serialPort2.DataBits = 8;
                serialPort2.StopBits = StopBits.One;
                serialPort2.Parity = Parity.None;
                serialPort2.BaudRate = 9600;
                serialPort2.PortName = "COM23"; //파워서플라이 연결 포트
                serialPort2.DtrEnable = true;
                         
                serialPort2.Open();  

                label1.Text = "포트가 열렸습니다.";
                comboBox1.Enabled = false;  //COM포트설정 콤보박스 비활성화
            }
            else  //시리얼포트가 열려 있으면
            {
                label1.Text = "포트가 이미 열려 있습니다.";
            }
        }
        //데이터 수신부
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(MySerialReceived1));
        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(MySerialReceived2));
        }
        
        private void MySerialReceived1(object s, EventArgs e)  //수신 데이터 처리
        {            
            txtRecieve.AppendText("M.A: "+serialPort1.ReadLine());
            txtRecieve.ScrollToCaret(); //스크롤을 맨 아래로 이동
        }

        private void MySerialReceived2(object s, EventArgs e)  
        {
            txtRecieve.AppendText("P.A: " + serialPort2.ReadLine());
            txtRecieve.ScrollToCaret();
        }
        //모터 전송부
        private void btnSend1_Click(object sender, EventArgs e)
        {
            sendData1();
        }

        private void txtSend1_KeyDown(object sender, KeyEventArgs e)    //엔터키로 전송 기능 구현
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendData1();
            }
        }

        private void sendData1()
        {
            if (serialPort1.IsOpen) {
                serialPort1.Write(txtSend1.Text + "\r");
                txtRecieve.AppendText("M.Q: " + txtSend1.Text + "\n");
                txtRecieve.ScrollToCaret();
            }
            txtSend1.Clear();
        }
        //파워서플라이 전송부
        private void btnSend2_Click(object sender, EventArgs e)
        {
            sendData2();
        }

        private void txtSend2_KeyDown(object sender, KeyEventArgs e)    
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendData2();
            }
        }

        private void sendData2()
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.WriteLine(txtSend2.Text);
                txtRecieve.AppendText("P.Q: " + txtSend2.Text + "\n");
                txtRecieve.ScrollToCaret();
            }
            txtSend2.Clear();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen || serialPort2.IsOpen)  //시리얼포트가 열려 있으면
            {
                serialPort1.Close();  //시리얼포트 닫기
                serialPort2.Close();

                label1.Text = "포트가 닫혔습니다.";
                comboBox1.Enabled = true;  //COM포트설정 콤보박스 활성화
            }
            else  //시리얼포트가 닫혀 있으면
            {
                label1.Text = "포트가 이미 닫혀 있습니다.";
            }
        }
    }
}
