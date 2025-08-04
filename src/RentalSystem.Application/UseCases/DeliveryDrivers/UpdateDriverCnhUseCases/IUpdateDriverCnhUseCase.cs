using RentalSystem.Communication.Requests.DeliveryDriver;

namespace RentalSystem.Application.UseCases.DeliveryDrivers.UpdateDriverCnhUseCases
{
    public interface IUpdateDriverCnhUseCase
    {
        Task ExecuteAsync(string id, RequestUpdateDriverCnhJson request);
    }
}
