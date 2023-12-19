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
        Cablecar Car;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Car = new Cablecar(30, this.Height/2, Color.Black);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TranslateTransform(0, 0);

            g.FillRectangle(new SolidBrush(Color.Wheat), 0, 0, this.Width, this.Height);

            Liner liner = new Liner(20, this.Height / 2 - 16, this.Width - 20, this.Height / 2 - 16, Color.Red);
            liner.Draw(g);
            
            Car.Draw(g);
            Car.go(10, 0);

            base.OnPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
    public class Cablecar : Shape
    {
        Shape[] sh;
        public Cablecar(float x, float y, Color color)
        {
            sh = new Shape[5];
            sh[0] = new Rectangle(x, y, 40, 20, color);
            sh[1] = new Circle(x + 8, y - 16, 10, 10, color);
            sh[2] = new Circle(x + 24, y - 16, 10, 10, color);
            sh[3] = new Shape(x + 10, y - 16, 6, 6, color);
            sh[4] = new Shape(x + 26, y - 16, 6, 6, color);
        }
        public override void Draw(Graphics g)
        {
            foreach (Shape bus in sh)
                bus.Draw(g);
        }
        public void go(float mx, float my)
        {
            foreach (Shape bus in sh)
                bus.Move(mx, my);
        }
    }
    public class Liner : Shape
    {
        public Liner(float x, float y, float width, float height)
            : base(x, y, width, height) { }

        public Liner(float x, float y, float width, float height, Color color)
            : base(x, y, width, height, color) { }

        public override void Draw(Graphics g)
        {
            Pen xPen = new Pen(color, 1);
            g.DrawLine(xPen, new Point((int)x, (int)y), new Point((int)width, (int)y));
            xPen.Dispose();
        }
    }
    public class Shape
    {
        protected Color color;
        protected float x;
        protected float y;
        protected float width;
        protected float height;

        public Shape():this(0.0f, 0.0f, 10f, 10f, Color.Black) { }

        public Shape(float x, float y, float width, float height)
            :this(x, y, width, height, Color.Black) { }

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