using OnlineFoodOrdering.API.Data;
using OnlineFoodOrdering.API.Models;

namespace OnlineFoodOrdering.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, FoodOrderingDbContext dbContext)
        {
            DateTime requestTime = DateTime.Now;

            await _next(context);

            DateTime responseTime = DateTime.Now;

            var log = new AuditLog
            {
                RequestUrl = context.Request.Path,
                HttpMethod = context.Request.Method,
                RequestTime = requestTime,
                ResponseTime = responseTime
            };

            dbContext.AuditLogs.Add(log);
            await dbContext.SaveChangesAsync();
        }
    }
}