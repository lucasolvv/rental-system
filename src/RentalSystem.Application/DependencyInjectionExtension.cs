using Microsoft.Extensions.DependencyInjection;
using RentalSystem.Application.Services.AutoMapper;
using RentalSystem.Application.UseCases.Motos.CreateMotoUseCases;
namespace RentalSystem.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddScoped(option => new AutoMapper.MapperConfiguration(option =>
            {
                option.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<ICreateMotoUseCase, CreateMotoUseCase>();
        }

    }
}
