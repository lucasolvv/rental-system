namespace RentalSystem.Domain.Repositories.Rental
{
    public interface IRentalReadOnlyRepository
    {
        Task<IEnumerable<Domain.Entities.Rental>> GetAllRentalsAsync();
        Task<Domain.Entities.Rental> GetRentalByIdAsync(string id);
    }
}
