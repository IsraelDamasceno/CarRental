using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace CarRental.Repository.Persistence
{
    public class MongoDbPersistence
    {
        public static void Configure()
        {
            VehicleMap.Configure();

            // Set Guid to CSharp style (with dash -)
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}
