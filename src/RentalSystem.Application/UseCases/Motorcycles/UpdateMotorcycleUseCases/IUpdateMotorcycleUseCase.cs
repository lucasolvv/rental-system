using RentalSystem.Communication.Requests.Motorcycles;

namespace RentalSystem.Application.UseCases.Motorcycles.UpdateMotorcycleUseCases
{
    public interface IUpdateMotorcycleUseCase
    {
        Task ExecuteAsync(string id, string newPlate);
    }
}
