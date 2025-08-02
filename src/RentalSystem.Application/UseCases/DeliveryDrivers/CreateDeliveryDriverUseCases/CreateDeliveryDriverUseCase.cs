using AutoMapper;
using RentalSystem.Communication.Requests.DeliveryDriver;
using RentalSystem.Domain.Repositories;
using RentalSystem.Domain.Repositories.DeliveryDriver;
using RentalSystem.Domain.Entities;

namespace RentalSystem.Application.UseCases.DeliveryDrivers.CreateDeliveryDriverUseCases
{
    public class CreateDeliveryDriverUseCase : ICreateDeliveryDriverUseCase
    {
        private readonly IDeliveryDriverWriteOnlyRepository _deliveryDriverWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDeliveryDriverUseCase(IDeliveryDriverWriteOnlyRepository deliveryDriverWriteOnlyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _deliveryDriverWriteOnlyRepository = deliveryDriverWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(RequestCreateDeliveryDriverJson request)
        {
            Validate(request);
            var deliveryDriver = _mapper.Map<DeliveryDriver>(request);
            await _deliveryDriverWriteOnlyRepository.CreateDeliveryDriverAsync(deliveryDriver);
        }

        private async Task Validate(RequestCreateDeliveryDriverJson request)
        {
            //var deliveryDriverWithCnhExists = await _deliveryDriverReadOnlyRepository.DeliveryDriverWithCnhAlreadyExists(request.Cnh);
            //var deliveryDriverWithCnpjExists = await _deliveryDriverReadOnlyRepository.DeliveryDriverWithCnpjAlreadyExists(request.Cnpj);

        }
    }
}
