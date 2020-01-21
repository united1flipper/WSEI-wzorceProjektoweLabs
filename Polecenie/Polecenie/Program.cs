using System;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższej implementacji
    public interface ICommand
    {
        void Execute();
    }

    class FirstCommand : ICommand
    {
        // TODO
        public string Text;
        public FirstCommand(string text)
        {
            this.Text = text;
        }
        public void Execute()
        {
            Console.WriteLine($"Pierwsze polecenie wypisuje: \"{this.Text}\"");
        }
    }

    // Nie zmieniaj poniższej implementacji
    class SecondCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Drugie polecenie nie wypisuje niczego konkretnego");
        }
    }

    class ThirdCommand : ICommand
    {
        public int Result;
        // TODO
        public ThirdCommand(int number)
        {
            this.Result = 4 * number;
        }
        public void Execute()
        {
            Console.WriteLine($"Trzecie polecenie wykonuje obliczenia, które dają {this.Result}");
        }
    }

    // Nie zmieniaj poniższej implementacji
    class Invoker
    {
        private ICommand _onStart;
        private ICommand _onMiddle;
        private ICommand _onFinish;

        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }

        public void SetOnMiddle(ICommand command)
        {
            this._onMiddle = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }

        public void ExecuteCommands()
        {
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }

            if (this._onMiddle is ICommand)
            {
                this._onMiddle.Execute();
            }

            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }

    // Nie zmieniaj poniższej implementacji
    class Program
    {
        static void Main()
        {
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new FirstCommand("Jestę programistę"));
            invoker.SetOnMiddle(new SecondCommand());
            invoker.SetOnFinish(new ThirdCommand(2));

            invoker.ExecuteCommands();
        }
    }
}