using RentalSystem.Communication.Requests.Rental;
using RentalSystem.Application.UseCases.Rentals.Validators.CreateRentalValidators;
using RentalSystem.Domain.Repositories.Rental;
using AutoMapper;
using RentalSystem.Application.Services.Rental;
using RentalSystem.Domain.Repositories;
namespace RentalSystem.Application.UseCases.Rentals.CreateRentalUseCases
{
    public class CreateRentalUseCase : ICreateRentalUseCase
    {
        private readonly RentalPlanValidator _rentalValidator;
        private readonly DriverEligibilityValidator _driverEligibilityValidator;
        private readonly RentalPeriodValidator _rentalPeriodValidator;
        private readonly IRentalWriteOnlyRepository _repository;
        private readonly IRentalCostCalculator _rentalCostCalculator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRentalUseCase(RentalPlanValidator rentalValidator, 
                               DriverEligibilityValidator driverEligibilityValidator, 
                               RentalPeriodValidator rentalPeriodValidator,
                               IRentalWriteOnlyRepository repository,
                               IMapper mapper,
                               IRentalCostCalculator rentalCostCalculator,
                               IUnitOfWork unitOfWork
            )
        {
            _rentalValidator = rentalValidator;
            _driverEligibilityValidator = driverEligibilityValidator;
            _rentalPeriodValidator = rentalPeriodValidator;
            _repository = repository;
            _mapper = mapper;
            _rentalCostCalculator = rentalCostCalculator;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(RequestCreateMotorcycleRentalJson request)
        {
            // Implementation goes here
            await Validate(request);
            var rental = _mapper.Map<Domain.Entities.Rental>(request);
            rental.Id = $"locacao_{Guid.NewGuid().ToString().Split("-")[1]}";
            rental.DailyRate = _rentalValidator.GetDailyRate(request.Plano);
            rental.TotalValue = _rentalCostCalculator.CalculatePlannedTotal(request.Plano);

            await _repository.CreateRentalAsync(rental);
            await _unitOfWork.Commit();
        }

        private async Task Validate(RequestCreateMotorcycleRentalJson request)
        {
            await _driverEligibilityValidator.ValidateAsync(request.Entregador_id);
            _rentalValidator.Validate(request.Plano);
            _rentalPeriodValidator.Validate(request.Data_inicio, request.Data_termino, request.Data_previsao_termino);
        }
    }
}
