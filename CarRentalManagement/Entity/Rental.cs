using Car_Rental_Management_System.Enums;

namespace Car_Rental_Management_System.Entity;

public class Rental
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime ActualReturnDate {  get; set; }
    public decimal DailyPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public RentalStatus Status { get; set; }
    public Car Car { get; set; } = null!;
    public Customer Customer { get; set; } = null!;

    public ICollection<Payment> Payment { get; set; } = new List<Payment>();
    public ICollection<Penalty> Penalty { get; set; } = new List<Penalty>();
    public ICollection<RentalHistory> RentalHistory { get; set; } = new List<RentalHistory>();

    public override string ToString()
    {
        return $"Rental #{Id} | Car: {CarId} | Customer: {CustomerId} | " +
               $"{StartDate:d} - {ExpectedReturnDate:d} | Status: {Status}";
    }
}
