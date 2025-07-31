using RentalSystem.Domain.Entities;
namespace RentalSystem.Domain.Contracts.MotoContracts
{
    public interface IMotoReadOnlyContract
    {
        public Task<IEnumerable<Moto>> GetAllMotosAsync();
        public Task<bool> MotoAlreadyExists(string placa);
        public Task<Moto> GetMotoByIdAsync(Guid id);
    }
}
