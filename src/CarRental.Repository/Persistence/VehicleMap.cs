using CarRental.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace CarRental.Repository.Persistence
{
    public class VehicleMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Vehicle>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Model).SetIsRequired(true);
                map.MapIdMember(x => x.PriceDay).SetIsRequired(true);
                map.MapMember(x => x.PriceHour).SetIsRequired(true);
            });
        }
    }
}
