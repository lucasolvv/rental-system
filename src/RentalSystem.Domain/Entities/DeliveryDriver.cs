using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Domain.Entities
{
    public class DeliveryDriver
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(14)]
        public string Cnpj { get; set; } // Must be unique

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Cnh { get; set; } // Must be unique

        [Required]
        [MaxLength(3)]
        public string LicenseType { get; set; } // A, B or A+B

        [MaxLength(255)]
        public string? LicenseImagePath { get; set; }
    }

}
