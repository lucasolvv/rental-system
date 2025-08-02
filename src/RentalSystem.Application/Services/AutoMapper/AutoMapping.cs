using AutoMapper;
using RentalSystem.Communication.Requests.DeliveryDriver;
using RentalSystem.Communication.Requests.Motorcycles;
using RentalSystem.Communication.Responses;
using RentalSystem.Domain.Entities;
using System.Net.NetworkInformation;

namespace RentalSystem.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
            DomainToResponse();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestCreateMotorcycleJson, Motorcycle>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Ano))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Modelo))
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.Placa));

            CreateMap<RequestCreateDeliveryDriverJson, DeliveryDriver>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Cnh, opt => opt.MapFrom(src => src.NumeroCnh))
                .ForMember(dest => dest.LicenseType, opt => opt.MapFrom(src => src.TipoCnh));
        }

        private void DomainToResponse()
        {
            CreateMap<Motorcycle, ResponseGetMotorcycleJson>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.LicensePlate));
        }
    }
}
