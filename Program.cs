using Microsoft.Extensions.Configuration;
using Mongo_Docker;
using MongoDB.Driver;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Docker Demo - Lets use MongoDB");

            // List People
            var client = new MongoClient("mongodb://admin:pass@192.168.86.32:27017");
            var database = client.GetDatabase("MySuperiorDB");
            var collection = database.GetCollection<People>("People");

            var people = await collection.Find<People>(_ => true).ToListAsync();
            Console.WriteLine($"Found {people.Count} records");

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Id}: {person.Name}");
            }

            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }

    }
}