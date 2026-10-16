namespace Car_Rental_Management_System.Entity;

public class RentalHistory
{
    public int Id { get; set; }
    public int RentalId { get; set; }
    public string OldStatus { get; set; } = null!;
    public string NewStatus { get; set; } = null!;
    public DateTime ChangedAt { get; set; }
    public string? Description { get; set; }

    public Rental Rental { get; set; } = null!;

    public override string ToString()
    {
        return $"Rental: {RentalId} | {OldStatus} -> {NewStatus} | {ChangedAt:g}";
    }
}
