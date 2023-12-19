using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Hanoi
{
    public partial class Form1 : Form
    {
        Hanoi hanoi;
        List<Move> movList;
        int phase,flagA,flagB,flagC,AY,BY,CY
            ,AC=105,BC=296,CC=487
            ,floor=315,trayHeight=15,interval=191;
        public Form1()
        {
            List<Object> rect = new List<Object>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            init();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            move(movList[phase].getBefore, movList[phase].getAfter);
            phase++;
            if (phase == 7)
                btnNext.Enabled = false;
            btnPrev.Enabled = true;
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            phase--;
            move(movList[phase].getAfter, movList[phase].getBefore);
            if (phase == 0)
                btnPrev.Enabled = false;
            btnNext.Enabled = true;
        }
        public void init(){
            flagA=8;
            flagB=0;
            flagC=0;
            AY=floor-4*trayHeight;
            BY=floor-trayHeight;
            CY=floor-trayHeight;
            recTray0.Location = new Point(AC - recTray0.Size.Width / 2, AY+trayHeight);
            recTray1.Location = new Point(AC - recTray1.Size.Width / 2, AY+2*trayHeight);
            recTray2.Location = new Point(AC - recTray2.Size.Width / 2, AY+3*trayHeight);
            btnPrev.Enabled = false;
            hanoi = new Hanoi();
            hanoi.show();
            movList = hanoi.getList;
            phase = 0;
            btnPrev.Enabled = false;
            btnNext.Enabled = true;
        }
        public void move(string before, string after)
        {
            switch (before)
            {
                case "A":
                    if (after.Equals("B"))
                    {
                        if (flagA >= 5)
                        {
                            recTray0.Location = new Point(recTray0.Location.X + interval, BY);
                            flagA -= 5;
                            flagB += 5;
                        }
                        else if (flagA == 2||flagA==3)
                        {
                            recTray1.Location = new Point(recTray1.Location.X + interval, BY);
                            flagA -= 2;
                            flagB += 2;
                        }
                        else
                        {
                            recTray2.Location = new Point(recTray2.Location.X + interval, BY);
                            flagA -= 1;
                            flagB += 1;
                        }
                        AY += trayHeight;
                        BY -= trayHeight;
                    }
                    else if (after.Equals("C"))
                    {
                        if (flagA >=5 )
                        {
                            recTray0.Location = new Point(recTray0.Location.X + interval * 2, CY);
                            flagA -= 5;
                            flagC += 5;
                        }
                        else if (flagA == 2 || flagA == 3)
                        {
                            recTray1.Location = new Point(recTray1.Location.X + interval * 2, CY);
                            flagA -= 2;
                            flagB += 2;
                        }
                        else
                        {
                            recTray2.Location = new Point(recTray2.Location.X + interval * 2, CY);
                            flagA -= 1;
                            flagC += 1;
                        }
                        AY += trayHeight;
                        CY -= trayHeight;
                    }break;
                case "B":
                    if (after.Equals("A"))
                    {
                        if (flagB >= 5)
                        {
                            recTray0.Location = new Point(recTray0.Location.X - interval, AY);
                            flagB -= 5;
                            flagA += 5;
                        }
                        else if (flagB == 2 || flagB == 3)
                        {
                            recTray1.Location = new Point(recTray1.Location.X - interval, AY);
                            flagB -= 2;
                            flagA += 2;
                        }
                        else
                        {
                            recTray2.Location = new Point(recTray2.Location.X - interval, AY);
                            flagB -= 1;
                            flagA += 1;
                        }
                        BY += trayHeight;
                        AY -= trayHeight;
                    }
                    else if (after.Equals("C"))
                    {
                        if (flagB >= 5)
                        {
                            recTray0.Location = new Point(recTray0.Location.X + interval , CY);
                            flagB -= 5;
                            flagC += 5;
                        }
                        else if (flagB == 2 || flagB == 3)
                        {
                            recTray1.Location = new Point(recTray1.Location.X + interval , CY);
                            flagB -= 2;
                            flagC += 2;
                        }
                        else
                        {
                            recTray2.Location = new Point(recTray2.Location.X + interval , CY);
                            flagB -= 1;
                            flagC += 1;
                        }
                        BY += trayHeight;
                        CY -= trayHeight;
                    } break;
                case "C":
                    if (after.Equals("A"))
                    {
                        if (flagC >= 5)
                        {
                            recTray0.Location = new Point(recTray0.Location.X - interval*2, AY);
                            flagC -= 5;
                            flagA += 5;
                        }
                        else if (flagC == 2 || flagC == 3)
                        {
                            recTray1.Location = new Point(recTray1.Location.X - interval*2, AY);
                            flagC -= 2;
                            flagA += 2;
                        }
                        else
                        {
                            recTray2.Location = new Point(recTray2.Location.X - interval*2, AY);
                            flagC -= 1;
                            flagA += 1;
                        }
                        CY += trayHeight;
                        AY -= trayHeight;
                    }
                    else if (after.Equals("B"))
                    {
                        if (flagC >= 5)
                        {
                            recTray0.Location = new Point(recTray0.Location.X - interval, BY);
                            flagC -= 5;
                            flagB += 5;
                        }
                        else if (flagC == 2 || flagC == 3)
                        {
                            recTray1.Location = new Point(recTray1.Location.X - interval, BY);
                            flagC -= 2;
                            flagB += 2;
                        }
                        else
                        {
                            recTray2.Location = new Point(recTray2.Location.X - interval, BY);
                            flagC -= 1;
                            flagB += 1;
                        }
                        CY += trayHeight;
                        BY -= trayHeight;
                    } break;
            }
        }
    }
    public class Hanoi
    {
        private int tray = 3;  
        private List<Move> movList=new List<Move>();

        public List<Move> getList { get { return movList; } }

        public Hanoi() { }

        public Hanoi(int tray)
        {
            this.tray = tray;
        }
        public void HanoiTower(int n, String a, String b, String c)
        {
            if (n == 1)
            {
                movList.Add(new Move(a,c));
            }
            else
            {
                this.HanoiTower(n - 1, a, c, b);
                movList.Add(new Move(a, c));
                this.HanoiTower(n - 1, b, a, c);
            }
        }
        public void show()
        {
            HanoiTower(tray, "A", "B", "C");
        }
    }
    public class Move
    {
        private String before, after;
        public string getBefore { get { return before; } }
        public string getAfter { get { return after; } }
        public Move(String before, String after)
        {
            this.before = before;
            this.after = after;
        }
    }
}