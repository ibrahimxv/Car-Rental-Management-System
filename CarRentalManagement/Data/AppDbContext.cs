using Microsoft.EntityFrameworkCore;
using Car_Rental_Management_System.Entity;

namespace Car_Rental_Management_System.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("server=IBO\\SQLEXPRESS;database=RentalDB;trusted_connection=true;integrated security=true;TrustServerCertificate=true;");
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Penalty> Penalty { get; set; }
    public DbSet<Rental> Rental { get; set; }
    public DbSet<RentalHistory> RentalHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
