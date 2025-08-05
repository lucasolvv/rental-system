using RentalSystem.Communication.Responses;

namespace RentalSystem.Application.UseCases.Rentals.GetRentalUseCases
{
    public interface IGetRentalUseCase
    {
        Task<ResponseGetRentalJson> GetRentalByIdAsync(string id);
        Task<IEnumerable<ResponseGetRentalJson>> GetAllRentalsAsync();
    }
}
