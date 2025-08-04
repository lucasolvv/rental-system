using RentalSystem.Communication.Requests.Rental;

namespace RentalSystem.Application.UseCases.Rental.CreateRentalUseCases
{
    public interface ICreateRentalUseCase
    {
        Task ExecuteAsync(RequestCreateMotorcycleRentalJson request);
    }
}
