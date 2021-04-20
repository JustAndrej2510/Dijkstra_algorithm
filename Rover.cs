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
        const int INF = int.MaxValue; // Некоторое очень большое число 
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
            Node[] resPath = new Node[map.Length]; // Наш итоговый путь

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
            for (int i = 0; i < map.Length; i++)
            {
                resPath[i] = new Node(-1, -1);
            }

            //Устанавливаем значение начальной клетки
            visitedNode[1, 1] = false;
            power[1, 1] = 0;
            Node node = new Node(1, 1);

            // Реализация алгоритма поиска пути с минимальными затратами энергии
            while (!visitedNode[target.X, target.Y])
            {
                int tempMin = INF; // Временная переменная с минимальным значнием следующей клетки
                for (int i = 1; i < sizeN - 1; i++)
                {
                    for (int j = 1; j < sizeM - 1; j++)
                    {
                        if (power[i, j] < tempMin && !visitedNode[i, j])
                        {
                            tempMin = power[i, j]; // Присваиваем значение соседа с минимальной стоимостью и записываем его координаты
                            node.X = i;
                            node.Y = j;
                        }
                    }
                }
                visitedNode[node.X, node.Y] = true; // Помечаем клетку как посещенную


                for (int i = node.X - 1; i < node.X + 2; i++)
                {
                    for (int j = node.Y - 1; j < node.Y + 2; j++)
                    {
                        if (!visitedNode[i, j] && ((i == node.X && j != node.Y) || (i != node.X && j == node.Y))) // Проверяем, посещена ли клетка и не является ли она диагональной,
                        {                                                                                        // т.к. ходить мы можем только на север, юг, запад, восток

                            if ((CalculatePower(tempMap[node.X, node.Y], tempMap[i, j]) + power[node.X, node.Y]) < power[i, j]) // Сравниваем стоимость перехода в клетку с ее предыдущей стоимостью
                            {

                                power[i, j] = CalculatePower(tempMap[node.X, node.Y], tempMap[i, j]) + power[node.X, node.Y]; // Присваиваем значение минимальной стоимости

                                neighbours[i, j].Copy(node); // Записываем соседа, из которого пришли

                            }
                        }
                    }
                }

            }

            fuel = power[target.X, target.Y]; // Стоимость прохождения до конечной точки
            Node pathNode = new Node(target.X, target.Y);// Записываем координаты клеток для восстановления пути

            //Восстановление пути
            while (true)
            {

                resPath[steps].AddPoint(pathNode.X - 1, pathNode.Y - 1);// Добавляем их в итоговый путь
                pathNode.Copy(neighbours[pathNode.X, pathNode.Y]); // Достаем значение соседа, из которого пришли
                steps++;

                if (pathNode.X == 1 && pathNode.Y == 1) // Если дошли до начальной клетки, то выходим из цикла и добавляем координат начальной клетки в итоговый путь
                {
                    resPath[steps].AddPoint(pathNode.X - 1, pathNode.Y - 1);
                    break;
                }
            }


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
