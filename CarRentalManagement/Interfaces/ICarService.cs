using Car_Rental_Management_System.Entity;

namespace Car_Rental_Management_System.Interfaces;

public interface ICarService
{
    Task<Car> AddAsync(Car car);
    Task<List<Car>> GetAllAsync();
    Task<Car> GetByIdAsync(int id);
    Task UpdateAsync (Car car);
    Task DeactivateAsync (int id);

    Task<List<Car>> SearchAsync(string? brand, string? model);
    Task<List<Car>> FilterByPriceAsync(decimal minPrice, decimal maxPrice);
    Task<List<Car>> GetAvailableAsync(DateTime startDate, DateTime endDate);
    Task<List<Car>> GetMaintenanceDueAsync();
    Task<List<Car>> GetMostRentedAsync();
}
