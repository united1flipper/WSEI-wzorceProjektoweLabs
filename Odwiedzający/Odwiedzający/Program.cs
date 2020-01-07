using System;
using System.Collections.Generic;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższej implementacji
    public interface ICity
    {
        void Accept(IVisitor visitor);
    }

    public class PolishCity : ICity
    {
        public string City;
        public PolishCity(string city)
        {
            City = city;
        }
        public void Accept(IVisitor visitor)
        {
            // TODO
            visitor.Visit(this);
            Console.WriteLine($"Odwiedzam {City}");

        }
    }

    public class NetherlandCity : ICity
    {
        public string City;
        public NetherlandCity(string city)
        {
            City = city;
        }
        public void Accept(IVisitor visitor)
        {
            // TODO
            visitor.Visit(this);
            Console.WriteLine($"Odwiedzam {City}");

        }
    }

    public class USACity : ICity
    {
        public string City;
        public USACity(string city)
        {
            City = city;
        }
        public void Accept(IVisitor visitor)
        {
            // TODO
            visitor.Visit(this);
            Console.WriteLine($"Odwiedzam {City}");
        }
    }

    // Nie zmieniaj poniższej implementacji
    public interface IVisitor
    {
        void Visit(PolishCity element);
        void Visit(NetherlandCity element);
        void Visit(USACity element);
    }

    class Visitor : IVisitor
    {
        private int PolishCounter = 0;
        private int NetherlandCounter = 0;
        private int USACounter = 0;

        public void Visit(PolishCity element)
        {
            // TODO
            PolishCounter++;
        }

        public void Visit(NetherlandCity element)
        {
            // TODO
            NetherlandCounter++;
        }

        public void Visit(USACity element)
        {
            // TODO
            USACounter++;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Byłem w {PolishCounter} Polskich miastach," +
                $" {NetherlandCounter} Holenderskich miastach i {USACounter} miastach USA.");
        }
    }

    // Nie zmieniaj poniższej implementacji
    public class Client
    {
        public static void ClientCode(List<ICity> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
    }

    // Nie zmieniaj poniższej implementacji
    class Program
    {
        static void Main(string[] args)
        {
            List<ICity> components = new List<ICity>
            {
                new PolishCity("Kraków"),
                new PolishCity("Szczecin"),
                new PolishCity("Rzeszów"),
                new PolishCity("Gdańsk"),
                new PolishCity("Katowice"),
                new NetherlandCity("Maastricht"),
                new NetherlandCity("Amsterdam"),
                new USACity("Nowy Jork"),
                new USACity("Waszyngton"),
                new USACity("Boston"),
                new USACity("Princeton"),
                new USACity("Seattle"),
                new USACity("Chicago"),
                new USACity("Huston"),
            };

            var visitor = new Visitor();
            Client.ClientCode(components, visitor);
            visitor.PrintInfo();
        }
    }
}