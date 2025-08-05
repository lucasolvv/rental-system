using AutoMapper;
using RentalSystem.Communication.Responses;
using RentalSystem.Domain.Repositories.Motorcycle;
using RentalSystem.Domain.Repositories.Rental;
using RentalSystem.Exceptions.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Application.UseCases.Rentals.GetRentalUseCases
{
    public class GetRentalUseCase : IGetRentalUseCase
    {
        private readonly IRentalReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        public GetRentalUseCase(IRentalReadOnlyRepository rentalReadOnlyRepository, IMapper mapper)
        {
            _repository = rentalReadOnlyRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ResponseGetRentalJson>> GetAllRentalsAsync()
        {
            var allRentals = await _repository.GetAllRentalsAsync();
            return _mapper.Map<IEnumerable<ResponseGetRentalJson>>(allRentals);
        }

        public async Task<ResponseGetRentalJson> GetRentalByIdAsync(string id)
        {
            var rental = await _repository.GetRentalByIdAsync(id);
            if (rental == null) throw new ErrorOnValidationException($"Não há nenhuma locação registrada com o {id}.");
            return _mapper.Map<ResponseGetRentalJson>(rental);
        }
    }
}
