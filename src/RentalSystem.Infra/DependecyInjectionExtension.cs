using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalSystem.Domain.Repositories.Motorcycle;
using RentalSystem.Domain.Repositories;
using RentalSystem.Infra.DataAccess;
using RentalSystem.Infra.DataAccess.Repositories;
using RentalSystem.Domain.Repositories.DeliveryDriver;

namespace RentalSystem.Infra
{
    public static class DependecyInjectionExtension
    {
        public static void AddInfraDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext_PostGrees(services, configuration);
            AddRepositories(services);
        }

        private static void AddDbContext_PostGrees(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RentalSystemDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // motorcycles
            services.AddScoped<IMotorcycleWriteOnlyRepository, MotorcycleRepository>();
            services.AddScoped<IMotorcycleReadOnlyRepository, MotorcycleRepository>();
            services.AddScoped<IMotorcycleUpdateOnlyRepository, MotorcycleRepository>();
            services.AddScoped<IMotorcycleDeleteOnlyRepository, MotorcycleRepository>();

            // delivery drivers
            services.AddScoped<IDeliveryDriverWriteOnlyRepository, DeliveryDriverRepository>();
            services.AddScoped<IDeliveryDriverReadOnlyRepository, DeliveryDriverRepository>();
        }

    }
}
