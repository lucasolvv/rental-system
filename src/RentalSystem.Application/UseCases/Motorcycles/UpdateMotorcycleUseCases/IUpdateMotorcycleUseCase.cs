using RentalSystem.Communication.Requests.Motorcycles;

namespace RentalSystem.Application.UseCases.Motorcycles.UpdateMotorcycleUseCases
{
    public interface IUpdateMotorcycleUseCase
    {
        Task ExecuteAsync(Guid id, string newPlate);
    }
}
