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

            public void Copy(Node a)
            {
                this.X = a.X;
                this.Y = a.Y;
            }

            public void AddPoint(int x, int y)
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
