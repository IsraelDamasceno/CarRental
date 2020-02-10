using CarRental.Domain.Entities;
using CarRental.Service.Interfaces;
using System;

namespace CarRental.Service.Services
{
    public class RentalService
    {
        private ITaxService _taxService;
        public RentalService( ITaxService taxService)
        {
            _taxService = taxService;
        }
        public void ProcessInvoice(CarRent carRent, Vehicle vehicle)
        {
            TimeSpan duration = carRent.Finish.Subtract(carRent.Start);

            double basicPayment = 0.0;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = vehicle.PriceHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = vehicle.PriceDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);

            carRent.Invoice = new Invoice(basicPayment, tax);
        }
    }
}