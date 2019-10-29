using System;

namespace FactoryMethod
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IPersonFactory
    {
        Person CreatePerson(string name);
    }

    public class PersonFactory : IPersonFactory
    {
        int i = 0;
        public Person CreatePerson(string name)
        {
            var person = new Person();
            person.Name = name;
            person.Id = i;
            i++;
            return person;
        }
    }

    // Nie zmieniaj poniższej klasy!
    class MainClass
    {
        public static void Main(string[] args)
        {
            PersonFactory pf = new PersonFactory();
            var geralt = pf.CreatePerson("Geralt");
            var ciri = pf.CreatePerson("Ciri");
            Console.WriteLine(geralt.Name + " " + geralt.Id);
            Console.WriteLine(ciri.Name + " " + ciri.Id);
        }
    }


}
