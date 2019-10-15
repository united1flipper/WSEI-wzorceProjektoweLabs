using System;
using System.Collections;
using System.Text;

namespace Budowniczy
{
    public class CodeBuilder
    {
        // TODO
        private readonly string rootName;
        Hashtable fields = new Hashtable();
        
        public CodeBuilder(string rootName)
        {
            this.rootName = rootName;
        }

        public CodeBuilder AddField(string name, string type)
        {
            fields.Add(name, type);
            return this;
        }

        public override string ToString()
        {
            string code = $"public class {rootName}\n";
            code += "{";
            foreach (DictionaryEntry de in fields)
            {
                code+=($"\n  public {de.Value} {de.Key};");
            }
            code+=("\n}");
            return code;

        }


    }

    // Nie zmieniaj poniższej klasy!
    class MainClass
    {
        public static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}