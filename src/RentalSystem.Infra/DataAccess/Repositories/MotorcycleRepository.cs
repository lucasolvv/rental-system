using Microsoft.EntityFrameworkCore;
using RentalSystem.Domain.Contracts.MotorcycleContracts;
using RentalSystem.Domain.Entities;

namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class MotorcycleRepository : IMotorcycleReadOnlyContract, IMotorcycleWriteOnlyContract
    {
        private readonly RentalSystemDbContext _dbContext;

        public MotorcycleRepository(RentalSystemDbContext context) => _dbContext = context;

        public async Task CreateMotorcycleAsync(Motorcycle motorcycle)
        {
            await _dbContext.Motorcycles.AddAsync(motorcycle);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> MotorcycleAlreadyExists(string plate)
        {
            var exists = await _dbContext.Motorcycles.AnyAsync(m => m.LicensePlate.Equals(plate));
            return exists;
        }

        public Task DeleteMotorcycleByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Motorcycle>> GetAllMotorcyclesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Motorcycle> GetMotorcycleByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlateByIdAsync(Guid id, string newPlate)
        {
            throw new NotImplementedException();
        }
    }
}
