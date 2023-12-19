using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindMine
{
    public partial class Form1 : Form
    {
        List<Button> btnList = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                MessageBox.Show("우클릭");
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MessageBox.Show("좌클릭");
            if (e.Button == MouseButtons.Right)
                MessageBox.Show("우클릭");
        }
    }
    public class MineConsole
    {
        public void Chain_Bomb(int x, int y)
        {
            while (x >= 0 && x <= (boardSize - 1) && y >= 0 && y <= (boardSize - 1) &&
                board[x, y].oState != OpenState.OPEN &&
                board[x, y].oState != OpenState.FLAG)
            {
                board[x, y].oState = OpenState.OPEN;
                if (board[x, y].bState == BombState.EMPTY)
                {
                    Chain_Bomb(x - 1, y - 1);
                    Chain_Bomb(x - 1, y);
                    Chain_Bomb(x - 1, y + 1);
                    Chain_Bomb(x, y - 1);
                    Chain_Bomb(x, y + 1);
                    Chain_Bomb(x + 1, y - 1);
                    Chain_Bomb(x + 1, y);
                    Chain_Bomb(x + 1, y + 1);
                }
                break;
            }
        }
        public enum BombState
        {
            EMPTY = 0, ONE = 1, TWO, THREE, FOUR, FIVE, SIX,
            SEVEN, EIGHT, END = 10, FLAGEND = 11, BOMB = 12
        };

        public enum OpenState { CLOSE = 0, OPEN, FLAG, QUESTION };

        public struct Block
        {
            public BombState bState;
            public OpenState oState;
            public bool down;
        };
        public struct Position
        {
            public int row;
            public int col;
        }
        Block[,] board;
        Position[] pos;
        int boardSize = 15;
        int mine = 20;
        public MineConsole()
        {
            board = new Block[boardSize, boardSize];
            pos = new Position[mine];
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                    board[i, j].bState = BombState.EMPTY;
            }
        }
        public void setMine()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int count = 0;
            int row = 0;
            int col = 0;
            while (true)
            {
                if (count == mine) break;
                row = r.Next(boardSize);
                col = r.Next(boardSize);
                if (board[row, col].bState != BombState.BOMB)
                {
                    pos[count].row = row;
                    pos[count].col = col;
                    count++;
                    board[row, col].bState = BombState.BOMB;
                }
            }
        }
        public void CalMine()
        {
            for (int t = 0; t < mine; t++)
            {
                int x = pos[t].row;
                int y = pos[t].col;
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i >= 0 && j >= 0 && i <= (boardSize - 1) && j <= (boardSize - 1) && board[i, j].bState != BombState.BOMB)
                            board[i, j].bState++;
                    }
                }
            }
        }
    }
}
