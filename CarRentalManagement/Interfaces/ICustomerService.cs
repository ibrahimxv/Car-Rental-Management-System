using Car_Rental_Management_System.Entity;

namespace Car_Rental_Management_System;

public interface ICustomerService
{
    Task<Customer> AddAsync(Customer customer);
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task UpdateAsync(Customer customer);
    Task DeactivateAsync(int id);
    Task<List<Rental>> GetRentalHistoryAsync(int customerId);
    Task<List<Customer>> GetCustomersByTotalSpendingAsync();
}
