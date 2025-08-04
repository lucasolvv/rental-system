using RentalSystem.Domain.Repositories.DeliveryDriver;
using RentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class DeliveryDriverRepository : IDeliveryDriverWriteOnlyRepository, IDeliveryDriverReadOnlyRepository, IDeliveryDriverUpdateOnlyRepository
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
        public async Task<bool> DeliveryDriverWithCnhAlreadyExists(string cnh)
        {
            return await _dbContext.DeliveryDrivers.AnyAsync(dd => dd.Cnh == cnh);
        }
        public async Task<bool> DeliveryDriverWithCnpjAlreadyExists(string cnpj)
        {
            return await _dbContext.DeliveryDrivers.AnyAsync(dd => dd.Cnpj == cnpj);
        }
        public async Task<bool> DeliveryDriverExistsById(string id)
        {
            return await _dbContext.DeliveryDrivers.AnyAsync(dd => dd.Id == id);
        }
        public async Task<DeliveryDriver> GetDeliveryDriverById(string id)
        {
            return await _dbContext.DeliveryDrivers.FirstOrDefaultAsync(dd => dd.Id == id);
        }

        public void UpdateDeliveryDriverAsync(DeliveryDriver deliveryDriver)
        {
            _dbContext.DeliveryDrivers.Update(deliveryDriver);
        }
    }
}
