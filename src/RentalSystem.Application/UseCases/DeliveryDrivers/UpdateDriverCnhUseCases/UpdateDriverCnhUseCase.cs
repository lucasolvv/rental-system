using RentalSystem.Application.Services.FileStorage;
using RentalSystem.Communication.Requests.DeliveryDriver;
using RentalSystem.Domain.Repositories;
using RentalSystem.Domain.Repositories.DeliveryDriver;
using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Application.UseCases.DeliveryDrivers.UpdateDriverCnhUseCases
{
    public class UpdateDriverCnhUseCase : IUpdateDriverCnhUseCase
    {
        private readonly IDeliveryDriverReadOnlyRepository _deliveryDriverReadOnlyRepository;
        private readonly IDeliveryDriverUpdateOnlyRepository _deliveryDriverUpdateOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorage;

        public UpdateDriverCnhUseCase(
            IDeliveryDriverReadOnlyRepository deliveryDriverReadOnlyRepository,
            IDeliveryDriverUpdateOnlyRepository deliveryDriverUpdateOnlyRepository,
            IUnitOfWork unitOfWork,
            IFileStorageService fileStorage)
        {
            _deliveryDriverReadOnlyRepository = deliveryDriverReadOnlyRepository;
            _deliveryDriverUpdateOnlyRepository = deliveryDriverUpdateOnlyRepository;
            _unitOfWork = unitOfWork;
            _fileStorage = fileStorage;
        }
        public async Task ExecuteAsync(string id, RequestUpdateDriverCnhJson request)
        {
            await Validate(id);
            var driver =  await _deliveryDriverReadOnlyRepository.GetDeliveryDriverById(id);

            var newImageFileName = driver.Name.Split(" ")[0] + "_CNH_" + $"updated_{DateTime.Now.Ticks}";
            var newCnhFilePath = await _fileStorage.SaveImageAsync(request.Imagem_cnh, newImageFileName);

            driver.LicenseImagePath = newCnhFilePath;
            _deliveryDriverUpdateOnlyRepository.UpdateDeliveryDriverAsync(driver);
            await _unitOfWork.Commit();
        }

        private async Task Validate(string id)
        {
            var driverExists = await _deliveryDriverReadOnlyRepository.DeliveryDriverExistsById(id);
            if (!driverExists)
            {
                throw new ErrorOnValidationException($"Motorista com ID {id} não encontrado.");
            }
        }
    }
}
