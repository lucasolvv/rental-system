using RentalSystem.Domain.Contracts.MotoContracts;
using AutoMapper;
using RentalSystem.Communication.Requests.Motos;
using RentalSystem.Exceptions.ExceptionBase;
namespace RentalSystem.Application.UseCases.Motos.CreateMotoUseCases
{
    public class CreateMotoUseCase : ICreateMotoUseCase
    {
        private readonly IMotoWriteOnlyContract _motoWriteRepository;
        private readonly IMotoReadOnlyContract _motoReadOnlyRepository;
        private readonly IMapper _mapper;

        public CreateMotoUseCase(IMotoWriteOnlyContract motoWriteRepository, 
                                 IMotoReadOnlyContract motoReadOnlyRepository, 
                                 IMapper mapper)
        {
            _motoWriteRepository = motoWriteRepository;
            _motoReadOnlyRepository = motoReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(RequestCreateMotoJson request)
        {
            await Validate(request);
            
            var moto = _mapper.Map<Domain.Entities.Moto>(request);
            
            await _motoWriteRepository.CreateMotoAsync(moto);
        }

        private async Task Validate (RequestCreateMotoJson request)
        {
            var motoExists = await _motoReadOnlyRepository.MotoAlreadyExists(request.Placa);
            
            if (motoExists)
            {
                throw new ErrorOnValidationException($"Moto com a placa {request.Placa} ja consta em nossa base.");
            } 
            
        }
    }
}
