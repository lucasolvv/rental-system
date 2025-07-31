using AutoMapper;
using RentalSystem.Communication.Requests.Motos;
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
            CreateMap<RequestCreateMotoJson, Moto>();
        }
    }
}
