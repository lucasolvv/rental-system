namespace RentalSystem.Domain.Repositories.Rental
{
    public interface IRentalReadOnlyRepository
    {
        Task<IEnumerable<Entities.Rental>> GetAllRentalsAsync();
        Task<Entities.Rental> GetRentalByIdAsync(string id);
        Task<bool> GetRentalByMotorcycleIdAsync(string motorcycleId);
    }
}
