using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalSystem.Domain.Contracts.MotorcycleContracts;
using RentalSystem.Infra.DataAccess;
using RentalSystem.Infra.DataAccess.Repositories;

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
            services.AddScoped<IMotorcycleWriteOnlyContract, MotorcycleRepository>();
            services.AddScoped<IMotorcycleReadOnlyContract, MotorcycleRepository>();
        }

    }
}
