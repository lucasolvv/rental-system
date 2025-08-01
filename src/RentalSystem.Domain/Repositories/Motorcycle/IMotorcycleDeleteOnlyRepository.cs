namespace RentalSystem.Domain.Repositories.Motorcycle
{
    public interface IMotorcycleDeleteOnlyRepository
    {
        Task DeleteMotorcycle(Guid id);
    }
}
