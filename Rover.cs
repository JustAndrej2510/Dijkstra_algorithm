using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    public class Rover
    {
        public class Node
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Node() { }
            public Node(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            

        }
        public static void CalculateRoverPath(int[,] map)
        {

        }
        private static int CalculatePower(int prev, int cur)
        {
            int power = (cur - prev);
            if (power < 0)
                power *= -1;
            power = 1 + power;

            return power;
        }
    }

}
