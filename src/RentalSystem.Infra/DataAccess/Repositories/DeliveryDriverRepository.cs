using RentalSystem.Domain.Repositories.DeliveryDriver;
using RentalSystem.Domain.Entities;
namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class DeliveryDriverRepository : IDeliveryDriverWriteOnlyRepository
    {
        private readonly RentalSystemDbContext _dbContext;
        public DeliveryDriverRepository(RentalSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateDeliveryDriverAsync(DeliveryDriver deliveryDriver)
        {
            await _dbContext.DeliveryDrivers.AddAsync(deliveryDriver);
        }
    }
}
