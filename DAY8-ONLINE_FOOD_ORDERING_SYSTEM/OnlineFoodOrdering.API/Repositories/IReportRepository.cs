using OnlineFoodOrdering.API.DTOs;

namespace OnlineFoodOrdering.API.Repositories
{
    public interface IReportRepository
    {
        Task<List<TopSellingFoodDto>> GetTopSellingFoods();
        Task<List<MonthlyRevenueDto>> GetMonthlyRevenue();
    }
}