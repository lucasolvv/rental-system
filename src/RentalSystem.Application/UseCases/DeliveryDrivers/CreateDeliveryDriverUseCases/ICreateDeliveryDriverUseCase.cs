using RentalSystem.Communication.Requests.DeliveryDriver;

namespace RentalSystem.Application.UseCases.DeliveryDrivers.CreateDeliveryDriverUseCases
{
    public interface ICreateDeliveryDriverUseCase
    {
        Task ExecuteAsync(RequestCreateDeliveryDriverJson request);
    }
}
