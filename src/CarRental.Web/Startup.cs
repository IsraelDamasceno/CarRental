using CarRental.CrossCutting.DependencyInjection;
using CarRental.Domain.Interfaces;
using CarRental.Repository.Context;
using CarRental.Repository.Interfaces;
using CarRental.Repository.Persistence;
using CarRental.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRental.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            MongoDbPersistence.Configure();
            services.AddControllers();
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IVehicle, VehicleRepository>();
            ConfigureService.ConfigureDependenciesService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
