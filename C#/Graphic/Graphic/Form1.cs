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

namespace Graphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TranslateTransform(0, 0);

            g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);

            MakeShape ms = new MakeShape(this.Width, this.Height);
            ms.Make();
            ms.PrintShape(g);

            base.OnPaint(e);
        }

        private void btnReDraw_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

    }
    public class MakeShape
    {
        byte[,] colors ={{255,0,0},{0,255,0},{0,0,255},{255,255,0},{255,0,255},{0,255,255},
                        {0,128,0},{0,255,128},{255,0,128},{128,0,255},{255,128,0},{128,255,0},};
        List<Shape> shlist = new List<Shape>();
        Random r;
        static int SEED = 37;
        int maxWidth, maxHeight;
        public MakeShape(int maxWidth, int maxHeight)
        {
            r = new Random(SEED++ + DateTime.Now.Millisecond);
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
        }
        public void Make()
        {
            for (int i = 0; i < 30; i++)
            {
                Shape s = new Shape(r.Next(maxWidth), r.Next(maxHeight),
                    r.Next(1, 50), r.Next(1, 50), RGB(r.Next(0, colors.GetLength(0))));
                Circle c = new Circle(r.Next(maxWidth), r.Next(maxHeight),
                    r.Next(1, 50), r.Next(1, 50), RGB(r.Next(0, colors.GetLength(0))));
                Rectangle re = new Rectangle(r.Next(maxWidth), r.Next(maxHeight),
                    r.Next(1, 50), r.Next(1, 50), RGB(r.Next(0, colors.GetLength(0))));
                shlist.Add(s);
                shlist.Add(c);
                shlist.Add(re);
            }
        }
        private Color RGB(int m)
        {
            return Color.FromArgb(colors[m, 0], colors[m, 1], colors[m, 2]);
        }
        public void PrintShape(Graphics g){
            foreach(Shape sh in shlist){
                sh.Draw(g);
            }
        }
    }
            
    public class Shape
    {
        protected Color color;
        protected float x;
        protected float y;
        protected float width;
        protected float height;

        public Shape() : this(0.0f, 0.0f, 10f, 10f, Color.Black) { }

        public Shape(float x, float y, float width, float height)
            : this(x, y, width, height, Color.Black) { }

        public Shape(float x, float y, float width, float height, Color color)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.color = color;
        }
        public virtual void Draw(Graphics g)
        {
            SolidBrush axisXBrush = new SolidBrush(color);
            g.FillEllipse(axisXBrush, x, y, width, height);
        }
        public void Move(float mx, float my)
        {
            this.x += mx;
            this.y += my;
        }
    }
    public class Circle : Shape
    {
        public Circle(float x, float y, float width, float height)
            : base(x, y, width, height) { }

        public Circle(float x, float y, float width, float height, Color color)
            : base(x, y, width, height, color) { }

        public override void Draw(Graphics g)
        {
            Pen xPen = new Pen(color, 1);
            g.DrawArc(xPen, new RectangleF(x, y, width, height), 0.0f, 360.0f);
            xPen.Dispose();
        }
    }
    public class Rectangle : Shape
    {
        public Rectangle(float x, float y, float width, float height)
            : base(x, y, width, height) { }

        public Rectangle(float x, float y, float width, float height, Color color)
            : base(x, y, width, height, color) { }

        public override void Draw(Graphics g)
        {
            Pen xPen = new Pen(color, 1);
            g.DrawRectangle(xPen, x, y, width, height);
            xPen.Dispose();
        }
    }
}