using CarRental.Repository.Context;
using CarRental.Service.Interfaces;
using CarRental.Service.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CarRental.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<MongoContext>();
            serviceCollection.AddScoped<ITaxService, BrazilTaxService>();
        }
    }
}
