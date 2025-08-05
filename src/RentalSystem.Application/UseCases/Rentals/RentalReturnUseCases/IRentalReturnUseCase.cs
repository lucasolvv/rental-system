namespace RentalSystem.Application.UseCases.Rentals.RentalReturnUseCases
{
    public interface IRentalReturnUseCase
    {
        Task<decimal> ExecuteAsync(string rentalId, DateTime dataDevolucao);
    }
}
