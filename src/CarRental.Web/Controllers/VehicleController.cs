using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicle _vehicle;
        public VehicleController(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            var vehicle = await _vehicle.SelectAsync();
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> Post([FromBody] Vehicle vehicle )
        {
            var newvehicle = new Vehicle(vehicle.Model, vehicle.PriceDay, vehicle.PriceHour);
            await _vehicle.InsertAsync(newvehicle);
            return vehicle;
        }
    }
}