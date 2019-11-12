using System;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższego interfejsu
    public interface IRectangle
    {
        int Area();
        int GetWidth();
        int GetHeight();
    }
    // Nie zmieniaj poniższej klasy
    public class Rectangle : IRectangle
    {
        int Height;
        int Width;
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }
        public int Area()
        {
            return Width * Height;
        }
        public int GetHeight()
        {
            return Height;
        }
        public int GetWidth()
        {
            return Width;
        }
    }
    // Nie zmieniaj poniższej klasy
    public class Square
    {
        int Side;
        public Square(int side)
        {
            Side = side;
        }
        public int Area()
        {
            return Side * Side;
        }
        public int GetSide()
        {
            return Side;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        Square _square;

        public SquareToRectangleAdapter(Square square)
        {
            _square = square;
        }
        public int Area()
        {
            return _square.Area();
        }

        public int GetHeight()
        {
            return _square.GetSide();
        }

        public int GetWidth()
        {
            return _square.GetSide();
        }
    }
    // Nie zmieniaj poniższej klasy
    public class Program
    {
        static void Main(string[] args)
        {
            Square kwadrat = new Square(4);
            IRectangle adapter = new SquareToRectangleAdapter(kwadrat);
            Console.WriteLine($"Prostokąt o bokach a={adapter.GetHeight()} i b={adapter.GetWidth()} ma pole {adapter.Area()} ");
        }
    }
}