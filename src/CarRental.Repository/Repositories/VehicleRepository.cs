using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Repository.Interfaces;

namespace CarRental.Repository.Repositories
{
    public class VehicleRepository: BaseRepository<Vehicle>, IVehicle
    {
        public VehicleRepository(IMongoContext context): base(context)
        {
        }
    }
}
