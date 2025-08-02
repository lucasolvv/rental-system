using RentalSystem.Domain.Repositories.DeliveryDriver;
using RentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class DeliveryDriverRepository : IDeliveryDriverWriteOnlyRepository, IDeliveryDriverReadOnlyRepository
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
    }
}
