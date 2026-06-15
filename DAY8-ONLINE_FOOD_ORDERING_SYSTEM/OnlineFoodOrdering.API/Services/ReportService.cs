using OnlineFoodOrdering.API.DTOs;
using OnlineFoodOrdering.API.Repositories;

namespace OnlineFoodOrdering.API.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<List<TopSellingFoodDto>> GetTopSellingFoods()
        {
            return await _reportRepository.GetTopSellingFoods();
        }

        public async Task<List<MonthlyRevenueDto>> GetMonthlyRevenue()
        {
            return await _reportRepository.GetMonthlyRevenue();
        }
    }
}