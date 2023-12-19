using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subway
{
    public partial class Form1 : Form
    {
        Form2 allPath;
        private String[] station = { "대구역","중앙로","반월당","명덕","교대","영대병원"
                         ,"내당","반고개","신남","경대병원","대구은행"
                         ,"달성공원","서문시장","남산","건들바위","대봉교"};
        private int[,] path;
        private Floyd floyd;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = station;
            comboBox2.DataSource = station.Clone();
            richTextBox1.Text = "1호선 - 0.대구역 1.중앙로 2.반월당 3.명덕 4.교대 5.영대병원\n"
                    + "2호선 - 6.내당 7.반고개 8.신남 9.경대병원 10.대구은행\n"
                    + "3호선 - 11.달성공원 12.서문시장 13.남산 14.건들바위 15.대봉교";
            makePath();
            floyd = new Floyd(station, path);
            floyd.Distance();
        }
        private void makePath()
        {
            path = new int[station.Length, station.Length];
            for (int i = 0; i < path.GetLength(0); i++)
            {
                for (int j = 0; j < path.GetLength(0); j++)
                {
                    if (i == j)
                        path[i, j] = 0;
                    else
                        path[i, j] = 99;
                }
            }
            List<int> except = new List<int>(); //앞뒤에 역이 하나만 있는 곳
            except.Add(0);  //except(0)
            except.Add(5);  //except(1)
            except.Add(6);
            except.Add(10);
            except.Add(11);
            except.Add(15);
            except.Add(9);  //여기서부터 교차역 설정
            except.Add(8);
            except.Add(14);
            except.Add(12);

            for (int i = 0; i < path.GetLength(0); i++)
            {
                for (int j = 0; j < path.GetLength(0); j++)
                {
                    if (i == 13)
                        continue;
                    if (except.Contains(i))
                    {
                        if (except.IndexOf(i) % 2 == 0)
                            path[i, i + 1] = 1;
                        else
                            path[i, i - 1] = 1;
                    }
                    else
                    {
                        path[i, i - 1] = 1;
                        path[i, i + 1] = 1;
                    }
                }
            }
            cross(2, 8);    //교차역 설정
            cross(2, 9);
            cross(3, 13);
            cross(3, 14);
            cross(8, 12);
            cross(8, 13);
        }
        public void cross(int i, int j)
        {
            path[i, j] = 1;
            path[j, i] = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            floyd.result = "";
            lbResult.Text = "";
            floyd.Path(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
            lbResult.Text = floyd.name[comboBox1.SelectedIndex] + " -> " + floyd.result
                + floyd.name[comboBox2.SelectedIndex];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            allPath = new Form2();
            for (int i = 0; i < path.GetLength(0); i++)
            {
                for (int j = 0; j < path.GetLength(0); j++)
                {
                    if (i == j)
                        continue;
                    floyd.result = "";
                    floyd.Path(i, j);
                    allPath.richTextBox1.AppendText("["+floyd.name[i]+"->"+ floyd.name[j]+"] : "
                    +floyd.name[i] + "->" + floyd.result + floyd.name[j] + "\r\n");
                }
            }
            allPath.richTextBox1.SelectionStart = 0;
            allPath.Show();
        }
    }
    public class Floyd
    {
        private int[,] data;
        private int[,] p;
        public string[] name;
        public string result;

        public Floyd(string[] name, int[,] data)
        {
            this.data = data;
            p = new int[data.GetLength(0), data.GetLength(0)];
            this.name = name;
        }
        public void Distance()
        {
            for (int i = 0; i < data.GetLength(0); i++)
                for (int j = 0; j < data.GetLength(0); j++)
                    p[i, j] = -1;
            for (int k = 0; k < data.GetLength(0); k++)
                for (int i = 0; i < data.GetLength(0); i++)
                    for (int j = 0; j < data.GetLength(0); j++)
                        if (data[i, j] > data[i, k] + data[k, j])
                        {
                            p[i, j] = k;
                            data[i, j] = data[i, k] + data[k, j];
                        }
        }
        public void Path(int q, int r)
        {
            if (p[q, r] != -1)
            {
                Path(q, p[q, r]);
                result += name[p[q, r]] + " -> ";
                Path(p[q, r], r);
            }
        }
        public void PrintPath()
        {
            int count = data.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                    Console.Write("{0}  ", data[i, j]);
                Console.WriteLine();
            }
        }
    }
}