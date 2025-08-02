namespace RentalSystem.Domain.Repositories.DeliveryDriver
{
    public interface IDeliveryDriverWriteOnlyRepository
    {
        public Task CreateDeliveryDriverAsync(Entities.DeliveryDriver deliveryDriver);
    }
}
