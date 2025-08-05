using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.UseCases.Rentals.Validators.CreateRentalValidators
{
    public class RentalPeriodValidator
    { 
        public void Validate(DateTime startDate, DateTime endDate, DateTime expectedEndDate)
        {
            var today = DateTime.UtcNow.Date;
            var minimumStartDate = today.AddDays(1);

            if (startDate.Date != minimumStartDate)
                throw new ErrorOnValidationException("A data de início deve ser o primeiro dia após a data de criação.");
            
            if (endDate <= startDate)
                throw new ErrorOnValidationException("A data de término deve ser após a data de início.");

            if (expectedEndDate < startDate || expectedEndDate > endDate)
                throw new ErrorOnValidationException("A data de previsão de término deve estar entre o início e o término.");

        }
    }
}
