using System;

namespace WzorceProjektowe
{
    abstract class Worker
    {
        protected string Profession;
        public void LiveADay()
        {
            // TODO
            Eat();
            Work();
            Hook();
            Sleep();
        }

        protected void Eat()
        {
            Console.WriteLine($"{Profession} mówi: Jem śniadanie.");
        }

        protected void Sleep()
        {
            Console.WriteLine($"{Profession} mówi: Idę spać.");
        }
        protected abstract void Work();
        protected virtual void Hook() { }
    }

    // Nie zmieniaj poniższej klasy
    class Programmer : Worker
    {
        public Programmer()
        {
            Profession = "Programista";
        }
        protected override void Work()
        {
            Console.WriteLine($"Programista mówi: Pracuję 8 godzin przed komputerem i na spotkaniach.");
        }
        protected override void Hook()
        {
            Console.WriteLine("Programista mówi: Idę na trening.");
        }
    }

    // Nie zmieniaj poniższej klasy
    class Lumberjack : Worker
    {
        public Lumberjack()
        {
            Profession = "Drwal";
        }
        protected override void Work()
        {
            Console.WriteLine($"Drwal mówi: I am a lumberjack and I'm ok, I sleep all night and work all day!");
        }
    }

    // Nie zmieniaj poniższej klasy
    class Client
    {
        public static void ClientCode(Worker abstractClass)
        {
            abstractClass.LiveADay();
        }
    }

    // Nie zmieniaj poniższej klasy
    class Program
    {
        static void Main(string[] args)
        {
            Client.ClientCode(new Programmer());
            Client.ClientCode(new Lumberjack());
        }
    }
}