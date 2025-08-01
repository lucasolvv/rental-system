using AutoMapper;
using RentalSystem.Communication.Requests.Motorcycles;
using RentalSystem.Domain.Repositories.Motorcycle;
using RentalSystem.Domain.Entities;
using RentalSystem.Exceptions.ExceptionBase;
using RentalSystem.Domain.Repositories;
namespace RentalSystem.Application.UseCases.Motorcycles.CreateMotorcycleUseCases
{
    public class CreateMotorcycleUseCase : ICreateMotorcycleUseCase
    {
        private readonly IMotorcycleWriteOnlyRepository _motorcycleWriteRepository;
        private readonly IMotorcycleReadOnlyRepository _motorcycleReadOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMotorcycleUseCase(IMotorcycleWriteOnlyRepository motorcycleWriteRepository, 
                                 IMotorcycleReadOnlyRepository motorcycleReadOnlyRepository, 
                                 IMapper mapper,
                                 IUnitOfWork unitOfWork)
        {
            _motorcycleWriteRepository = motorcycleWriteRepository;
            _motorcycleReadOnlyRepository = motorcycleReadOnlyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(RequestCreateMotorcycleJson request)
        {
            await Validate(request);
            
            var motorcycle = _mapper.Map<Motorcycle>(request);
            
            await _motorcycleWriteRepository.CreateMotorcycleAsync(motorcycle);
            await _unitOfWork.Commit();
        }

        private async Task Validate (RequestCreateMotorcycleJson request)
        {
            var motorcycleExists = await _motorcycleReadOnlyRepository.MotorcycleAlreadyExists(request.Placa);
            
            if (motorcycleExists)
            {
                throw new ErrorOnValidationException($"Moto com a placa {request.Placa} ja consta em nossa base.");
            } 
            
        }
    }
}
