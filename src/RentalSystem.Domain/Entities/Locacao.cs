using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Domain.Entities
{
    public class Locacao
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid EntregadorId { get; set; }

        [Required]
        public Guid MotoId { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataTermino { get; set; }

        [Required]
        public DateTime DataPrevisaoTermino { get; set; }

        [Required]
        public int DiasPlano { get; set; } // Ex: 7, 15, 30, etc.

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorDiaria { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ValorTotal { get; set; }

        // Navegação (opcional, se estiver usando EF Core)
        public Moto Moto { get; set; }
        public Entregador Entregador { get; set; }
    }
}
