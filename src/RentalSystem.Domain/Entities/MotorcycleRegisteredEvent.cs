using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Domain.Entities
{
    public class MotorcycleRegisteredEvent
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string MotorcycleId { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string? MessageContent { get; set; } // JSON, plain text or log
    }

}
