using Microsoft.Extensions.DependencyInjection;
using RentalSystem.Application.Services.AutoMapper;
using RentalSystem.Application.UseCases.DeliveryDrivers.CreateDeliveryDriverUseCases;
using RentalSystem.Application.UseCases.Motorcycles.CreateMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.DeleteMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.GetMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.UpdateMotorcycleUseCases;
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
            // motorcycles
            services.AddScoped<ICreateMotorcycleUseCase, CreateMotorcycleUseCase>();
            services.AddScoped<IGetMotorcycleUseCase, GetMotorcycleUseCase>();
            services.AddScoped<IUpdateMotorcycleUseCase, UpdateMotorcycleUseCase>();
            services.AddScoped<IDeleteMotorcycleUseCase, DeleteMotorcycleUseCase>();

            // delivery drivers
            services.AddScoped<ICreateDeliveryDriverUseCase, CreateDeliveryDriverUseCase>();
        }

    }
}
