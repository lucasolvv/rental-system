using RentalSystem.Domain.Repositories;
using RentalSystem.Domain.Repositories.Motorcycle;
using RentalSystem.Domain.Repositories.Rental;
using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.UseCases.Motorcycles.DeleteMotorcycleUseCases
{
    public class DeleteMotorcycleUseCase : IDeleteMotorcycleUseCase
    {
        private readonly IMotorcycleDeleteOnlyRepository _deleteRepository;
        private readonly IMotorcycleReadOnlyRepository _readOnlyRepository;
        private readonly IRentalReadOnlyRepository _rentalReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMotorcycleUseCase(IMotorcycleDeleteOnlyRepository repository, 
            IMotorcycleReadOnlyRepository readOnlyRepository, 
            IRentalReadOnlyRepository rentalReadOnlyRepository, 
            IUnitOfWork unitOfWork)
        {
            _deleteRepository = repository;
            _unitOfWork = unitOfWork;
            _readOnlyRepository = readOnlyRepository;
            _rentalReadOnlyRepository = rentalReadOnlyRepository;
        }

        public async Task ExecuteAsync(string id)
        {

            await Validate(id);
            await _deleteRepository.DeleteMotorcycle(id);
            await _unitOfWork.Commit();
        }


        private async Task Validate(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ErrorOnValidationException($"{id} da moto não pode ser vazio.");

            var motorcycle = await _readOnlyRepository.GetMotorcycleByIdAsync(id);

            if (motorcycle is null)
                throw new ErrorOnValidationException($"Moto com id {id} não encontrada.");

            var rental = await _rentalReadOnlyRepository.GetRentalByMotorcycleIdAsync(motorcycle.Id);

            if (rental)
            {
                throw new ErrorOnValidationException($"Não é possível excluir a moto com id {id} porque ela está associada a uma locação.");
            }
        }
    }
}
