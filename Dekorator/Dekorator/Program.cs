using System;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższej klasy
    public interface Vehicle
    {
        string Description();
        double Price();
    }

    public abstract class Addition : Vehicle
    {
        // TODO
        protected Vehicle Car;

        public Addition(Vehicle v)
        {
            Car = v;
        }

        public abstract string Description();

        public abstract double Price();
    }

    // Nie zmieniaj poniższej klasy
    public class MazdaMX5 : Vehicle
    {
        string description = "Mazda MX5 silnik 2.0";
        double price = 89000.00;

        public string Description()
        {
            return description;
        }
        public double Price()
        {
            return price;
        }
    }

    // Nie zmieniaj poniższej klasy
    public class FordFocusMk4 : Vehicle
    {
        string description = "Ford Focus silnik EcoBoost 1.5";
        double price = 69400.00;

        public string Description()
        {
            return description;
        }
        public double Price()
        {
            return price;
        }
    }

    public class Premium : Addition
    {
        // TODO
        private string description = ", skórzana tapicerka";
        private double price = 3000;

        public Premium(Vehicle c) : base(c)
        {
        }

        public override string Description()
        {
            return Car.Description()+description;
        }

        public override double Price()
        {
            return Car.Price()+price;
        }
    }

    // Nie zmieniaj poniższej klasy
    public class Comfort : Addition
    {
        private string description = ", ogrzewana szyba przednia";
        private double price = 1500;
        public Comfort(Vehicle c) : base(c)
        {
        }
        public override double Price()
        {
            return Car.Price() + price;
        }

        public override string Description()
        {
            return Car.Description() + description;
        }
    }

    public class Configure
    {
        // TODO
        public Vehicle AddComfort(Vehicle c)
        {
             return c = new Comfort(c);
        }

        public Vehicle AddPremium(Vehicle c)
        {
            return c = new Premium(c);
        }

        public void PrintSpecification(Vehicle c)
        {
            Console.WriteLine($"{c.Description()}; koszt: {c.Price()} zł");
        }
    }

    // Nie zmieniaj poniższej klasy
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new Configure();

            Vehicle miata = new MazdaMX5();
            miata = config.AddComfort(miata);
            miata = config.AddPremium(miata);
            config.PrintSpecification(miata);

            Vehicle focus = new FordFocusMk4();
            focus = config.AddComfort(focus);
            config.PrintSpecification(focus);
        }
    }
}