using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarRental.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicles;
        public VehicleController(IVehicleRepository vehicles)
        {
            _vehicles = vehicles;
        }

        [HttpGet]
        public ActionResult<List<Vehicle>> Get()
        {
            return _vehicles.Get();
        }
      
        [HttpGet("{id:length(24)}", Name = "GetVehicle")]
        public ActionResult<Vehicle> Get(string id)
        {
            var vehicle = _vehicles.Get(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        [HttpPost]
        public ActionResult<Vehicle> Create(Vehicle vehicle)
        {
            _vehicles.Create(vehicle);

            return CreatedAtRoute("GetVehicle", new { id = vehicle.Id.ToString() }, vehicle);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Vehicle vehicle)
        {
            var oneVehicle = _vehicles.Get(id);

            if (oneVehicle == null)
            {
                return NotFound();
            }

            _vehicles.Update(id, vehicle);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var vehicle = _vehicles.Get(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            _vehicles.Remove(vehicle.Id);

            return NoContent();
        }

    }
}