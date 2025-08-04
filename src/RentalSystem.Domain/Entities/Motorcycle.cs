using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Domain.Entities
{
    public class Motorcycle
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        [MaxLength(10)]
        public string LicensePlate { get; set; }
    }

}
