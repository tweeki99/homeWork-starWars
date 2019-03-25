using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace pkw2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                List<Person> cashPeople = new List<Person>();

                while (true)
                {
                    XmlSerializer xslp = new XmlSerializer(typeof(List<Person>));
                    using (var fileStream = new FileStream("person.xml", FileMode.OpenOrCreate))
                    {
                        cashPeople = (List<Person>)xslp.Deserialize(fileStream);
                    }

                    Console.WriteLine("Введите номер персонажа");
                    int peopleId;
                    if (int.TryParse(Console.ReadLine(), out peopleId))
                    {
                        bool isExists = false;
                        foreach (var people in cashPeople)
                        {
                            if (people.Id == peopleId)
                            {
                                isExists = true;
                                PrintPerson(people);
                            }
                        }

                        if (!isExists)
                        {
                            try
                            {
                                string json = client.DownloadString("https://swapi.co/api/people/" + peopleId);
                                Person result = JsonConvert.DeserializeObject<Person>(json);
                                result.Id = peopleId;
                                cashPeople.Add(result);
                                PrintPerson(result);

                                XmlSerializer xs = new XmlSerializer(typeof(List<Person>));

                                using (var fileStream = new FileStream("person.xml", FileMode.OpenOrCreate))
                                {
                                    xs.Serialize(fileStream, cashPeople);
                                }
                            }
                            catch (WebException)
                            {
                                Console.Clear();
                                continue;
                            }
                        }
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
            }
        }
       static public void PrintPerson(Person person)
        {
            Console.WriteLine("Id: " + person.Id);
            Console.WriteLine("Name: " + person.Name);
            Console.WriteLine("Height: " + person.Height);
            Console.WriteLine("Mass: " + person.Mass);
            Console.WriteLine("Hair_color: " + person.HairColor);
            Console.WriteLine("Skin_color: " + person.SkinColor);
            Console.WriteLine("Eye_color: " + person.EyeColor);
            Console.WriteLine("Birth_year: " + person.BirthYear);
            Console.WriteLine("Gender: " + person.Gender);
            Console.WriteLine("Homeworld: " + person.Homeworld);
            Console.WriteLine("Films: ");
            foreach (var film in person.Films)
                Console.WriteLine("   " + film);
            Console.WriteLine("Species: ");
            foreach (var Specie in person.Species)
                Console.WriteLine("   " + Specie);
            Console.WriteLine("Vehicles: ");
            foreach (var Vehicle in person.Vehicles)
                Console.WriteLine("   " + Vehicle);
            Console.WriteLine("Starships: ");
            foreach (var Starship in person.Starships)
                Console.WriteLine("   " + Starship);
            Console.WriteLine("Created: " + person.Created);
            Console.WriteLine("Edited: " + person.Edited);
            Console.WriteLine("Url: " + person.Url);
        }
    }
}
