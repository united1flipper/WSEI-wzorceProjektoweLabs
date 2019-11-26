using System;

namespace WzorceProjektowe
{

    public abstract class Message
    {
        // TODO
        public abstract void Send();
    }


    public abstract class MessageSystem
    {
        // TODO
        public Message Msg;
        public void SendMessage()
        {
            Msg.Send();
        }
    }

    // Nie zmieniaj poniższej klasy
    public class AnniversaryMessageSystem : MessageSystem
    {

    }

    // Nie zmieniaj poniższej klasy
    public class MessageEN : Message
    {
        public override void Send()
        {
            Console.WriteLine("Happy Birthday!");
        }
    }

    // Nie zmieniaj poniższej klasy
    public class MessagePL : Message
    {
        public override void Send()
        {
            Console.WriteLine("Wszystkiego najlepszego!");
        }
    }

    // Nie zmieniaj poniższej klasy
    public class MessageDE : Message
    {
        public override void Send()
        {
            Console.WriteLine("Alles Gute!");
        }
    }

    // Nie zmieniaj poniższej klasy
    public class Program
    {
        static void Main(string[] args)
        {
            var MsgSystem = new AnniversaryMessageSystem();
            MsgSystem.Msg = new MessagePL();
            MsgSystem.SendMessage();
            MsgSystem.Msg = new MessageEN();
            MsgSystem.SendMessage();
            MsgSystem.Msg = new MessageDE();
            MsgSystem.SendMessage();
        }
    }
}