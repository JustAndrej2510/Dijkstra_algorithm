using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Данные для тестов

            int[,] map = new int[4, 6] { {3,4,4,4,4,3 },
                                         {3,2,1,1,1,4 },
                                         {4,2,1,1,3,4 },
                                         {4,4,2,2,3,4 }};
            //int n = 100, m = 15;
            //int[,] map = new int[n, m];
            //Random rnd = new Random();
            //for (int a = 0; a < n; a++)
            //    for (int b = 0; b < m; b++)
            //        map[a, b] = 0 + rnd.Next(30);

            Rover.CalculateRoverPath(map); // Вызов метода для запуска алгоритма
        }
    }
}
