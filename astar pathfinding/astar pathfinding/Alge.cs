using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace astar_pathfinding
{
    class Alge
    {
        public static Point currentRec;
        public  static Point cheapestRec;

        /*public static void calcDistance(GridElement[,] Grid)
        {
            int xdif;
            int ydif;
            foreach (var ge in Grid)
            {
                xdif = Form1.startID / 10 - ge.x;
                ydif = Form1.startID % 10 - ge.y;

                ge.startDistance = xdif * 10 + ydif;

                xdif = Form1.zielID / 10 - ge.x;
                ydif = Form1.zielID % 10 - ge.y;

                ge.startDistance = xdif * 10 + ydif;
                ge.totalCost    todo
            }
        } */

        /*public static void calcDistance(Point p,int parentID)
        {

            if(Form1.Grid[p.X,p.Y].ParentID == null)
            {
                //time to search for the best parent in the neighbourhood
                checkNeighbours(p.X, p.Y);
            }
            else
            {

            }
        } */

        public static void checkOpen()
        {
            //ermittle den günstigsten node
            foreach (var ge in Form1.openNodes)
            {
                checkBlock(ge.pos);
            }

            

        }

        public static bool getNeighbours()
        {
            for(int x = currentRec.X -1;x <= currentRec.X + 1;x++)
            {
                for (int y = currentRec.Y - 1; y <= currentRec.Y + 1; y++)
                {
                    if (!Form1.closedNodes.Contains(Form1.Grid[x, y]))
                    {
                        calcCost(Form1.Grid[x, y]);
                        Form1.openNodes.Add(Form1.Grid[x, y]);
                    }
                }
            }

            checkOpen();

            GridElement chosenOne = Form1.Grid[cheapestRec.X, cheapestRec.Y];
            if (Form1.Grid[cheapestRec.X, cheapestRec.Y].typ == typen.OwO)
            {
                Form1.Grid[cheapestRec.X, cheapestRec.Y].ParentID = currentRec.X * 10 + currentRec.Y;
                enterGrid(chosenOne);
                Form1.Grid[cheapestRec.X, cheapestRec.Y].typ = typen.traversed;
                currentRec = cheapestRec;

            }
            else if(Form1.Grid[cheapestRec.X, cheapestRec.Y].typ == typen.hinderniss)
            {
                enterGrid(chosenOne);
                getNeighbours();
            }
            else if(Form1.Grid[cheapestRec.X, cheapestRec.Y].typ == typen.ziel)
            {
                return true;
            }

            return false;

        }

        static void calcCost(GridElement ge)
        {
            int xdif;
            int ydif;

            xdif = Form1.startID / 10 - ge.pos.X;
            ydif = Form1.startID % 10 - ge.pos.Y;

            ge.startDistance = xdif + ydif;

            xdif = Form1.zielID / 10 - ge.pos.X;
            if (xdif < 0)
                xdif = 0;
            ydif = Form1.zielID % 10 - ge.pos.Y;
            if (ydif < 0)
                ydif = 0;

            ge.homeDistance = xdif + ydif;
            ge.totalCost = ge.startDistance + ge.homeDistance;

            Form1.Grid[ge.pos.X, ge.pos.Y] = ge;
        }

        static void enterGrid(GridElement ge)
        {
            Form1.closedNodes.Add(ge);
            Form1.openNodes.Remove(ge);

        }

        static void setCurrent(Point p)
        {
            cheapestRec = currentRec;

        }
        public static void checkBlock(Point p)
        {
            if (cheapestRec == null || Form1.Grid[p.X, p.Y].homeDistance < Form1.Grid[cheapestRec.X, cheapestRec.Y].homeDistance  && Form1.Grid[p.X, p.Y].homeDistance >= 0)
            {
                cheapestRec.X = p.X;
                cheapestRec.Y = p.Y;
            }
        }

        //der algorythmus kalkuliert die kosten -> totalcost(kosten des gesammten pfades ab ziel bis block) von ( überprüften block ausgehend vom basisblock(mittelblock)) + basisblock kosten)
    }
}
