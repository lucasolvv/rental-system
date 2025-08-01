using RentalSystem.Domain.Entities;
namespace RentalSystem.Domain.Repositories.Motorcycle
{
    public interface IMotorcycleWriteOnlyrRepository
    {
        public Task CreateMotorcycleAsync(Entities.Motorcycle motorcycle);
        public Task UpdatePlateByIdAsync(Guid id, string newPlate);
        public Task DeleteMotorcycleByIdAsync(Guid id);
    }
}
