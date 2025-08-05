using RentalSystem.Domain.Repositories.DeliveryDriver;
using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.UseCases.Rentals.Validators.CreateRentalValidators
{
    public class DriverEligibilityValidator
    {
        private readonly IDeliveryDriverReadOnlyRepository _deliveryDriverRepo;
        public DriverEligibilityValidator(IDeliveryDriverReadOnlyRepository deliveryDriverRepo)
        {
            _deliveryDriverRepo = deliveryDriverRepo;
        }
        public async Task ValidateAsync(string driverId)
        {
            var driver = await _deliveryDriverRepo.GetDeliveryDriverById(driverId);

            if (driver == null) throw new ErrorOnValidationException("Entregador nao encontrado pelo ID fornecido.");

            if (!string.Equals(driver.LicenseType, "A", StringComparison.OrdinalIgnoreCase))
            {
                throw new ErrorOnValidationException("O entregador deve possuir uma CNH do tipo A para realizar entregas.");
            }
        }
    }
}
