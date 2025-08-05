using RentalSystem.Application.Services.Rental;
using RentalSystem.Application.UseCases.Rentals.Validators.ReturnRentalValidators;
using RentalSystem.Domain.Entities;
using RentalSystem.Domain.Repositories;
using RentalSystem.Domain.Repositories.Rental;
using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.UseCases.Rentals.RentalReturnUseCases
{
    public class RentalReturnUseCase : IRentalReturnUseCase
    {
        private readonly IRentalReadOnlyRepository _readRepository;
        private readonly IRentalUpdateOnlyRepository _updateOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRentalCostCalculator _rentalCostCalculator;
        private readonly ReturnRentalValidator _returnValidator;

        public RentalReturnUseCase(
        IRentalReadOnlyRepository readRepository,
        IRentalUpdateOnlyRepository updateOnlyRepository,
        IUnitOfWork unitOfWork,
        IRentalCostCalculator rentalCostCalculator,
        ReturnRentalValidator validator)
        {
            _readRepository = readRepository;
            _updateOnlyRepository = updateOnlyRepository;
            _rentalCostCalculator = rentalCostCalculator;
            _unitOfWork = unitOfWork;
            _returnValidator = validator;
        }

        public async Task<decimal> ExecuteAsync(string rentalId, DateTime dataDevolucao)
        {
            var rental = await _readRepository.GetRentalByIdAsync(rentalId);
            
            await Validate(rental, dataDevolucao);
            
            rental.EndDate = dataDevolucao;
            rental.TotalValue = _rentalCostCalculator.CalculateTotalWithReturn(rental.PlanDays, rental.ExpectedEndDate, dataDevolucao);
            
            await _updateOnlyRepository.UpdateAsync(rental);
            await _unitOfWork.Commit();
            
            return rental.TotalValue ?? 0;
        }

        private async Task Validate(Rental rental, DateTime dataDevolucao)
        {
            _returnValidator.Validate(rental, dataDevolucao);
        }
    }
}
