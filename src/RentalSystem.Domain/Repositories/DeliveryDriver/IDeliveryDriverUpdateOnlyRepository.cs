namespace RentalSystem.Domain.Repositories.DeliveryDriver
{
    public interface IDeliveryDriverUpdateOnlyRepository
    {
        void UpdateDeliveryDriverAsync(Entities.DeliveryDriver deliveryDriver);
    }
}
