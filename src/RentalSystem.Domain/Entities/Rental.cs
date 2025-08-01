using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Domain.Entities
{
    public class Rental
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DeliveryDriverId { get; set; }

        [Required]
        public Guid MotorcycleId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime ExpectedEndDate { get; set; }

        [Required]
        public int PlanDays { get; set; } // Ex: 7, 15, 30, etc.

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DailyRate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? TotalValue { get; set; }

        // Navigation properties
        public Motorcycle Motorcycle { get; set; }
        public DeliveryDriver DeliveryDriver { get; set; }
    }

}
