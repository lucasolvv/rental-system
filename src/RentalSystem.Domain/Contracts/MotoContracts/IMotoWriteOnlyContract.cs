using RentalSystem.Domain.Entities;
namespace RentalSystem.Domain.Contracts.MotoContracts
{
    public interface IMotoWriteOnlyContract
    {
        public Task CreateMotoAsync(Moto moto);
        public Task UpdatePlacaByIdAsync(Guid id, string novaPlaca);
        public Task DeleteMotoByIdAsync(Guid id);
    }
}
