using AutoMapper;
using RentalSystem.Communication.Requests.DeliveryDriver;
using RentalSystem.Domain.Repositories;
using RentalSystem.Domain.Repositories.DeliveryDriver;
using RentalSystem.Domain.Entities;
using RentalSystem.Application.Services.FileStorage;
using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.UseCases.DeliveryDrivers.CreateDeliveryDriverUseCases
{
    public class CreateDeliveryDriverUseCase : ICreateDeliveryDriverUseCase
    {
        private readonly IDeliveryDriverWriteOnlyRepository _deliveryDriverWriteOnlyRepository;
        private readonly IDeliveryDriverReadOnlyRepository _deliveryDriverReadOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorage;

        public CreateDeliveryDriverUseCase(
            IDeliveryDriverWriteOnlyRepository deliveryDriverWriteOnlyRepository, 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IFileStorageService fileStorage,
            IDeliveryDriverReadOnlyRepository deliveryDriverReadOnlyRepository
            )
        {
            _deliveryDriverWriteOnlyRepository = deliveryDriverWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileStorage = fileStorage;
            _deliveryDriverReadOnlyRepository = deliveryDriverReadOnlyRepository;
        }

        public async Task ExecuteAsync(RequestCreateDeliveryDriverJson request)
        {
            await Validate(request);
            
            var deliveryDriver = _mapper.Map<DeliveryDriver>(request);

            if(!string.IsNullOrWhiteSpace(request.Imagem_cnh))
            {
                var imageFileName = request.Nome + "_CNH_" + Guid.NewGuid().ToString() + ".jpg";
                var imagePath = await _fileStorage.SaveImageAsync(request.Imagem_cnh, imageFileName);
                deliveryDriver.LicenseImagePath = imagePath;
            }

            await _deliveryDriverWriteOnlyRepository.CreateDeliveryDriverAsync(deliveryDriver);
            await _unitOfWork.Commit();
        }

        private async Task Validate(RequestCreateDeliveryDriverJson request)
        {
            var deliveryDriverWithCnhExists = await _deliveryDriverReadOnlyRepository.DeliveryDriverWithCnhAlreadyExists(request.Numero_cnh);
            var deliveryDriverWithCnpjExists = await _deliveryDriverReadOnlyRepository.DeliveryDriverWithCnpjAlreadyExists(request.Cnpj);

            if (deliveryDriverWithCnhExists)
                throw new ErrorOnValidationException($"Já existe um entregador com a CNH {request.Numero_cnh}.");
            

            if (deliveryDriverWithCnpjExists)
                throw new ErrorOnValidationException($"Já existe um entregador com o CNPJ {request.Cnpj}.");
            

        }
    }
}
