using Microsoft.EntityFrameworkCore;
using RentalSystem.Domain.Contracts.MotoContracts;
using RentalSystem.Domain.Entities;

namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class MotoRepository : IMotoReadOnlyContract, IMotoWriteOnlyContract
    {
        private readonly RentalSystemDbContext _dbContext;

        public MotoRepository(RentalSystemDbContext context) => _dbContext = context;

        public async Task CreateMotoAsync(Moto moto)
        {
            await _dbContext.Motos.AddAsync(moto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> MotoAlreadyExists(string placa)
        {
            var exists = await _dbContext.Motos.AnyAsync(m => m.Placa.Equals(placa));
            return exists;
        }

        public Task DeleteMotoByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Moto>> GetAllMotosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Moto> GetMotoByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlacaByIdAsync(Guid id, string novaPlaca)
        {
            throw new NotImplementedException();
        }
    }
}
