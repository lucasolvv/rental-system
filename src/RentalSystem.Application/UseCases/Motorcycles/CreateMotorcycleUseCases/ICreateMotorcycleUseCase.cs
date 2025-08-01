using RentalSystem.Communication.Requests.Motorcycle;
namespace RentalSystem.Application.UseCases.Motorcycles.CreateMotorcycleUseCases
{
    public interface ICreateMotorcycleUseCase
    {
        Task ExecuteAsync(RequestCreateMotorcycleJson request);
    }
}
