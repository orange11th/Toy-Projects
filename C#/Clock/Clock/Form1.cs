using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Clock
{
    public partial class Form1 : Form
    {
        Matrix matrix = new Matrix();
        PointF[] hf = new PointF[4];
        PointF[] mf = new PointF[4];
        PointF[] sf = new PointF[4];

        public Form1()
        {
            InitializeComponent();
            Init();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void Init()
        {
            hf[0] = new PointF(0, -120);
            hf[1] = new PointF(-7, -100);
            hf[2] = new PointF(0, 0);
            hf[3] = new PointF(7, -100);
            mf[0] = new PointF(0, -170);
            mf[1] = new PointF(-5, -150);
            mf[2] = new PointF(0, 0);
            mf[3] = new PointF(5, -150);
            sf[0] = new Point(0, -190);
            sf[1] = new Point(-2, -160);
            sf[2] = new Point(0, -0);
            sf[3] = new Point(2, -160);
            float startH = DateTime.Now.Hour;
            float startM = DateTime.Now.Minute;
            float startS = DateTime.Now.Second;
            matrix.Reset();
            matrix.Rotate((float)((startH - 1) * 60f * 60f) / 120.0f + startM * 0.5f, MatrixOrder.Append);
            matrix.TransformPoints(hf);
            matrix.Reset();
            matrix.Rotate((float)((startM - 1) * 60f) / 10.0f, MatrixOrder.Append);
            matrix.TransformPoints(mf);
            matrix.Reset();
            matrix.Rotate((float)((startS - 1) * 6.0f), MatrixOrder.Append);
            matrix.TransformPoints(sf);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TranslateTransform(200f, 200f);   //폼 중앙을 0,0으로 설정
            DrawCircle(g);
            DrawHour(g);
            DrawMinute(g);
            DrawSecond(g);
            base.OnPaint(e);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "Clock   "+DateTime.Now.Hour+"시 "
                +DateTime.Now.Minute+"분 "+DateTime.Now.Second+"초";
            this.Invalidate();
        }
        private void DrawCircle(Graphics g)
        {
            Pen xPen = new Pen(Color.Black, 2);
            g.DrawArc(xPen, new Rectangle(-200, -200, 400, 400), 0.0f, 360.0f);
            GraphicsPath path = new GraphicsPath();
            Matrix rotateMatrix=new Matrix();
            xPen = new Pen(Color.Black, 1);
            g.DrawArc(xPen, new Rectangle(-195, -195, 390, 390), 0.0f, 360.0f);
            for (int i = 1; i <= 12; i++)
            {
                rotateMatrix.Reset();
                path.Reset();
                path.AddString(i.ToString(), this.Font.FontFamily, 1, 20, new PointF(10.0F, -190.0F),
                    new StringFormat(StringFormatFlags.DirectionRightToLeft));
                rotateMatrix.RotateAt(30.0F * i, new PointF(0f, 0.0F));
                path.Transform(rotateMatrix);
                g.FillPath(new SolidBrush(Color.Black), path);
            }
            path.Dispose();
            xPen.Dispose();
        }
        private void DrawHour(Graphics g)
        {
            matrix.Reset();
            matrix.Rotate(1.0f/120.0f); //초당 1/120도, 60초에 0.5도, 3600초에 30도=1시간
            matrix.TransformPoints(hf);
            g.FillPolygon(new SolidBrush(Color.Red), hf);
        }
        private void DrawMinute(Graphics g)
        {
            matrix.Reset();
            matrix.Rotate(1.0f/10.0f);  //초당 0.1도, 60초에 6도=1분
            matrix.TransformPoints(mf);
            g.FillPolygon(new SolidBrush(Color.Blue), mf);
        }
        private void DrawSecond(Graphics g)
        {
            matrix.Reset();
            matrix.Rotate(6.0f);    //초당 6도 60초에 360도=한바퀴=1분
            matrix.TransformPoints(sf);
            g.FillPolygon(new SolidBrush(Color.LightGreen), sf);
        }
    }
}