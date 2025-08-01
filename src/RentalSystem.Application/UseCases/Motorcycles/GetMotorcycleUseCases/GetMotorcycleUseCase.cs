using AutoMapper;
using RentalSystem.Communication.Requests.Motorcycles;
using RentalSystem.Communication.Responses;
using RentalSystem.Domain.Repositories.Motorcycle;

namespace RentalSystem.Application.UseCases.Motorcycles.GetMotorcycleUseCases
{
    public class GetMotorcycleUseCase : IGetMotorcycleUseCase
    {
        private readonly IMotorcycleReadOnlyRepository _motorcycleReadOnlyRepository;
        private readonly IMapper _mapper;

        public GetMotorcycleUseCase(IMotorcycleReadOnlyRepository motorcycleReadOnlyRepository, IMapper mapper)
        {
            _motorcycleReadOnlyRepository = motorcycleReadOnlyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponseGetMotorcycleJson>> ExecuteAsync(RequestGetMotorcycleByPlateJson request)
        {
            if (string.IsNullOrEmpty(request.Placa))
            {
                var allMotorcycles = await _motorcycleReadOnlyRepository.GetAllMotorcyclesAsync();
                return _mapper.Map<IEnumerable<ResponseGetMotorcycleJson>>(allMotorcycles);
            }

            var motorcycles = await _motorcycleReadOnlyRepository.GetMotorcycleByPlateAsync(request.Placa);
            return _mapper.Map<IEnumerable<ResponseGetMotorcycleJson>>(motorcycles);

        }
    }
}
