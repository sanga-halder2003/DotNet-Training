using LeaveManagementAPI.Models;

namespace LeaveManagementAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllAsync();
        Task<EmployeeModel> GetByIdAsync(int id);

        Task AddAsync(EmployeeModel employee);

        Task UpdateAsync(EmployeeModel employee);

        Task DeleteAsync(int id);
    }
}
