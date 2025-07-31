using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RentalSystem.Domain.Entities
{
    public class Moto
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        [MaxLength(100)]
        public string Modelo { get; set; }

        [Required]
        [MaxLength(10)]
        public string Placa { get; set; }
    }
}
