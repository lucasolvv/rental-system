using RentalSystem.Domain.Entities;
namespace RentalSystem.Domain.Repositories.Motorcycle
{
    public interface IMotorcycleWriteOnlyRepository
    {
        public Task CreateMotorcycleAsync(Entities.Motorcycle motorcycle);
    }
}
