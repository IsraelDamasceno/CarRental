using CarRental.Domain.Entities;
using System.Collections.Generic;

namespace CarRental.Domain.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle Create(Vehicle vehicle);
        List<Vehicle> Get();
        Vehicle Get(string id);
        void Remove(Vehicle vehicle);
        void Remove(string id);
        void Update(string id, Vehicle vehicle);
    }
}
