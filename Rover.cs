using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    public class Rover
    {
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
