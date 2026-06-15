using LeaveManagementAPI.Models;

namespace LeaveManagementAPI.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetAllEmployees();

        Task AddEmployee(EmployeeModel employee);

        Task<EmployeeModel> GetEmployeeById(int id);

        Task UpdateEmployee(EmployeeModel employee);

        Task DeleteEmployee(int id);
    }
}