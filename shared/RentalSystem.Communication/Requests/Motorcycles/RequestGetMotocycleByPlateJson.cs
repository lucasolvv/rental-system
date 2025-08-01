using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Communication.Requests.Motorcycles
{
    public class RequestGetMotorcycleByPlateJson
    {
        [StringLength(8, ErrorMessage = "A placa não pode ter mais de 8 caracteres.")]
        public string? Placa { get; set; } = string.Empty;
    }
}
