using RentalSystem.Communication.Requests.Motorcycles;
using RentalSystem.Communication.Responses;
using RentalSystem.Domain.Repositories;
using RentalSystem.Domain.Repositories.Motorcycle;
using RentalSystem.Exceptions.ExceptionBase;
namespace RentalSystem.Application.UseCases.Motorcycles.UpdateMotorcycleUseCases
{
    public class UpdateMotorcycleUseCase : IUpdateMotorcycleUseCase
    {
        private readonly IMotorcycleUpdateOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMotorcycleUseCase(IMotorcycleUpdateOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(Guid id, string newPlate)
        {
            var motorcycle = await _repository.GetMotorcycleByIdAsync(id);
            if (motorcycle == null)
                throw new MotorcycleNotFoundException($"Não encontramos nenhuma moto em nossa base com o ID {id}.");
            
            motorcycle.LicensePlate = newPlate;
            _repository.UpdateMotorcycle(motorcycle);
            await _unitOfWork.Commit();
        }
    }
}
