using Microsoft.EntityFrameworkCore;
using RentalSystem.Domain.Entities;

namespace RentalSystem.Infra.DataAccess
{
    public class RentalSystemDbContext : DbContext
    {
        public RentalSystemDbContext(DbContextOptions<RentalSystemDbContext> options) : base(options) { }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<MotorcycleRegisteredEvent> MotorcycleRegisteredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorcycle>(entity =>
            {
                entity.ToTable("motorcycles");

                entity.HasIndex(m => m.LicensePlate).IsUnique();
                entity.Property(m => m.LicensePlate).HasColumnName("license_plate");
                entity.Property(m => m.Model).HasColumnName("model");
                entity.Property(m => m.Year).HasColumnName("year");
            });

            modelBuilder.Entity<DeliveryDriver>(entity =>
            {
                entity.ToTable("delivery_drivers");

                entity.HasIndex(e => e.Cnpj).IsUnique();
                entity.HasIndex(e => e.Cnh).IsUnique();
                entity.Property(e => e.Cnpj).HasColumnName("cnpj");
                entity.Property(e => e.Cnh).HasColumnName("cnh");
                entity.Property(e => e.LicenseType).HasColumnName("license_type");
                entity.Property(e => e.LicenseImagePath).HasColumnName("license_img_path");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.ToTable("rentals");
                entity.Property(l => l.DailyRate)
                      .HasColumnType("numeric(10,2)");
                entity.Property(l => l.TotalValue)
                      .HasColumnType("numeric(10,2)");
                entity.HasOne(l => l.DeliveryDriver)
                      .WithMany()
                      .HasForeignKey(l => l.DeliveryDriverId);
                entity.HasOne(l => l.Motorcycle)
                      .WithMany()
                      .HasForeignKey(l => l.MotorcycleId);
            });
            modelBuilder.Entity<MotorcycleRegisteredEvent>(entity =>
            {
                entity.ToTable("motorcycle_registered_events");
                entity.Property(e => e.MessageContent).HasColumnType("text");
            });
        }
    }
}
