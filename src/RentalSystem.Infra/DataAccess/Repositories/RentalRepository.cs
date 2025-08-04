using RentalSystem.Application.UseCases.Rental.CreateRentalUseCases;
using RentalSystem.Domain.Entities;
using RentalSystem.Domain.Repositories.Rental;
;

namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class RentalRepository : IRentalWriteOnlyRepository
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
    }
}
