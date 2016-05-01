using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {

            Person person1 = new Person("Martin", new DateTime(1992, 11, 04));
            Person person2 = new Person("Mate", new DateTime(1995, 01, 18));
            Person person3 = new Person("Gabor", new DateTime(1932, 05, 10));
            Person person4 = new Person("Mari", new DateTime(1990, 12, 04));

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
            Console.WriteLine(person4);

            Serialize(person1);
            Serialize(person2);
            Serialize(person3);
            Serialize(person4);

            Person desPerson = Deserialize();
            Console.WriteLine("Deserialized person: ");
            Console.WriteLine(desPerson);
            Console.ReadLine();

        }

        private static void Serialize(Person newPerson)
        {
            FileStream fileStream = new FileStream(@"C:\Users\Szakolczai Martin\Desktop\Person.dat", FileMode.Create);
            BinaryFormatter binFormatter = new BinaryFormatter();

            binFormatter.Serialize(fileStream, newPerson);
            fileStream.Close();
        }

        private static Person Deserialize()
        {
            FileStream fileStream = new FileStream(@"C:\Users\Szakolczai Martin\Desktop\Person.dat", FileMode.Open);
            BinaryFormatter binFormatter = new BinaryFormatter();

            var person = (Person)binFormatter.Deserialize(fileStream);

            fileStream.Close();

            return person;
        }
    }
}
