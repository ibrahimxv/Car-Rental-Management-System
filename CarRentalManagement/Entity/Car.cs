namespace Car_Rental_Management_System.Entity;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string PlateNumber { get; set; } = null!;
    public decimal DailyPrice { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }
    public bool IsAvailable { get; set; } = true;
    public bool IsDeleted { get; set; }

    public ICollection<Rental> Rental { get; set; } = new List<Rental>();
    public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();

    public override string ToString()
    {
        return $"{Id} | {Brand} {Model} | {PlateNumber} | {DailyPrice:C}";
    }
}
