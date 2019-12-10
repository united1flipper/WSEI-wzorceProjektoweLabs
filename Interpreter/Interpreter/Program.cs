using System;
using System.Collections.Generic;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższej klasy
    class Context
    {
        private string _input;
        private int _output;

        public Context(string input)
        {
            this._input = input;
        }

        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }

        public int Output
        {
            get { return _output; }
            set { _output = value; }
        }
    }

    abstract class Expression
    {
        // TODO
        public abstract int Multiplier();
        public void Interpret(Context ctx)
        {
            int ctxNumber;

            switch (Multiplier())
            {
                case 1:
                    ctxNumber = (int)Char.GetNumericValue(ctx.Input[2]);
                    break;
                case 5:
                    ctxNumber = (int)Char.GetNumericValue(ctx.Input[1]);
                    break;
                case 25:
                    ctxNumber = (int)Char.GetNumericValue(ctx.Input[0]);
                    break;
                default:
                    ctxNumber = 0;
                    break;
            }
            ctx.Output += ctxNumber * Multiplier();
        }
    }

    // Nie zmieniaj poniższej klasy
    class FirstPositionExpression : Expression
    {
        public override int Multiplier() { return 1; }
    }

    // Nie zmieniaj poniższej klasy
    class SecondPositionExpression : Expression
    {
        public override int Multiplier() { return 5; }
    }

    // Nie zmieniaj poniższej klasy
    class ThirdPositionExpression : Expression
    {
        public override int Multiplier() { return 25; }
    }

    // Nie zmieniaj poniższej klasy
    class Program
    {
        static void Main()
        {
            List<Expression> tree = new List<Expression>();
            tree.Add(new FirstPositionExpression());
            tree.Add(new SecondPositionExpression());
            tree.Add(new ThirdPositionExpression());

            string bathumani = "143";
            Context context = new Context(bathumani);
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }
            Console.WriteLine("{0} = {1}", bathumani, context.Output);

            bathumani = "100";
            context = new Context(bathumani);
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }
            Console.WriteLine("{0} = {1}", bathumani, context.Output);
        }
    }
}