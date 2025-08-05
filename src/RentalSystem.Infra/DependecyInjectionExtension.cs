using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalSystem.Application.Services.Messaging;
using RentalSystem.Domain.Repositories;
using RentalSystem.Domain.Repositories.DeliveryDriver;
using RentalSystem.Domain.Repositories.Motorcycle;
using RentalSystem.Domain.Repositories.Rental;
using RentalSystem.Infra.DataAccess;
using RentalSystem.Infra.DataAccess.Repositories;
using RentalSystem.Infra.Messaging.Consumers;
using RentalSystem.Infra.Messaging.EventBus;

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

            services.AddSingleton<IMessageBusService, RabbitMqService>();


            // delivery drivers
            services.AddScoped<IDeliveryDriverWriteOnlyRepository, DeliveryDriverRepository>();
            services.AddScoped<IDeliveryDriverReadOnlyRepository, DeliveryDriverRepository>();
            services.AddScoped<IDeliveryDriverUpdateOnlyRepository, DeliveryDriverRepository>();

            // rentals 
            services.AddScoped<IRentalWriteOnlyRepository, RentalRepository>();
            services.AddScoped<IRentalReadOnlyRepository, RentalRepository>();
            services.AddScoped<IRentalUpdateOnlyRepository, RentalRepository>();

        }

    }
}
