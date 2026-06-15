using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrdering.API.Services;

namespace OnlineFoodOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("topselling")]
        public async Task<IActionResult> GetTopSellingFoods()
        {
            var result = await _reportService.GetTopSellingFoods();
            return Ok(result);
        }

        [HttpGet("monthlyrevenue")]
        public async Task<IActionResult> GetMonthlyRevenue()
        {
            var result = await _reportService.GetMonthlyRevenue();
            return Ok(result);
        }
    }
}