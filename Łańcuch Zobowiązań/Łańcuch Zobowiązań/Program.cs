using System;
using System.Collections.Generic;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższego interfejsu
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        void Handle(string request);
    }

    // Nie zmieniaj poniższej klasy
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual void Handle(string request)
        {
            if (this._nextHandler != null)
            {
                this._nextHandler.Handle(request);
            }
            else
            {
                Console.WriteLine($"Nikt nie chce tego zjeść: {request}");
            }
        }
    }

    public class MonkeyHandler : AbstractHandler
    {
        // TODO
        public override void Handle(string request)
        {
            if (request == "banan")
                Console.WriteLine($"Małpa zjada {request}");
            else
                base.Handle(request);
        }
    }

    // Nie zmieniaj poniższej klasy
    public class SquirrelHandler : AbstractHandler
    {
        public override void Handle(string request)
        {
            if (request == "orzech")
            {
                Console.WriteLine($"Wiewiórka zjada {request}.");
            }
            else
            {
                base.Handle(request);
            }
        }
    }

    public class DogHandler : AbstractHandler
    {
        // TODO
        public override void Handle(string request)
        {
            if (request == "mięso" || request == "plasterek szynki")
                Console.WriteLine($"Pies zjada {request}");
            else
                base.Handle(request);
        }

    }

    public class CatHandler:AbstractHandler
    {
        // TODO
        public override void Handle(string request)
        {
            if (request == "mięso")
                Console.WriteLine($"Kot zjada {request}");
            else
                base.Handle(request);
        }
    }

    // Nie zmieniaj poniższej klasy
    public class Client
    {
        public static void ClientCode(AbstractHandler handler)
        {
            foreach (var food in new List<string> { "orzech", "banan", "mięso", "plasterek szynki", "lody" })
            {
                Console.WriteLine($"Kto chce {food}?");

                handler.Handle(food);
            }
        }
    }

    // Nie zmieniaj poniższej klasy
    public class Program
    {
        static void Main(string[] args)
        {
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();
            var cat = new CatHandler();

            monkey.SetNext(dog).SetNext(squirrel).SetNext(cat);

            Console.WriteLine("Łańcuch: Małpa > Pies > Wiewiórka > Kot");
            Client.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Podzbiór łańcucha: Wiewiórka > Kot\n");
            Client.ClientCode(squirrel);
        }
    }
}