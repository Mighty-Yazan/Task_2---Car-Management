using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Task2.Data;

namespace Task2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // #1️ Total cars
            var totalCars = _context.Cars.Count();

            // #2 Average price
            var avgPrice = _context.Cars.Any() ? _context.Cars.Average(c => c.Price) : 0;

            // #3 Most expensive car
            var mostExpensiveCar = _context.Cars
                .OrderByDescending(c => c.Price)
                .FirstOrDefault();

            // #4 Cheapest car
            var cheapestCar = _context.Cars
                .OrderBy(c => c.Price)
                .FirstOrDefault();

            // #5 Price range
            var minPrice = _context.Cars.Any() ? _context.Cars.Min(c => c.Price) : 0;
            var maxPrice = _context.Cars.Any() ? _context.Cars.Max(c => c.Price) : 0;

            // #6 Cars added this month
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var carsAddedThisMonth = _context.Cars
                .Where(c => c.DateAdded >= firstDayOfMonth)
                .Count();

            
            ViewBag.TotalCars = totalCars;
            ViewBag.AvgPrice = avgPrice;
            ViewBag.MostExpensiveCar = mostExpensiveCar;
            ViewBag.CheapestCar = cheapestCar;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.CarsAddedThisMonth = carsAddedThisMonth;

            return View();
        }
    }
}
