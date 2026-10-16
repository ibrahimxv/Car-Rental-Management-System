namespace Car_Rental_Management_System.Configurations;

using Car_Rental_Management_System.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class RentalHistoryConfiguration : IEntityTypeConfiguration<RentalHistory>
{
    public void Configure(EntityTypeBuilder<RentalHistory> builder)
    {
        builder.ToTable("RentalHistories");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.OldStatus).HasMaxLength(20);
        builder.Property(h => h.NewStatus).HasMaxLength(20);
        builder.Property(h => h.Description).HasMaxLength(500);
    }
}
