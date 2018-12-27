using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorVisual
{



    public partial class MazeForm : Form
    {

        public MazeForm()
        {
            InitializeComponent();

           
            //MazeVisual.Image = Global.Maze;
            textBox1.Text = Global.w.ToString();
            textBox2.Text = Global.WallWeight.ToString();
            textBox3.Text = Global.Delay.ToString();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.Maze = new Bitmap(MazeVisual.Width, MazeVisual.Height);
            Global.Canvas = Graphics.FromImage(Global.Maze);
            Global.r = new Random();
            if (int.TryParse(textBox1.Text, out int W)) Global.w = W;
            if (int.TryParse(textBox2.Text, out int WW)) Global.WallWeight = WW;
            if (int.TryParse(textBox3.Text, out int D)) Global.Delay = D;
            button1.Enabled = false;
            Thread t = new Thread(GenerateMaze);
            Global.MazeThread = t;
            t.IsBackground = true;
            t.Start();
            
        }

        private void GenerateMaze()
        {
            //setup
            Global.cols = (int)Math.Floor((double)(MazeVisual.Width / Global.w));
            Global.rows = (int)Math.Floor((double)(MazeVisual.Height / Global.w));
            Cell current;
            Stack<Cell> BackTrack = new Stack<Cell>();

            for (int x = 0; x < Global.rows; x++)
            {
                for (int y = 0; y < Global.cols; y++)
                {
                    Cell cell = new Cell(y, x, Global.w, Global.Canvas);

                    Global.ListOfCells.Add(cell);
                }
            }

            current = Global.ListOfCells.FirstOrDefault();
            BackTrack.Push(current);
            //loop
            while (true)
            {
                Global.Canvas.Clear(Color.White);
                foreach (var item in Global.ListOfCells)
                {
                    item.Show();
                }

                current.Visited = true;
                current.Current = true;
                Cell next = current.CheckNeighbors();

                if (next != null)
                {
                    BackTrack.Push(next);
                    RemoveWalls(current, next);
                    next.Visited = true;
                    current.Current = false;
                    next.Current = true;
                    current = next;
                }
                else
                {
                    current.Current = false;
                    Cell tmp = null;

                    while (tmp == null)
                    {
                        if (BackTrack.Count <= 0) goto EXIT;
                        tmp = BackTrack.Pop();
                        
                    }

                    current = tmp;
                }

                //This is slowing everything
                MazeVisual.Image = Global.Maze;

                Thread.Sleep(Global.Delay);
                //this.Refresh();
               //this.Update();
            }

        EXIT:
            Global.Ready = true;
        }

        private void RemoveWalls(Cell current, Cell next)
        {
            int tmp = current.i - next.i;
            if(tmp > 0)
            {
                current.Left = false;
                next.Right = false;
            }

            if (tmp < 0)
            {
                current.Right = false;
                next.Left = false;
            }

            int tmp2 = current.j - next.j;
            if (tmp2 > 0)
            {
                current.Top = false;
                next.Down = false;
            }

            if (tmp2 < 0)
            {
                current.Down = false;
                next.Top = false;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Point loc = new Point(0, 0);
            e.Graphics.DrawImage(Global.Maze, loc);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Global.Ready)
            {
                DialogResult result = printDialog1.ShowDialog();

                // If the result is OK then print the document.
                if (result == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            else
            {
                MessageBox.Show("Wait...");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Global.MazeThread.Abort();
            Global.Ready = true;
            if (Global.Ready)
            {
                MazeVisual.Image = new Bitmap(100, 100);
                Global.Maze = new Bitmap(MazeVisual.Width, MazeVisual.Height);
                Global.Canvas = Graphics.FromImage(Global.Maze);
                Global.r = new Random();
                Global.cols = (int)Math.Floor((double)(MazeVisual.Width / Global.w));
                Global.rows = (int)Math.Floor((double)(MazeVisual.Height / Global.w));
                Global.ListOfCells = new List<Cell>();
                //MazeVisual.Image = Global.Maze;
                button1.Enabled = true;
                Global.Ready = false;
            }
        }
    }



    public class Cell
    {
        public int i;
        public int j;
        int w;
        Graphics Canvas;
        public bool Top = true;
        public bool Left = true;
        public bool Down = true;
        public bool Right = true;
        public bool Visited = false;
        public bool Current = false;

        public Cell(int i, int j, int w, Graphics Canvas)
        {
            this.i = i;
            this.j = j;
            this.w = w;
            this.Canvas = Canvas;
        }

        public void Show()
        {
            int x = i * w;
            int y = j * w;

            //Canvas.DrawRectangle(new Pen(Brushes.Black, 1), new Rectangle(x, y, w, w));
            if (Visited) Canvas.FillRectangle(Brushes.Gray, x, y, w, w);
            if (Current) Canvas.FillRectangle(Brushes.Red, x, y, w, w);

            if (Top) Canvas.DrawLine(new Pen(Brushes.Black, Global.WallWeight), x, y, x + w, y);
            if (Right) Canvas.DrawLine(new Pen(Brushes.Black, Global.WallWeight), x + w, y, x + w, y + w);
            if (Down) Canvas.DrawLine(new Pen(Brushes.Black, Global.WallWeight), x + w, y + w, x, y + w);
            if (Left) Canvas.DrawLine(new Pen(Brushes.Black, Global.WallWeight), x, y + w, x, y);

            
        }

        public Cell CheckNeighbors()
        {
            List<Cell> Neighbors = new List<Cell>();

            Cell Top = index(this.i, this.j - 1) != -1 ? Global.ListOfCells.ElementAt(index(this.i, this.j - 1)) : null;
            Cell Right = index(this.i + 1, this.j) != -1 ? Global.ListOfCells.ElementAt(index(this.i + 1, this.j)) : null;
            Cell Bottom = index(this.i, this.j + 1) != -1 ? Global.ListOfCells.ElementAt(index(this.i, this.j + 1)) : null;
            Cell Left = index(this.i - 1, this.j) != -1 ? Global.ListOfCells.ElementAt(index(this.i - 1, this.j)) : null;

            if (Top != null && !Top.Visited) Neighbors.Add(Top);
            if (Right != null && !Right.Visited) Neighbors.Add(Right);
            if (Bottom != null && !Bottom.Visited) Neighbors.Add(Bottom);
            if (Left != null && !Left.Visited) Neighbors.Add(Left);

            if (Neighbors.Count > 0)
            {
                
                int rInt = Global.r.Next(0, Neighbors.Count);
                return Neighbors.ElementAt(rInt);
            }
            else
            {
                return null;
            }
        }

        private int index(int ix, int jx)
        {
            if (ix < 0 || jx < 0 || ix > Global.cols - 1  || jx > Global.rows - 1 ) return -1;

            return ix + jx * Global.cols;
        }
    }

    public static class Global
    {
        public static List<Cell> ListOfCells = new List<Cell>();
        public static int cols, rows;
        public static int w = 40;
        public static bool Ready = false;

        public static int Delay = 5;
        public static int WallWeight = 2;
        public static Bitmap Maze;
        public static Graphics Canvas;
        public static Random r;
        public static Thread MazeThread;
    }
}
