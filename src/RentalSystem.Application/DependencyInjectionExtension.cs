using Microsoft.Extensions.DependencyInjection;
using RentalSystem.Application.Services.AutoMapper;
using RentalSystem.Application.Services.FileStorage;
using RentalSystem.Application.Services.Rental;
using RentalSystem.Application.UseCases.DeliveryDrivers.CreateDeliveryDriverUseCases;
using RentalSystem.Application.UseCases.DeliveryDrivers.UpdateDriverCnhUseCases;
using RentalSystem.Application.UseCases.Motorcycles.CreateMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.DeleteMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.GetMotorcycleUseCases;
using RentalSystem.Application.UseCases.Motorcycles.UpdateMotorcycleUseCases;
using RentalSystem.Application.UseCases.Rentals.CreateRentalUseCases;
using RentalSystem.Application.UseCases.Rentals.GetRentalUseCases;
using RentalSystem.Application.UseCases.Rentals.RentalReturnUseCases;
using RentalSystem.Application.UseCases.Rentals.Validators.CreateRentalValidators;
using RentalSystem.Application.UseCases.Rentals.Validators.ReturnRentalValidators;
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
            services.AddAutoMapper(typeof(AutoMapping));

        }

        private static void AddUseCases(IServiceCollection services)
        {
            // file storage 
            services.AddScoped<IFileStorageService, FileStorageService>();

            // motorcycles
            services.AddScoped<ICreateMotorcycleUseCase, CreateMotorcycleUseCase>();
            services.AddScoped<IGetMotorcycleUseCase, GetMotorcycleUseCase>();
            services.AddScoped<IUpdateMotorcycleUseCase, UpdateMotorcycleUseCase>();
            services.AddScoped<IDeleteMotorcycleUseCase, DeleteMotorcycleUseCase>();

            // delivery drivers
            services.AddScoped<ICreateDeliveryDriverUseCase, CreateDeliveryDriverUseCase>();
            services.AddScoped<IUpdateDriverCnhUseCase, UpdateDriverCnhUseCase>();

            // rentals
            services.AddScoped<ICreateRentalUseCase, CreateRentalUseCase>();
            services.AddScoped<IRentalCostCalculator, RentalCostCalculator>();
            services.AddScoped<IGetRentalUseCase, GetRentalUseCase>();
            services.AddScoped<IRentalReturnUseCase, RentalReturnUseCase>();

            services.AddScoped<DriverEligibilityValidator>();
            services.AddScoped<RentalPeriodValidator>();
            services.AddScoped<RentalPlanValidator>();
            services.AddScoped<ReturnRentalValidator>();

        }

    }
}
