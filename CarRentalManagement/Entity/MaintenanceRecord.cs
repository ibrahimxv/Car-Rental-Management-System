namespace Car_Rental_Management_System.Entity;

public class MaintenanceRecord
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Description { get; set; } = null!;
    public DateTime MaintenanceDate { get; set; }
    public decimal Cost { get; set; }
    public DateTime NextMaintenanceDate { get; set; }
    public Car Car { get; set; } = null!;

    public override string ToString()
    {
        return $"Maintenance #{Id} | Car: {CarId} | {Description} | " +
               $"Cost: {Cost:C} | Next: {NextMaintenanceDate:d}";
    }
}
