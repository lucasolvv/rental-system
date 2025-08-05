using Microsoft.EntityFrameworkCore;
using RentalSystem.Application.UseCases.Rentals.CreateRentalUseCases;
using RentalSystem.Domain.Entities;
using RentalSystem.Domain.Repositories.Rental;

namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class RentalRepository : IRentalWriteOnlyRepository, IRentalReadOnlyRepository
    {
        private readonly RentalSystemDbContext _dbContext;

        public RentalRepository(RentalSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateRentalAsync(Rental rental)
        {
            await _dbContext.Rentals.AddAsync(rental);
        }
        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await _dbContext.Rentals.ToListAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(string id)
        {
            return await _dbContext.Rentals
                .Include(r => r.Motorcycle)
                .Include(r => r.DeliveryDriver)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
