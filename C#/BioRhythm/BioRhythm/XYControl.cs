using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BioRhythm
{
    public partial class XYControl : UserControl
    {
        Rectangle rect;
        BioRhythm bio;
        DateTime dt;
        Calendar cal;
        int lastOfDay;
        float steps;
        private float orginX = 0.0f;
        private float orginY = 0.0f;
        private float pixH = 100.0f;
        bool isFirst = true;
        PointFS physical = new PointFS(Color.Red);
        PointFS emotial = new PointFS(Color.Blue);
        PointFS intellectual = new PointFS(Color.Green);
        PointFS perceptive = new PointFS(Color.Pink);
        public XYControl()
        {
            InitializeComponent(); 
            rect = this.ClientRectangle;
            this.orginX = rect.Left + 100.0f;
            this.orginY = rect.Top + (rect.Height) / 2;
            this.BackColor = Color.White;
            this.remove();
        }
        public void DrawCross(Graphics g)
        {  //기준선 그리기(추가)
            Pen xPen = new Pen(Color.Black, 1);
            Font font = new Font("Ariel", 9);
            SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
            StringFormat format = new StringFormat();
            g.DrawLine(xPen, new Point((int)orginX, (int)orginY), new Point(570, (int)orginY)); //가로
            g.DrawLine(xPen, new Point((int)orginX, 30), new Point((int)orginX, 280));  //세로
            for (int i = 1; i <= lastOfDay; i++)    //날짜 그리기
                g.DrawString((i).ToString(), font, brush
                    , new Point((int)orginX + (i - 1) * (470 / lastOfDay), (int)orginY), format);
        }
        public void DrawPhysical(Graphics g)
        {
            Pen xPen = new Pen(Color.Red, 1);
            float stX = this.orginX;
            float stY = this.orginY;
            bio.setToday(dt.Year, dt.Month, 1);
            bio.PreviousDay();
            float xy = stY - pixH * ((float)bio.Physical());
            physical.Add(new PointF(stX, xy));
            for (int i = 1; i <= lastOfDay; i++)
            {
                bio.setToday(dt.Year, dt.Month, i);
                xy = stY - pixH * ((float)bio.Physical());
                physical.Add(new PointF(stX + steps * i, xy));
            }
            physical.Draw(g);
            xPen.Dispose();
        }
        public void DrawEmotial(Graphics g)
        {
            Pen xPen = new Pen(Color.Red, 1);
            float stX = this.orginX;
            float stY = this.orginY;
            bio.setToday(dt.Year, dt.Month, 1);
            bio.PreviousDay();
            float xy = stY - pixH * ((float)bio.Emotial());
            emotial.Add(new PointF(stX, xy));
            for (int i = 1; i <= lastOfDay; i++)
            {
                bio.setToday(dt.Year, dt.Month, i);
                xy = stY - pixH * ((float)bio.Emotial());
                emotial.Add(new PointF(stX + steps * i, xy));
            }
            emotial.Draw(g);
            xPen.Dispose();
        }
        public void DrawIntellectual(Graphics g)
        {
            Pen xPen = new Pen(Color.Red, 1);
            float stX = this.orginX;
            float stY = this.orginY;
            bio.setToday(dt.Year, dt.Month, 1);
            bio.PreviousDay();
            float xy = stY - pixH * ((float)bio.Intellectual());
            intellectual.Add(new PointF(stX, xy));
            for (int i = 1; i <= lastOfDay; i++)
            {
                bio.setToday(dt.Year, dt.Month, i);
                xy = stY - pixH * ((float)bio.Intellectual());
                intellectual.Add(new PointF(stX + steps * i, xy));
            }
            intellectual.Draw(g);
            xPen.Dispose();
        }
        public void DrawPerceptive(Graphics g)
        {
            Pen xPen = new Pen(Color.Red, 1);
            float stX = this.orginX;
            float stY = this.orginY;
            bio.setToday(dt.Year, dt.Month, 1);
            bio.PreviousDay();
            float xy = stY - pixH * ((float)bio.Perceptive());
            perceptive.Add(new PointF(stX, xy));
            for (int i = 1; i <= lastOfDay; i++)
            {
                bio.setToday(dt.Year, dt.Month, i);
                xy = stY - pixH * ((float)bio.Perceptive());
                perceptive.Add(new PointF(stX + steps * i, xy));
            }
            perceptive.Draw(g);
            xPen.Dispose();
        }
        private void XYControl_Load(object sender, EventArgs e)
        {
            DateInit(false);
        }
        private void DateInit(bool bs)
        {
            this.label1.Visible = !bs;
            this.label2.Visible = !bs;
            this.dateTimePicker1.Visible = !bs;
            this.dateTimePicker2.Visible = !bs;
        }
        public void remove()
        {
            physical.Remove();
            emotial.Remove();
            intellectual.Remove();
            perceptive.Remove();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.remove();
            bio = new BioRhythm(this.dateTimePicker1.Value.Year
                , this.dateTimePicker1.Value.Month, this.dateTimePicker1.Value.Day);
            dt = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value.Month
                , this.dateTimePicker2.Value.Day, new GregorianCalendar());
            cal = CultureInfo.InvariantCulture.Calendar;
            lastOfDay = cal.GetDaysInMonth(dt.Year, dt.Month, Calendar.CurrentEra);
            //steps = (rect.Width - 140.0f);
            steps = (rect.Width-100)/31;
            Graphics g = e.Graphics;
            if (!isFirst)
            {
                this.DrawCross(g);
                this.DrawPhysical(g);
                this.DrawEmotial(g);
                this.DrawIntellectual(g);
                this.DrawPerceptive(g);     
            }
            this.DrawCross(g);
            base.OnPaint(e);
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.Invalidate();
            this.isFirst = false;
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.Invalidate();
            this.isFirst = false;
        }
    }
}
