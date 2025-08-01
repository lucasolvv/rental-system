using AutoMapper;
using RentalSystem.Communication.Requests.Motorcycle;
using RentalSystem.Domain.Contracts.MotorcycleContracts;
using RentalSystem.Domain.Entities;
using RentalSystem.Exceptions.ExceptionBase;
namespace RentalSystem.Application.UseCases.Motorcycles.CreateMotorcycleUseCases
{
    public class CreateMotorcycleUseCase : ICreateMotorcycleUseCase
    {
        private readonly IMotorcycleWriteOnlyContract _motorcycleWriteRepository;
        private readonly IMotorcycleReadOnlyContract _motorcycleReadOnlyRepository;
        private readonly IMapper _mapper;

        public CreateMotorcycleUseCase(IMotorcycleWriteOnlyContract motorcycleWriteRepository, 
                                 IMotorcycleReadOnlyContract motorcycleReadOnlyRepository, 
                                 IMapper mapper)
        {
            _motorcycleWriteRepository = motorcycleWriteRepository;
            _motorcycleReadOnlyRepository = motorcycleReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(RequestCreateMotorcycleJson request)
        {
            await Validate(request);
            
            var motorcycle = _mapper.Map<Motorcycle>(request);
            
            await _motorcycleWriteRepository.CreateMotorcycleAsync(motorcycle);
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
