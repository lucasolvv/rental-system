using RentalSystem.Domain.Entities;
using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.UseCases.Rentals.Validators.ReturnRentalValidators
{
    public class ReturnRentalValidator
    {
        public void Validate(Rental rental, DateTime actualReturnDate)
        {
            if (rental == null)
                throw new ErrorOnValidationException("Locação não encontrada.");

            if (rental.EndDate != rental.ExpectedEndDate)
                throw new ErrorOnValidationException("Esta locação já foi finalizada anteriormente.");

            if (actualReturnDate < rental.StartDate)
                throw new ErrorOnValidationException("A data de devolução não pode ser anterior à data de início da locação.");
        }
    }
}
