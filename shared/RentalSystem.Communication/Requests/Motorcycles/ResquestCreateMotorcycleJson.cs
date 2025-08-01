using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Communication.Requests.Motorcycles
{
    public class RequestCreateMotorcycleJson
    {
        public int Ano { get; set; }
        public string Modelo { get; set; }

        [StringLength(7, ErrorMessage = "A placa não pode ter mais de 7 caracteres.")]
        public string Placa { get; set; }
    }
}
