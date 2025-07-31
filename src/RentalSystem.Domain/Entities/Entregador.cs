using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.Domain.Entities
{
    public class Entregador
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(14)]
        public string Cnpj { get; set; } // Deve ser único

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(20)]
        public string NumeroCnh { get; set; } // Deve ser único

        [Required]
        [MaxLength(3)]
        public string TipoCnh { get; set; } // A, B ou A+B

        
        [MaxLength(255)]
        public string? ImagemCnhPath { get; set; }
    }
}
