using CarRental.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Repository.Context
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;
        public IClientSessionHandle Session { get; set; }
        private readonly IConfiguration _configuration;
        public MongoContext(IConfiguration configuration)
        {
      
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            _commands = new List<Func<Task>>();
         
            MongoClient = new MongoClient(Environment.GetEnvironmentVariable("MONGOCONNECTION") ?? configuration.GetSection("MongoSettings")
                .GetSection("Connection").Value);

            Database = MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DATABASENAME") ?? configuration
                .GetSection("MongoSettings").GetSection("DatabaseName").Value);

        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);

            Database = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);

        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }
}
