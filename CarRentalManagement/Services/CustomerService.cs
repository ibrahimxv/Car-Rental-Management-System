using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Entity;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;
    public CustomerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        bool exists = await _context.Customers
            .AnyAsync(c => c.Email  == customer.Email || c.DrivingLicenseNumber == customer.DrivingLicenseNumber);

        if (exists)
            throw new Exception("This email or driver's license number already exists.");

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task DeactivateAsync(int id)
    {
        var customer = await GetByIdAsync(id);

        if (customer is null)
            throw new Exception("Customer not found");

        customer.IsDeleted = true;

        await _context.SaveChangesAsync();
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<List<Customer>> GetCustomersByTotalSpendingAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Rental>> GetRentalHistoryAsync(int customerId)
    {
        var customer = await GetByIdAsync (customerId);

        if (customer is null)
            throw new Exception("Customer not found");

        return await _context.Rental
            .Where(r => r.CustomerId == customerId)
            .Include(r => r.Car)
            .Include(r => r.Payment)
            .ToListAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        var existingCustomer = await GetByIdAsync(customer.Id);

        if (existingCustomer == null)
            throw new Exception("Customer not found.");

        bool duplicate = await _context.Customers.AnyAsync(c =>
            c.Id != customer.Id &&
            (c.Email == customer.Email ||
             c.DrivingLicenseNumber == customer.DrivingLicenseNumber));

        if (duplicate)
            throw new Exception(
                "The email or driver's license number belongs to someone else.");

        existingCustomer.FullName = customer.FullName;
        existingCustomer.Email = customer.Email;
        existingCustomer.DrivingLicenseNumber =
            customer.DrivingLicenseNumber;
        existingCustomer.LicenseExpiryDate = customer.LicenseExpiryDate;

        await _context.SaveChangesAsync();
    }
}
