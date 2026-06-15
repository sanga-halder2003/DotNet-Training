using Microsoft.EntityFrameworkCore;
using OnlineFoodOrdering.API.Data;
using OnlineFoodOrdering.API.DTOs;

namespace OnlineFoodOrdering.API.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly FoodOrderingDbContext _context;

        public ReportRepository(FoodOrderingDbContext context)
        {
            _context = context;
        }

        public async Task<List<TopSellingFoodDto>> GetTopSellingFoods()
        {
            return await _context.OrderDetails
                .Include(od => od.FoodItem)
                .GroupBy(od => new
                {
                    od.FoodId,
                    od.FoodItem.FoodName
                })
                .Select(g => new TopSellingFoodDto
                {
                    FoodId = g.Key.FoodId,
                    FoodName = g.Key.FoodName,
                    TotalQuantitySold = g.Sum(x => x.Quantity),
                    TotalSalesAmount = g.Sum(x => x.Quantity * x.UnitPrice)
                })
                .OrderByDescending(x => x.TotalQuantitySold)
                .ToListAsync();
        }

        public async Task<List<MonthlyRevenueDto>> GetMonthlyRevenue()
        {
            return await _context.Orders
                .Where(o => o.Status != "Cancelled")
                .GroupBy(o => new
                {
                    o.OrderDate.Year,
                    o.OrderDate.Month
                })
                .Select(g => new MonthlyRevenueDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = g.Sum(x => x.TotalAmount)
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();
        }
    }
}