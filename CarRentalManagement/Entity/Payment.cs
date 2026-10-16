using Car_Rental_Management_System.Enums;

namespace Car_Rental_Management_System.Entity;

public class Payment
{
    public int Id { get; set; }
    public int RentalId { get ; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentType PaymentType { get; set; }
    public Rental Rental { get; set; } = null!;

    public override string ToString()
    {
        return $"Payment #{Id} | Rental: {RentalId} | " +
               $"{Amount:C} | {PaymentType} | {PaymentDate:g}";
    }
}
