namespace RentalSystem.Domain.Repositories.Motorcycle
{
    public interface IMotorcycleUpdateOnlyRepository
    {
        public Task<Entities.Motorcycle> GetMotorcycleByIdAsync(string id);
        public void UpdateMotorcycle(Entities.Motorcycle motorcycle);
    }
}
