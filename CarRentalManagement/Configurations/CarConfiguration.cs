using Car_Rental_Management_System.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car_Rental_Management_System.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Brand)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Model)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.PlateNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(c => c.PlateNumber)
            .IsUnique();

        builder.Property(c => c.DailyPrice)
            .HasPrecision(18, 2);

        builder.Property(c => c.IsAvailable)
            .HasDefaultValue(true);

        builder.HasMany(c => c.Rental)
            .WithOne(r => r.Car)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.MaintenanceRecords)
            .WithOne(m => m.Car)
            .HasForeignKey(m => m.CarId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
