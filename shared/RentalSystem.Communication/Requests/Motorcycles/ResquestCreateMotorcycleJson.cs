using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Communication.Requests.Motorcycles
{
    public class RequestCreateMotorcycleJson
    {
        public string Identificador { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }

        [StringLength(8, ErrorMessage = "A placa não pode ter mais de 8 caracteres.")]
        public string Placa { get; set; }
    }
}
