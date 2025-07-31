using Microsoft.EntityFrameworkCore;
using RentalSystem.Domain.Entities;

namespace RentalSystem.Infra.DataAccess
{
    public class RentalSystemDbContext : DbContext
    {
        public RentalSystemDbContext(DbContextOptions<RentalSystemDbContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<EventoMotoCadastrada> EventosMotoCadastrada { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.ToTable("motos");

                entity.HasIndex(m => m.Placa).IsUnique();
                entity.Property(m => m.Placa).HasColumnName("placa");
                entity.Property(m => m.Modelo).HasColumnName("modelo");
                entity.Property(m => m.Ano).HasColumnName("ano");
            });

            modelBuilder.Entity<Entregador>(entity =>
            {
                entity.ToTable("entregadores");

                entity.HasIndex(e => e.Cnpj).IsUnique();
                entity.HasIndex(e => e.NumeroCnh).IsUnique();
                entity.Property(e => e.Cnpj).HasColumnName("cnpj");
                entity.Property(e => e.NumeroCnh).HasColumnName("numero_cnh");
                entity.Property(e => e.TipoCnh).HasColumnName("tipo_cnh");
                entity.Property(e => e.ImagemCnhPath).HasColumnName("imagem_cnh_path");
            });

            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.ToTable("locacoes");
                entity.Property(l => l.ValorDiaria)
                      .HasColumnType("numeric(10,2)");
                entity.Property(l => l.ValorTotal)
                      .HasColumnType("numeric(10,2)");
                entity.HasOne(l => l.Entregador)
                      .WithMany()
                      .HasForeignKey(l => l.EntregadorId);
                entity.HasOne(l => l.Moto)
                      .WithMany()
                      .HasForeignKey(l => l.MotoId);
            });
            modelBuilder.Entity<EventoMotoCadastrada>(entity =>
            {
                entity.ToTable("eventos_moto_cadastrada");
                entity.Property(e => e.ConteudoMensagem).HasColumnType("text");
            });
        }
    }
}
