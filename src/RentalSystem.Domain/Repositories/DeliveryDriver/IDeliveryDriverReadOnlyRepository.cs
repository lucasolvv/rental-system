using RentalSystem.Domain;
namespace RentalSystem.Domain.Repositories.DeliveryDriver
{
    public interface IDeliveryDriverReadOnlyRepository
    {
        Task<bool> DeliveryDriverWithCnhAlreadyExists(string cnh);   
        Task<bool> DeliveryDriverWithCnpjAlreadyExists(string cnpj);
        Task<Entities.DeliveryDriver> GetDeliveryDriverById(string id);
        Task<bool> DeliveryDriverExistsById(string id);
    }
}
