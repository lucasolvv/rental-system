using RentalSystem.Domain.Entities;
using RentalSystem.Communication.Requests.Motorcycles;
using RentalSystem.Communication.Responses;
namespace RentalSystem.Application.UseCases.Motorcycles.GetMotorcycleUseCases
{
    public interface IGetMotorcycleUseCase
    {
        Task<IEnumerable<ResponseGetMotorcycleJson>> ExecuteAsync(RequestGetMotorcycleByPlateJson request);
        Task<ResponseGetMotorcycleJson> GetMotorcycleByIdAsync(Guid id);
    }
}
