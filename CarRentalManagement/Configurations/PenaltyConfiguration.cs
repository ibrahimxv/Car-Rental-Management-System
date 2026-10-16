namespace Car_Rental_Management_System.Configurations;

using Car_Rental_Management_System.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PenaltyConfiguration : IEntityTypeConfiguration<Penalty>
{
    public void Configure(EntityTypeBuilder<Penalty> builder)
    {
        builder.ToTable("Penalties");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Reason)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(p => p.Amount)
            .HasPrecision(18, 2);
    }
}
