using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BioRhythm
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
    }
    public class BioRhythm
    {
        private DateTime birthDay;
        private DateTime today;

        public BioRhythm(int year, int month, int day)
        {
            this.birthDay = new DateTime(year, month, day, new GregorianCalendar());
            today = DateTime.Now;
        }
        public DateTime Today
        {
            get { return today; }
            set { today = value; }
        }
        public int HowLong(){
            TimeSpan howSpan=today-birthDay;
            return howSpan.Days;
        }
        public void setToday(int year,int month,int day){
            today = new DateTime(year, month, day, new GregorianCalendar());
        }
        public void PreviousDay()
        {
            today = today.AddDays(-1);
        }
        public void Nextday()
        {
            today = today.AddDays(1);
        }
        public double Physical()
        {
            return Math.Sin(2.0 * Math.PI * HowLong() / 23.0);
        }
        public double Emotial()
        {
            return Math.Sin(2.0 * Math.PI * HowLong() / 28.0);
        }
        public double Intellectual()
        {
            return Math.Sin(2.0 * Math.PI * HowLong() / 33.0);
        }
        public double Perceptive()
        {
            return Math.Sin(2.0 * Math.PI * HowLong() / 38.0);
        }
    }
    public class PointFS
    {
        private List<PointF> pointList = new List<PointF>();
        Color color;

        public PointFS(Color c)
        {
            this.color = c;
        }
        public void Add(PointF p)
        {
            pointList.Add(p);
        }
        public void Remove()
        {
            pointList.Clear();
        }
        public void Draw(Graphics g){
                int count=pointList.Count;
                Pen xPen=new Pen(color,1);  
                for(int i=0;i<count-1;i++)
                    g.DrawLine(xPen,pointList[i], pointList[i+1]);
                xPen.Dispose();
            }
    }
}