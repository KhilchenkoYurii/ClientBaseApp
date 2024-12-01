﻿using ClientBaseAppMVC.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClientBaseAppMVC.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<ClientsDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Client> Clients =>
            _database.GetCollection<Client>("Clients");
    }
}
