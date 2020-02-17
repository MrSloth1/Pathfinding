using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace astar_pathfinding
{
    public partial class Form1 : Form
    {
        public static GridElement[,] Grid = new GridElement[10,10];
        public static List<GridElement> openNodes = new List<GridElement>();
        public static List<GridElement> closedNodes = new List<GridElement>();

        public static int startID;
        public static int zielID;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createGrid();
        }

        void createGrid()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Grid[x, y] = new GridElement(x,y);
                }
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var ge in Grid)
            {
                if (ge.typ == typen.OwO)
                    e.Graphics.DrawRectangle(new Pen(Color.Black), ge.rec);
                else if (ge.typ == typen.ziel)
                    e.Graphics.FillRectangle(Brushes.GreenYellow, ge.rec);
                else if (ge.typ == typen.start)
                    e.Graphics.FillRectangle(Brushes.Green, ge.rec);
                else if (ge.typ == typen.hinderniss)
                    e.Graphics.FillRectangle(Brushes.Black, ge.rec);
                else if (ge.typ == typen.traversed)
                    e.Graphics.FillRectangle(Brushes.Blue, ge.rec);

            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x;
            int y;
            if(e.X >= 100)
            {
                x = e.X / 100;
            }
            else
            {
                x = 0;
            }
            y = e.Y / 100;

            if (comboBox1.Text == "Start")
            {
                Grid[x, y].typ = typen.start;
                startID = Grid[x, y].ID;
            }
            else if (comboBox1.Text == "Ziel")
            {
                Grid[x, y].typ = typen.ziel;
                zielID = Grid[x, y].ID;
            }
            else if (comboBox1.Text == "Hinderniss")
                Grid[x, y].typ = typen.hinderniss;
            else if (comboBox1.Text == "Debug")
                MessageBox.Show(Grid[x, y].typ.ToString());

            this.Refresh();
        }

        private void startButt_Click(object sender, EventArgs e)
        {
            Point p = new Point(startID / 10, startID % 10);
            Alge.currentRec = p;
            closedNodes.Add(Grid[p.X, p.Y]);
            bool finished;
            //do
            //{
                finished = Alge.getNeighbours();
            this.Refresh();
              //  Thread.Sleep(50);
            //} while (!finished);
            
        }
    }
}
