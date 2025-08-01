using RentalSystem.Domain.Entities;
namespace RentalSystem.Domain.Contracts.MotorcycleContracts
{
    public interface IMotorcycleReadOnlyContract
    {
        public Task<IEnumerable<Motorcycle>> GetAllMotorcyclesAsync();
        public Task<bool> MotorcycleAlreadyExists(string placa);
        public Task<Motorcycle> GetMotorcycleByIdAsync(Guid id);
    }
}
