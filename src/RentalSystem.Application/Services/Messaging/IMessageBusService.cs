
using RentalSystem.Domain.Dtos;
namespace RentalSystem.Application.Services.Messaging
{
    public interface IMessageBusService
    {
        void PublishMotorcycleRegisteredEvent(MotorcycleCreatedEvent motorcycleCreatedEvent);
    }
}
