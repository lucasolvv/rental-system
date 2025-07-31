using RentalSystem.Communication.Requests.Motos;
namespace RentalSystem.Application.UseCases.Motos.CreateMotoUseCases
{
    public interface ICreateMotoUseCase
    {
        Task ExecuteAsync(RequestCreateMotoJson request);
    }
}
