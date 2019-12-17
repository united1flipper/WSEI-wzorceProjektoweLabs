using System;
using System.Collections.Generic;

namespace WzorceProjektowe
{
    public abstract class AbstractChatMember
    {
        // TODO
        public string Name = null;
        protected AbstractChatroom _currentChatroom = null;
        public abstract void Receive(string message);
        public void Enter(AbstractChatroom chatroom)
        {
            if (_currentChatroom != null)
                Leave();
            chatroom.Register(this);
            _currentChatroom = chatroom;
        }

        public void Leave()
        {
            if (_currentChatroom != null)
            {
                _currentChatroom.Unregister(this);
                _currentChatroom = null;            }
        }
        public void Send(string msg)
        {
            Console.WriteLine($"{Name} --> {msg}");
            _currentChatroom.Send(msg, this);
        }
    }

    // Nie zmieniaj poniższej klasy
    public class ChatMember : AbstractChatMember
    {
        public ChatMember(string name)
        {
            this.Name = name;
        }
        public override void Receive(string message)
        {
            Console.WriteLine("{0} <-- {1}", Name, message);
        }
    }

    // Nie zmieniaj poniższej klasy
    public abstract class AbstractChatroom
    {
        protected List<AbstractChatMember> ActiveChatMembers = new List<AbstractChatMember>();
        public abstract void Send(string message, AbstractChatMember sender);
        public abstract void Register(AbstractChatMember member);
        public abstract void Unregister(AbstractChatMember member);
    }
    public class Chatroom : AbstractChatroom
    {
        // TODO
        public override void Register(AbstractChatMember member)
        {
            Console.WriteLine($"{member.Name} is joining the room");
            ActiveChatMembers.Add(member);
        }

        public override void Send(string message, AbstractChatMember sender)
        {
            foreach(AbstractChatMember chatMember in ActiveChatMembers)
            {
                if (chatMember != sender)
                    chatMember.Receive(message);
            }
        }

        public override void Unregister(AbstractChatMember member)
        {
            Console.WriteLine($"{member.Name} has left the room");
            ActiveChatMembers.Remove(member);
        }
    }

    // Nie zmieniaj poniższej klasy
    public class Program
    {
        static void Main(string[] args)
        {
            var Tom = new ChatMember("Tom");
            var Jerry = new ChatMember("Jerry");
            var chatroom = new Chatroom();
            Tom.Enter(chatroom);
            Jerry.Enter(chatroom);
            Tom.Send("Where is Jerry?");
            Jerry.Send("Try to guess!");
            Jerry.Leave();
        }
    }
}