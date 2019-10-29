using System;

namespace Prototype
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line()
        {
            Start = new Point();
            End = new Point();
        }

        public override string ToString()
        {
            return $"({Start.X}, {Start.Y}) - ({End.X}, {End.Y})";
        }
        public Line DeepCopy()
        {
            Line copy = new Line();
            copy.Start.X = this.Start.X;
            copy.Start.Y = this.Start.Y;
            copy.End.X = this.End.X;
            copy.End.Y = this.End.Y;
            return copy;

        }
    }

    // Nie zmieniaj poniższej klasy!
    class MainClass
    {
        public static void Main(string[] args)
        {
            Line AB = new Line();
            AB.Start.X = 1;
            AB.Start.Y = 1;
            AB.End.X = 8;
            AB.End.Y = 3;
            var BC = AB.DeepCopy();
            BC.Start.X = 19;

            Console.WriteLine(AB);
            Console.WriteLine(BC);
        }
    }
}
