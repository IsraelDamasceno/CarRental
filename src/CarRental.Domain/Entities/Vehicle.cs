using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarRental.Domain.Entities
{
    public class Vehicle
    {

        public Vehicle(string id, string model, double priceOfDay, double priceHour)
        {
            Id = id;
            Model = model;
            PriceOfDay = priceOfDay;
            PriceHour = priceHour;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Model")]
        public string Model { get; private set; }
        [BsonElement("PriceHour")]
        public double PriceHour { get; private set; }
        [BsonElement("PriceOfDay")]
        public double PriceOfDay { get; private set; }
    }
}
