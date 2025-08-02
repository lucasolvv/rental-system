namespace RentalSystem.Domain.Repositories.DeliveryDriver
{
    public interface IDeliveryDriverReadOnlyRepository
    {
        Task<bool> DeliveryDriverWithCnhAlreadyExists(string cnh);   
        Task<bool> DeliveryDriverWithCnpjAlreadyExists(string cnpj);
    }
}
