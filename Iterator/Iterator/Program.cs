using System;
using System.Collections;
using System.Collections.Generic;

namespace WzorceProjektowe
{
    public class Human:IEnumerable<string>
    {
        public string Name, FamilyName, Address, Pet;
        public Human(string name, string familyname, string address, string pet)
        {
            Name = name;
            FamilyName = familyname;
            Address = address;
            Pet = pet;
        }


        // TODO
        public IEnumerator<string> GetEnumerator()
        {
            return new Iterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
    public class Iterator : IEnumerator<string>
    {
        // TODO

        private Human _human;
        private int _current = -1;

        public Iterator(Human human)
        {
            _human = human;
        }
        public string Current
        {
            get
            {
                switch (_current)
                {
                    case 0:
                        return _human.Name;
                    case 1:
                        return _human.FamilyName;
                    case 2:
                        return _human.Address;
                    case 3:
                        return _human.Pet;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current <= 3)
                _current++;
            return _current <= 3;
        }

        public void Reset()
        {
            _current = -1;
        }

    }

    // Nie zmieniaj poniższej klasy
    public class Program
    {
        static void Main(string[] args)
        {
            var person = new Human("Harry", "Potter", "4 Privet Drive, Little Whinging, Surrey", "owl");
            foreach (var value in person)
                Console.WriteLine(value);
            person = new Human("Ronald", "Weasley", "The Burrow outside Ottery St.Catchpole", "rat");
            foreach (var value in person)
                Console.WriteLine(value);
        }
    }
}