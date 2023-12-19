using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form1 : Form
    {
        RSA rsa;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rsa = new RSA();
            rsa.makeArgs();
        }
        private void btnPubK_Click(object sender, EventArgs e)
        {
            btnPubK.Text = rsa.getPubK.ToString();
        }
        private void btnPriK_Click(object sender, EventArgs e)
        {
            btnPriK.Text = rsa.getPriK.ToString();
        }
        private void btnEncode_Click(object sender, EventArgs e)    //암호화 버튼
        {
            richTextBox3.Clear();
            richTextBox6.Clear();
            int[] bit = toBit(richTextBox1.Text);
            rsa.encode(bit);
            int[] tmp = rsa.getCode();
            foreach (int j in bit)
                richTextBox6.AppendText(j.ToString() + " ");
            foreach (int i in tmp)
                richTextBox3.AppendText(i.ToString() + " ");
        }
        private void btnPass_Click(object sender, EventArgs e)      //전달 버튼
        {
            richTextBox2.Clear();
            int[] tmp = rsa.getCode();
            foreach (int i in tmp)
                richTextBox2.AppendText(i.ToString() + " ");
        }
        private void btnDecode_Click(object sender, EventArgs e)    //해독 버튼
        {
            richTextBox4.Clear();
            richTextBox5.Clear();
            int[] m = rsa.getCode();
            int[] tmp = rsa.decode(m);
            foreach (int i in tmp)
            {
                richTextBox4.AppendText(i.ToString() + " ");
            }
            richTextBox5.Text = toKor(tmp);
        }
        private void btnClean_Click(object sender, EventArgs e)     //모두 지우기 버튼
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)     //리셋 버튼
        {
            rsa.makeArgs();
            btnPubK.Text = "공개 키 확인";
            btnPriK.Text = "개인 키 확인";
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();
            richTextBox6.Clear();
        }
        public int[] toBit(string kor)  //문자열을 유니코드로 변환
        {
            Encoding unicode = Encoding.Unicode;
            byte[] unicodeBytes = unicode.GetBytes(kor);
            int[] bits = new int[unicodeBytes.Length];
            for (int i = 0; i < unicodeBytes.Length; i++)
                bits[i] = unicodeBytes[i];
            return bits;
        }
        private string toKor(int[] kor) //유니코드를 문자열로 변환
        {
            Encoding unicode = Encoding.Unicode;
            byte[] unibyte = new byte[kor.Length];
            for (int i = 0; i < unibyte.Length; i++)
                unibyte[i] = (byte)kor[i];
            char[] uniChars = new char[unicode.GetCharCount(unibyte, 0, unibyte.Length)];
            unicode.GetChars(unibyte, 0, unibyte.Length, uniChars, 0);
            return new string(uniChars);
        }
    }
    public class RSA
    {
        private int p = 7, q = 11, n, phiN, pubK, priK;
        private static int SEED = 127;
        private List<int> pubKList = new List<int>();   //공개 키 후보 리스트
        private List<int> priKList = new List<int>();   //개인 키 후보 리스트
        private int[] code;

        public int getPubK { get { return pubK; } } //공개 키 얻기

        public int getPriK { get { return priK; } } //개인 키 얻기

        public int[] getCode()
        {
            int[] copy = new int[code.Length];
            Array.Copy(code, copy, copy.Length);
            return copy;
        }
        public void encode(int[] bits)  //문자열 암호화
        {
            code = new int[bits.Length];
            for (int i = 0; i < bits.Length; i++)
                code[i] = singleEncode(bits[i]);
        }
        private int singleEncode(int c) //한글자 암호화
        {
            int tmp = 1;
            for (int i = 0; i < pubK; i++)
            {
                tmp = (tmp * c) % n;
            }
            return tmp;
        }
        public int[] decode(int[] ps)   //문자열 해독
        {
            int[] ims = new int[ps.Length];
            for (int i = 0; i < ps.Length; i++)
                ims[i] = singleDecode(ps[i]);
            return ims;
        }
        private int singleDecode(int k) //한글자 해독
        {
            int tmp = 1;
            for (int i = 0; i < priK; i++)
                tmp = (tmp * k) % n;
            return tmp;
        }
        public void makeArgs()  //키 계산용 아규먼트와 키 생성
        {
            int distance = SEED / 2;
            Random r = new Random(SEED + System.DateTime.Now.Millisecond);
            this.p = r.Next(SEED - distance, SEED);
            while (!isPrime(p))          //소수 p 생성
                this.p = r.Next(SEED++);
            this.q = r.Next(SEED, SEED + distance);
            while (!isPrime(q) || q == p)    //p와 다른소수 q 생성
                this.q = r.Next(SEED, SEED + distance);
            this.n = p * q;                      //N=p*q
            this.phiN = (p - 1) * (q - 1);           //phiN(파이엔)=(p-1)*(q-1)
            makePubK();
            selectPubk();
            makePriK();
            selectPriK();
        }
        private void makePubK() //공개 키 생성
        {
            pubKList.Clear();
            for (int i = 2; i < phiN; i++)
            {
                if (i != p && i != q && (i < phiN) && (GCD(i, phiN) == 1))  //p와q가 아니고 파이엔과 서로소인 수
                    pubKList.Add(i);
            }
        }
        private void selectPubk()   //공개 키 후보 리스트에서 선택
        {
            Random r = new Random(SEED + System.DateTime.Now.Millisecond);
            pubK = pubKList[r.Next(pubKList.Count)];
        }
        private void makePriK() //개인 키 후보 생성
        {
            priKList.Clear();
            for (int i = 2; i < phiN; i++)
                if (pubK != i && (pubK * i) % phiN == 1)    //
                    priKList.Add(i);
        }
        private void selectPriK()   //개인 키 후보 리스트에서 선택
        {
            int iters = 0;
            int count = priKList.Count;
            while (count == 0)   //공개 키에 만족하는 개인 키가 없을 시 공개 키 변경
            {
                iters++;
                makePriK();
                count = priKList.Count;
                if (iters == 10)
                {
                    selectPubk();
                    iters = 0;
                }
            }
            priK = priKList[0];
        }
        private bool isPrime(int n)   //소수인지 확인
        {
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        private int GCD(int a, int b)   //최대공약수 구하기
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }
    }
}