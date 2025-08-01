using RentalSystem.Domain.Repositories;

namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentalSystemDbContext _dbContext;

        public UnitOfWork(RentalSystemDbContext dbContext) => _dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
