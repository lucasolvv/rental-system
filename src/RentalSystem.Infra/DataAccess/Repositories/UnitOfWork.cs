using RentalSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Infra.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentalSystemDbContext _dbContext;

        public UnitOfWork(RentalSystemDbContext dbContext) => _dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
