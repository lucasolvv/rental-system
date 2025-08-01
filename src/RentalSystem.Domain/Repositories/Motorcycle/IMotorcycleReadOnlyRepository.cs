namespace RentalSystem.Domain.Repositories.Motorcycle
{
    public interface IMotorcycleReadOnlyRepository
    {
        public Task<IEnumerable<Entities.Motorcycle>> GetAllMotorcyclesAsync();
        public Task<bool> MotorcycleAlreadyExists(string placa);
        public Task<Entities.Motorcycle> GetMotorcycleByIdAsync(Guid id);
        public Task<IEnumerable<Entities.Motorcycle>> GetMotorcycleByPlateAsync(string placa);
    }
}
