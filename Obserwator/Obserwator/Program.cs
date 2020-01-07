using System;
using System.Collections.Generic;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższej implementacji
    public enum Genre
    {
        Sport,
        Politics,
        Economy,
        Science
    }
    // Nie zmieniaj poniższej implementacji
    public interface IObserver
    {
        void Update(ISubject subject);
    }
    // Nie zmieniaj poniższej implementacji
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class NewsAgency : ISubject
    {
        public string NewsHeadline;
        public Genre State;

        public void setNewsHeadline(Genre state, string news)
        {
            // TODO
            NewsHeadline = news;
            State = state;
            Notify();
        }

        private List<IObserver> Observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            // TODO
            Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            // TODO
            Observers.Remove(observer);

        }

        public void Notify()
        {
            // TODO
            foreach(IObserver observer in Observers)
            {
                observer.Update(this);
            }
        }
    }

    // Nie zmieniaj poniższej implementacji
    class DailyEconomy : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as NewsAgency).State == Genre.Economy)
            {
                Console.WriteLine($"DailyEconomy publikuje artykuł \"{(subject as NewsAgency).NewsHeadline}\"");
            }
        }
    }

    class NationalGeographic : IObserver
    {
        // TODO
        public void Update(ISubject subject)
        {
            if ((subject as NewsAgency).State == Genre.Science)
            {
                Console.WriteLine($"NationalGeographic publikuje artykuł \"{(subject as NewsAgency).NewsHeadline}\"");
            }
        }
    }

    class NewYorkTimes : IObserver
    {
        // TODO
        public void Update(ISubject subject)
        {
            Console.WriteLine($"NewYorkTimes publikuje artykuł \"{(subject as NewsAgency).NewsHeadline}\"");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var newsAgency = new NewsAgency();
            var dailyEconomy = new DailyEconomy();
            var newYork = new NewYorkTimes();
            var nationalGeographic = new NationalGeographic();

            newsAgency.Attach(dailyEconomy);
            newsAgency.Attach(newYork);
            newsAgency.Attach(nationalGeographic);

            newsAgency.setNewsHeadline(Genre.Economy, "USA is going bancrupt!");
            newsAgency.setNewsHeadline(Genre.Science, "Life on Alpha Centauri");
            newsAgency.setNewsHeadline(Genre.Sport, "Adam Małysz is the greatest sportsman in the history of mankind");
            newsAgency.setNewsHeadline(Genre.Economy, "CD Project RED value has grown by 500% in 2020");
            newsAgency.setNewsHeadline(Genre.Science, "Kirkendall effect causing airplanes' engine deteriorate");

            newsAgency.Detach(dailyEconomy);

            newsAgency.setNewsHeadline(Genre.Economy, "Texas is going bancrupt!");
        }
    }
}