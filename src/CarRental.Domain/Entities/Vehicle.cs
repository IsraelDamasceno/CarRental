using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRental.Domain.Entities
{
    public class Vehicle
    {
        public Vehicle(string model, Double priceDay, Double priceHour)
        {
             
            Model = model;
            PriceDay = priceDay;
            PriceHour = priceHour;
        }
        [BsonElement("Model")]
        public string Model { get; private set; }
        [BsonElement("PriceDay")]
        public Double PriceDay { get; private set; }
        [BsonElement("PriceHour")]
        public Double PriceHour { get; private set; }
    }
}
