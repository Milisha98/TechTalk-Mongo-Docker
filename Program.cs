﻿using Microsoft.Extensions.Configuration;
using Mongo_Docker;
using MongoDB.Driver;

namespace MyApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Docker Demo - Lets use MongoDB");

            // List People
            string connectionString = "mongodb://admin:pass@host.docker.internal:27017";
            Console.WriteLine($"Connection: {connectionString}");

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
            Console.Read();
        }

    }
}