namespace RentalSystem.Domain.Repositories.Rental
{
    public interface IRentalWriteOnlyRepository
    {
        Task CreateRentalAsync(Entities.Rental rental);   
        //void Update(Entities.Rental rental);
        //void Delete(Entities.Rental rental);
    }
}
