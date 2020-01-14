using System;
using System.Collections.Generic;
using System.Linq;

namespace WzorceProjektowe
{
    class Context
    {
        private IStrategy Strategy;
        private List<int> Array;

        public Context()
        {
            this.Array = new List<int> { 32, 1, 98, 22, 11, 45, 30, 12, 28 };
        }

        public void SetStrategy(IStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public void Sort()
        {
            // ToDo
            List<int> data = Strategy.Sort(Array);
            Console.WriteLine("Sortowanie:");
            Console.WriteLine(String.Join(',', data));

        }
    }

    // Nie zmieniaj poniższej implementacji
    public interface IStrategy
    {
        List<int> Sort(List<int> data);
    }

    class SortingAscending : IStrategy
    {
        // ToDo
        public List<int> Sort(List<int> data)
        {
            return data.OrderBy(i => i).ToList();
        }
    }

    class SortingDescending : IStrategy
    {
        // ToDo
        public List<int> Sort(List<int> data)
        {
            return data.OrderByDescending(i => i).ToList();
        }
    }

    // Nie zmieniaj poniższej klasy
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            Console.WriteLine("Ustawiam sortowanie od najmniejszej do największej wartości.");
            context.SetStrategy(new SortingAscending());
            context.Sort();

            Console.WriteLine();

            Console.WriteLine("Ustawiam sortowanie od największej do najmniejszej wartości.");
            context.SetStrategy(new SortingDescending());
            context.Sort();
        }
    }
}