using System;

namespace WzorceProjektowe
{
    public class CoffeeMachine
    {
        public State State { get; set; }
        public CoffeeMachine()
        {
            this.State = new Empty();
        }
        public void AddCoffeeGrains()
        {
            //TODO
            this.State.AddCoffeeGrains(this);

        }
        public void AddMilk()
        {
            //TODO
            this.State.AddMilk(this);
        }
        public void MakeBlackCoffee()
        {
            //TODO
            this.State.MakeBlackCoffee(this);
        }
        public void MakeWhiteCoffee()
        {
            //TODO
            this.State.MakeWhiteCoffee(this);
        }
        public void Process(string command)
        {
            Console.WriteLine(command + ": ");
            switch (command)
            {
                case "1":
                    this.AddCoffeeGrains();
                    break;
                case "2":
                    this.AddMilk();
                    break;
                case "3":
                    this.MakeBlackCoffee();
                    break;
                case "4":
                    this.MakeWhiteCoffee();
                    break;
            }
        }
    }
    // Nie zmieniaj poniższej klasy
    public abstract class State
    {
        public abstract void AddCoffeeGrains(CoffeeMachine context);
        public abstract void AddMilk(CoffeeMachine context);
        public abstract void MakeBlackCoffee(CoffeeMachine context);
        public abstract void MakeWhiteCoffee(CoffeeMachine context);
    }
    public class Empty : State
    {
        //TODO
        public override void AddCoffeeGrains(CoffeeMachine context)
        {
            context.State = new WithCoffeeGrains();
            Console.WriteLine("Dodano ziarna kawy.");
        }

        public override void AddMilk(CoffeeMachine context)
        {
            context.State = new WithMilk();
            Console.WriteLine("Dolano mleko.");
        }

        public override void MakeBlackCoffee(CoffeeMachine context)
        {
            Console.WriteLine("Nie można zrobić kawy - brak ziaren.");
        }

        public override void MakeWhiteCoffee(CoffeeMachine context)
        {
            Console.WriteLine("Nie można zrobić kawy - brak ziaren i mleka.");
        }
    }
    public class WithCoffeeGrains : State
    {
        //TODO
        public override void AddCoffeeGrains(CoffeeMachine context)
        {
            Console.WriteLine("Pojemnik na ziarna kawy pełny.");
        }

        public override void AddMilk(CoffeeMachine context)
        {
            context.State = new WithCoffeeGrainsAndMilk();
            Console.WriteLine("Dolano mleko.");
        }

        public override void MakeBlackCoffee(CoffeeMachine context)
        {
            context.State = new Empty();
            Console.WriteLine("Robię czarną kawę.");
        }

        public override void MakeWhiteCoffee(CoffeeMachine context)
        {
            Console.WriteLine("Nie można zrobić kawy - brak mleka.");
        }
    }

    public class WithMilk : State
    {
        //TODO
        public override void AddCoffeeGrains(CoffeeMachine context)
        {
            context.State = new WithCoffeeGrainsAndMilk();
            Console.WriteLine("Dodano ziarna kawy.");
        }

        public override void AddMilk(CoffeeMachine context)
        {
        }

        public override void MakeBlackCoffee(CoffeeMachine context)
        {            
        }

        public override void MakeWhiteCoffee(CoffeeMachine context)
        {
        }
    }

    public class WithCoffeeGrainsAndMilk : State
    {
        //TODO
        public override void AddCoffeeGrains(CoffeeMachine context)
        {
            Console.WriteLine("Pojemnik na ziarna kawy pełny.");
        }

        public override void AddMilk(CoffeeMachine context)
        {
        }

        public override void MakeBlackCoffee(CoffeeMachine context)
        {
            context.State = new WithMilk();
            Console.WriteLine("Robię czarną kawę.");
        }

        public override void MakeWhiteCoffee(CoffeeMachine context)
        {
            context.State = new Empty();
            Console.WriteLine("Robię białą kawę.");
        }
    }

    // Nie zmieniaj poniższej klasy
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ekspres do kawy");
            Console.WriteLine("1: Wsyp ziarno");
            Console.WriteLine("2: Wlej mleko");
            Console.WriteLine("3: Zrób czarną kawę");
            Console.WriteLine("4: Zrób białą kawę");

            var machine = new CoffeeMachine();

            machine.Process("3");
            machine.Process("4");
            machine.Process("1");
            machine.Process("4");
            machine.Process("2");
            machine.Process("4");
            machine.Process("1");
            machine.Process("1");
            machine.Process("2");
            machine.Process("3");
            machine.Process("1");
            machine.Process("4");
        }
    }
}