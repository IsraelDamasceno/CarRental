using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CarRental.Repository.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _vehicles;
        public VehicleRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CarRental"));
            var database = client.GetDatabase("CarRental");
            _vehicles = database.GetCollection<Vehicle>("Vehicle");
        }
        public Vehicle Create(Vehicle vehicle)
        {
            _vehicles.InsertOne(vehicle);
            return vehicle;
        }

        public List<Vehicle> Get()
        {
            return _vehicles.Find(livro => true).ToList();
        }

        public Vehicle Get(string id)
        {
            return _vehicles.Find<Vehicle>(v => v.Id == id).FirstOrDefault();
        }

        public void Remove(Vehicle vehicle)
        {
            _vehicles.DeleteOne(v => v.Id == vehicle.Id);
        }

        public void Remove(string id)
        {
            _vehicles.DeleteOne(v => v.Id == id);
        }

        public void Update(string id, Vehicle vehicle)
        {
            _vehicles.ReplaceOne(v => v.Id == id, vehicle);
        }
    }
}
