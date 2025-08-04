namespace RentalSystem.Application.UseCases.Motorcycles.DeleteMotorcycleUseCases
{
    public interface IDeleteMotorcycleUseCase
    {
        Task ExecuteAsync(string id);
    }
}
