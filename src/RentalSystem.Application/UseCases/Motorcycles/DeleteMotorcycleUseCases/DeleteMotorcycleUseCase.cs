using RentalSystem.Domain.Repositories;
using RentalSystem.Domain.Repositories.Motorcycle;
using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.UseCases.Motorcycles.DeleteMotorcycleUseCases
{
    public class DeleteMotorcycleUseCase : IDeleteMotorcycleUseCase
    {
        private readonly IMotorcycleDeleteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMotorcycleUseCase(IMotorcycleDeleteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ErrorOnValidationException($"{id} invalido");
            }
            await _repository.DeleteMotorcycle(id);
            await _unitOfWork.Commit();
        }
    }
}
