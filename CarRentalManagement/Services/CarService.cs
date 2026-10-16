using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Entity;
using Car_Rental_Management_System.Enums;
using Car_Rental_Management_System.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Services;

public class CarService : ICarService
{
    private readonly AppDbContext _context;
    public CarService(AppDbContext context)
    {
        context = _context;
    }

    public async Task<Car> AddAsync(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        return car;
    }

    public async Task DeactivateAsync(int id)
    {
        var car = await GetByIdAsync(id);

        if (car is null)
        {
            throw new Exception("Car not found");
        }
        car.IsAvailable = false;
        car.IsDeleted = true;

        await _context.SaveChangesAsync();
    }

    public async Task<List<Car>> FilterByPriceAsync(decimal minPrice, decimal maxPrice)
    {
        if (minPrice < 0 || maxPrice < minPrice)
            throw new ArgumentException("Price range is incorrect.");

        return await _context.Cars
            .Where(c => c.IsAvailable && c.DailyPrice >= minPrice && c.DailyPrice <= maxPrice)
            .OrderBy(c => c.DailyPrice)
            .ToListAsync();
    }

    public async Task<List<Car>> GetAllAsync()
    {
        return await _context.Cars
            .Where(c => c.IsAvailable)
            .ToListAsync();
    }

    public async Task<List<Car>> GetAvailableAsync(DateTime startDate, DateTime endDate)
    {
        if (startDate.Date < DateTime.Today || endDate.Date <= startDate.Date)
        {
            throw new ArgumentException("Date range is incorrect.");
        }
        return await _context.Cars
            .Where(c => c.IsAvailable)
            .Where(c => !_context.Rental.Any(r =>
                r.CarId == c.Id &&
                (r.Status == RentalStatus.Reserved ||
                 r.Status == RentalStatus.Active) &&
                r.StartDate < endDate &&
                r.ExpectedReturnDate > startDate))
            .OrderBy(c => c.DailyPrice)
            .ToListAsync();
    }

    public async Task<Car> GetByIdAsync(int id)
    {
        return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id && c.IsAvailable);
    }

    public async Task<List<Car>> GetMaintenanceDueAsync()
    {
        var today = DateTime.Today;

        return await _context.Cars.Where(c => c.IsAvailable).ToListAsync();
                    
    }

    public async Task<List<Car>> GetMostRentedAsync()
    {
        return await _context.Cars
            .Where(c => c.IsAvailable)
            .OrderByDescending(c =>
                c.Rental.Count(r =>
                    r.Status != RentalStatus.Cancelled))
            .ToListAsync();
    }

    public async Task<List<Car>> SearchAsync(string? brand, string? model)
    {
        var query = _context.Cars.Where(c => c.IsAvailable).AsQueryable();

        if (!string.IsNullOrWhiteSpace(brand))
            query = query.Where(c => c.Brand.Contains(brand));

        if (!string.IsNullOrWhiteSpace(model))
            query = query.Where(c => c.Model.Contains(model));

        return await query.ToListAsync();
    }

    public async Task UpdateAsync(Car car)
    {
        var existingCar = await _context.Cars
            .FirstOrDefaultAsync(c => c.Id == car.Id && c.IsAvailable);

        if (existingCar == null)
            throw new Exception("Avtomobil tapılmadı.");

        existingCar.Brand = car.Brand;
        existingCar.Model = car.Model;
        existingCar.PlateNumber = car.PlateNumber;
        existingCar.DailyPrice = car.DailyPrice;
        existingCar.Year = car.Year;
        existingCar.Mileage = car.Mileage;

        await _context.SaveChangesAsync();
    }
}
