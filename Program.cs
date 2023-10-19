using Mongo_Docker;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Docker Demo - Lets use MongoDB");

            IConfiguration Configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            string connectionString = $"mongodb://{Configuration.GetConnectionString("my-mongo")}/";

            //string connectionString = Environment.GetEnvironmentVariable("MONGODB_URL");
            connectionString = "mongodb://admin:pass@mongo:27017/";
            Console.WriteLine($"Connection:{connectionString}");

            // List People
            var client = new MongoClient(connectionString);
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