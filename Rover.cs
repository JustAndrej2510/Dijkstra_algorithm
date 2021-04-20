using System.IO;
namespace Rover
{
    public class Node // Класс для хранения координат клетки
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Node() { }
        public Node(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static bool operator ==(Node a, Node b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Node a, Node b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj as Node == null)
                return false;
            Node node = (Node)obj;
            if (node == this)
                return true;
            else
                return false;
        }

        public void Copy(Node a) // Функция копирования клетки
        {
            this.X = a.X;
            this.Y = a.Y;
        }

        public void AddPoint(int x, int y) // Функция для добавления координат
        {
            this.X = x;
            this.Y = y;
        }

    }

    public class Rover
    {
        const int INF = 999999999; // Некоторое очень большое число 
        public static void CalculateRoverPath(int[,] map) //Расчет минимального пути
        {
            int sizeN = map.GetLength(0) + 2;// Ставим "рамки" для матрицы,
            int sizeM = map.GetLength(1) + 2;//               чтобы не выйти за ее пределы 
            int[,] tempMap = new int[sizeN, sizeM]; // Временная матрица с "рамками"
            int[,] power = new int[sizeN, sizeM]; // Матрица с минимальными затратами до клеток из начальной
            int steps = 0; // Количество шагов
            int fuel; //Итоговый расход из начальной в конечную клетку
            bool[,] visitedNode = new bool[sizeN, sizeM]; // Матрица с посещенными клетками
            Node target = new Node(sizeN - 2, sizeM - 2); // Координаты конечной точки
            Node[,] neighbours = new Node[sizeN, sizeM]; // Матрица с соседями (откуда пришли)
            Node[] resPath = new Node[map.Length - 1]; // Наш итоговый путь

            //Инициализируем переменные начальными значениями
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    if (i == 0 || i == sizeN - 1 || j == 0 || j == sizeM - 1)// Устанавливаем значения "рамки" в INF и помечаем их как посещенные, 
                    {                                                                                        //чтобы при вычислении пути не учитывать их
                        tempMap[i, j] = INF;
                        visitedNode[i, j] = true;
                    }
                    else                                                // Остальные значения заполняем значениями из исходной матрицы и помечаем их как непосещеные
                    {
                        tempMap[i, j] = map[i - 1, j - 1];
                        visitedNode[i, j] = false;
                    }
                    power[i, j] = INF; // Устанавливаем значения стоимости в клетку значением INF
                    neighbours[i, j] = new Node(-1, -1); // Заполняем матрицу соседей начальными данными (пока что любыми)
                }
             
            }

            // Заполняем значения итогового пути (пока что любыми)
            for (int i = 0; i < map.Length - 1; i++)
            {
                resPath[i] = new Node(-1, -1);
            }

            //Устанавливаем значение начальной клетки
            visitedNode[1, 1] = false;
            power[1, 1] = 0;
            Node node = new Node(1, 1);


        }
        private static int CalculatePower(int prev, int cur) // Расчет стоимости перехода в определенную клетку
        {
            int power = (cur - prev);
            if (power < 0)
                power *= -1;
            power = 1 + power;

            return power;
        }
    }

}
