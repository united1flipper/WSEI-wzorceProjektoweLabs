using System;
using System.Collections.Generic;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższej klasy
    class CDProjectStock
    {
        private double SharePrice;

        public CDProjectStock(double sharePrice)
        {
            this.SharePrice = sharePrice;
            Console.WriteLine("Początkowa wartość akcji: " + sharePrice);
        }

        public void SetSharePrice(double sharePrice)
        {
            this.SharePrice = sharePrice;
            Console.WriteLine("Wartość akcji ustalona na: " + sharePrice);
        }

        public IMemento Save()
        {
            return new Memento(this.SharePrice);
        }

        public void Restore(IMemento memento)
        {
            this.SharePrice = memento.GetSharePrice();
            Console.WriteLine($"Cena akcji po zmianie: {SharePrice}");
        }
    }

    // Nie zmieniaj poniższej implementacji
    public interface IMemento
    {
        double GetSharePrice();
    }

    // Nie zmieniaj poniższej klasy
    class Memento : IMemento
    {
        private double SharePrice;

        public Memento(double state)
        {
            this.SharePrice = state;
        }

        public double GetSharePrice()
        {
            return this.SharePrice;
        }
    }

    class Caretaker
    {
        private List<IMemento> Mementos = new List<IMemento>();

        private CDProjectStock StockValue = null;

        public Caretaker(CDProjectStock stockValue)
        {
            this.StockValue = stockValue;
        }

        public void Save()
        {
            // ToDo
            IMemento memento = StockValue.Save();
            Mementos.Add(memento);
        }

        public void Undo()
        {
            // ToDo
            if (Mementos.Count == 0)
                Console.WriteLine("Nie można cofnąć - brak zapisanych danych");
            else
            {
                IMemento memento = Mementos[Mementos.Count-1];
                Console.WriteLine($"Cena akcji przywrócona do: {memento.GetSharePrice().ToString()}");
                StockValue.Restore(memento);     
                Mementos.RemoveAt(Mementos.Count - 1);
            }

        }
    }

    // Nie zmieniaj poniższej klasy
    class Program
    {
        static void Main(string[] args)
        {
            CDProjectStock stockValue = new CDProjectStock(284.8);
            Caretaker caretaker = new Caretaker(stockValue);

            caretaker.Undo();

            caretaker.Save();
            stockValue.SetSharePrice(276.98);

            caretaker.Save();
            stockValue.SetSharePrice(250.02);

            caretaker.Save();
            stockValue.SetSharePrice(299.47);

            caretaker.Undo();
            caretaker.Undo();
        }
    }
}