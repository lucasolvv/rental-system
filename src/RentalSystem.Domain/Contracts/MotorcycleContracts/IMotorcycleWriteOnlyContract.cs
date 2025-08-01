using RentalSystem.Domain.Entities;
namespace RentalSystem.Domain.Contracts.MotorcycleContracts
{
    public interface IMotorcycleWriteOnlyContract
    {
        public Task CreateMotorcycleAsync(Motorcycle motorcycle);
        public Task UpdatePlateByIdAsync(Guid id, string newPlate);
        public Task DeleteMotorcycleByIdAsync(Guid id);
    }
}
