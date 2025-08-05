using AutoMapper;
using RentalSystem.Communication.Requests.DeliveryDriver;
using RentalSystem.Communication.Requests.Motorcycles;
using RentalSystem.Communication.Requests.Rental;
using RentalSystem.Communication.Responses;
using RentalSystem.Domain.Entities;

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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Identificador))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Ano))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Modelo))
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.Placa));

            CreateMap<RequestCreateDeliveryDriverJson, DeliveryDriver>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Identificador))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Data_nascimento))
                .ForMember(dest => dest.Cnh, opt => opt.MapFrom(src => src.Numero_cnh))
                .ForMember(dest => dest.LicenseType, opt => opt.MapFrom(src => src.Tipo_cnh));

            CreateMap<RequestCreateMotorcycleRentalJson, Domain.Entities.Rental>()
                .ForMember(dest => dest.DeliveryDriverId, opt => opt.MapFrom(src => src.Entregador_id))
                .ForMember(dest => dest.MotorcycleId, opt => opt.MapFrom(src => src.Moto_id))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Data_inicio))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Data_termino))
                .ForMember(dest => dest.ExpectedEndDate, opt => opt.MapFrom(src => src.Data_previsao_termino))
                .ForMember(dest => dest.PlanDays, opt => opt.MapFrom(src => (int)src.Plano))
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // será gerado no UseCase
                .ForMember(dest => dest.DailyRate, opt => opt.Ignore()) // será calculado
                .ForMember(dest => dest.TotalValue, opt => opt.Ignore()) // será calculado
                .ForMember(dest => dest.Motorcycle, opt => opt.Ignore()) // navigation
                .ForMember(dest => dest.DeliveryDriver, opt => opt.Ignore()); // navigation
        }

        private void DomainToResponse()
        {
            CreateMap<Motorcycle, ResponseGetMotorcycleJson>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.LicensePlate));

            CreateMap<Domain.Entities.Rental, ResponseGetRentalJson>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Entregador_id, opt => opt.MapFrom(src => src.DeliveryDriverId))
                .ForMember(dest => dest.Moto_id, opt => opt.MapFrom(src => src.MotorcycleId))
                .ForMember(dest => dest.Data_inicio, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.Data_termino, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Data_previsao_permino, opt => opt.MapFrom(src => src.ExpectedEndDate))
                .ForMember(dest => dest.Plano, opt => opt.MapFrom(src => src.PlanDays))
                .ForMember(dest => dest.Valor_diaria, opt => opt.MapFrom(src => src.DailyRate))
                .ForMember(dest => dest.Valor_total, opt => opt.MapFrom(src => src.TotalValue));

        }
    }
}
