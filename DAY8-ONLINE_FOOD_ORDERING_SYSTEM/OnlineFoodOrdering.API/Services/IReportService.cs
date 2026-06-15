using OnlineFoodOrdering.API.DTOs;

namespace OnlineFoodOrdering.API.Services
{
    public interface IReportService
    {
        Task<List<TopSellingFoodDto>> GetTopSellingFoods();
        Task<List<MonthlyRevenueDto>> GetMonthlyRevenue();
    }
}