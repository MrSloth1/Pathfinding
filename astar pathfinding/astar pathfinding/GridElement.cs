using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace astar_pathfinding
{
    public class GridElement
    {
        public Rectangle rec;
        public typen typ = typen.OwO;
        public Point pos;
        public int ID;

        public int? ParentID;
        public double startDistance;
        public double homeDistance;
        public double totalCost;

        public GridElement(int x, int y)
        {
            pos = new Point(x, y);
            ID = x * 10 + y;

            rec = new Rectangle(x * 100, y * 100, 100, 100);
        }



        public static int reverseID(int id)
        {
            int x = id / 10;
            int y = id % 10;
            return x + y;
        }
    }




    public enum typen { start,ziel,hinderniss,OwO,traversed }
}
