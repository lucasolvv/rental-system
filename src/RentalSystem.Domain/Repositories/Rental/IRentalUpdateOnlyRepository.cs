namespace RentalSystem.Domain.Repositories.Rental
{
    public interface IRentalUpdateOnlyRepository
    {
        Task UpdateAsync(Entities.Rental rental);
    }
}
