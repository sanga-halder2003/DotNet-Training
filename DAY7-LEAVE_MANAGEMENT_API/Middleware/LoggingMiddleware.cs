using Microsoft.AspNetCore.Http;

namespace LeaveManagementAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine(
                $"Request Method: {context.Request.Method}");

            Console.WriteLine(
                $"Request Path: {context.Request.Path}");

            await _next(context);

            Console.WriteLine(
                $"Response Status Code: {context.Response.StatusCode}");
        }
    }
}