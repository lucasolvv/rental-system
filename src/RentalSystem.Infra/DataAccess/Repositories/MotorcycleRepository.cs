using Microsoft.EntityFrameworkCore;
using RentalSystem.Domain.Repositories.Motorcycle;
using RentalSystem.Domain.Entities;

namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class MotorcycleRepository : IMotorcycleReadOnlyRepository, IMotorcycleWriteOnlyrRepository, IMotorcycleUpdateOnlyRepository
    {
        private readonly RentalSystemDbContext _dbContext;

        public MotorcycleRepository(RentalSystemDbContext context) => _dbContext = context;


        public async Task<IEnumerable<Motorcycle>> GetMotorcycleByPlateAsync(string plate)
        {
            return await _dbContext.Motorcycles
                .Where(m => m.LicensePlate.Equals(plate))
                .ToListAsync();
        }

        public async Task CreateMotorcycleAsync(Motorcycle motorcycle)
        {
            await _dbContext.Motorcycles.AddAsync(motorcycle);
        }

        public async Task<IEnumerable<Motorcycle>> GetAllMotorcyclesAsync()
        {
            return await _dbContext.Motorcycles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> MotorcycleAlreadyExists(string plate)
        {
            var exists = await _dbContext.Motorcycles.AnyAsync(m => m.LicensePlate.Equals(plate));
            return exists;
        }

        public void UpdateMotorcycle(Motorcycle motorcycle)
        {
            _dbContext.Motorcycles.Update(motorcycle);
        }

        

        public Task DeleteMotorcycleByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task<Motorcycle> GetMotorcycleByIdAsync(Guid id)
        {
            return await _dbContext.Motorcycles
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task UpdatePlateByIdAsync(Guid id, string newPlate)
        {
            throw new NotImplementedException();
        }
    }
}
