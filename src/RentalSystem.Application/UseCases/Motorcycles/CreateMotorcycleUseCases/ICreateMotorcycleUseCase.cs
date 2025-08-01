using RentalSystem.Communication.Requests.Motorcycles;
namespace RentalSystem.Application.UseCases.Motorcycles.CreateMotorcycleUseCases
{
    public interface ICreateMotorcycleUseCase
    {
        Task ExecuteAsync(RequestCreateMotorcycleJson request);
    }
}
