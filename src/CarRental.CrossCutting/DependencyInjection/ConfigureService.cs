using CarRental.Domain.Interfaces;
using CarRental.Repository.Repositories;
using CarRental.Service.Interfaces;
using CarRental.Service.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CarRental.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITaxService, BrazilTaxService>();
            serviceCollection.AddScoped<IVehicleRepository, VehicleRepository>();
        }
    }
}
