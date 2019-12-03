using System;
using System.Collections.Generic;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższej klasy
    abstract class Language
    {
        protected string name;

        public Language(string name)
        {
            this.name = name;
        }

        public abstract void Add(Language c);
        public abstract void Remove(Language c);
        public abstract void Display(int depth);
    }

    class LanguageFamily : Language
    {
        // TODO

        private List<Language> LanguageList = new List<Language>();

        public LanguageFamily(string languageName) : base(languageName)
        {
        }

        public override void Add(Language c)
        {
            LanguageList.Add(c);
        }
        public override void Remove(Language c)
        {
            LanguageList.Remove(c);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('*', depth) + name);

            foreach(Language language in LanguageList)
            {
                language.Display(depth + 3);
            }
        }

    }

    // Nie zmieniaj poniższej klasy
    class TerminalLanguage : Language
    {
        public TerminalLanguage(string name)
          : base(name)
        {
        }
        public override void Add(Language c)
        {
            Console.WriteLine("Cannot add to Terminal Language");
        }
        public override void Remove(Language c)
        {
            Console.WriteLine("Cannot remove from a Terminal Language");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('*', depth) + name);
        }
    }

    // Nie zmieniaj poniższej klasy
    class Program
    {
        static void Main()
        {
            LanguageFamily nostratyckie = new LanguageFamily("Języki nostratyckie");
            LanguageFamily euroazjatyckie = new LanguageFamily("Języki euroazjatyckie");
            LanguageFamily altajskie = new LanguageFamily("Języki ałtajskie");
            LanguageFamily uralskie = new LanguageFamily("Języki uralskie");

            uralskie.Add(new LanguageFamily("Języki ugrofińskie"));
            uralskie.Add(new LanguageFamily("Języki samojedzkie"));
            uralskie.Add(new TerminalLanguage("Język jukagirski"));

            altajskie.Add(new TerminalLanguage("Język turecki"));
            altajskie.Add(new TerminalLanguage("Język koreański"));
            altajskie.Add(new TerminalLanguage("Język japoński"));

            euroazjatyckie.Add(altajskie);
            euroazjatyckie.Add(uralskie);
            euroazjatyckie.Add(new LanguageFamily("Języki indoeuropejskie"));

            nostratyckie.Add(euroazjatyckie);
            nostratyckie.Add(new LanguageFamily("Języki kartwelskie"));
            nostratyckie.Add(new LanguageFamily("Języki drawidyjskie"));

            nostratyckie.Display(1);
        }
    }
}
