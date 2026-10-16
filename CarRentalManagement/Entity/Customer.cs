namespace Car_Rental_Management_System.Entity;

public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string DrivingLicenseNumber { get; set; } = null!;
    public DateTime LicenseExpiryDate { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public override string ToString()
    {
        return $"{Id} | {FullName} | {Email} | License expires: {LicenseExpiryDate:d}";
    }
}
