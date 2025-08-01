using AutoMapper;
using RentalSystem.Communication.Requests.Motorcycle;
using RentalSystem.Domain.Entities;

namespace RentalSystem.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        { 
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestCreateMotorcycleJson, Motorcycle>();
        }
    }
}
