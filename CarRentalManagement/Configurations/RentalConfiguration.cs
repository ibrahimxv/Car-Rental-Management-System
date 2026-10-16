namespace Car_Rental_Management_System.Configurations;

using Car_Rental_Management_System.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("Rentals");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.DailyPrice)
            .HasPrecision(18, 2);
        builder.Property(r => r.TotalPrice)
            .HasPrecision(18, 2);

        builder.Property(r => r.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasMany(r => r.Payment)
            .WithOne(p => p.Rental)
            .HasForeignKey(p => p.RentalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.Penalty)
            .WithOne (p => p.Rental)
            .HasForeignKey(p => p.RentalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.RentalHistory)
            .WithOne(p => p.Rental)
            .HasForeignKey(p => p.RentalId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
