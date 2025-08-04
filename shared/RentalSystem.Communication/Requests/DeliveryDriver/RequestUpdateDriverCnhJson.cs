using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Communication.Requests.DeliveryDriver
{
    public class RequestUpdateDriverCnhJson
    {
        [Required]
        public string Imagem_cnh { get; set; }
    }
}
