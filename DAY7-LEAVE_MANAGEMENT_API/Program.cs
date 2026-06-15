using LeaveManagementAPI.Data;
using LeaveManagementAPI.Middleware;
using LeaveManagementAPI.Repositories;
using LeaveManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository,
    EmployeeRepository>();

builder.Services.AddScoped<IEmployeeService,
    EmployeeService>();


builder.Services.AddScoped<ILeaveRequestRepository,
    LeaveRequestRepository>();

builder.Services.AddScoped<ILeaveRequestService,
    LeaveRequestService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();

app.Run();