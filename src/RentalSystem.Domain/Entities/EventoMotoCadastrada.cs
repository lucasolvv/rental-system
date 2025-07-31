using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Domain.Entities
{
    public class EventoMotoCadastrada
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid MotoId { get; set; }

        [Required]
        public DateTime DataEvento { get; set; }

        public string? ConteudoMensagem { get; set; } // JSON, texto ou log simples
    }
}
