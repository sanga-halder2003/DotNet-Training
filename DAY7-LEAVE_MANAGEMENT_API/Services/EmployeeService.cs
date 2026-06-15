using LeaveManagementAPI.Models;
using LeaveManagementAPI.Repositories;

namespace LeaveManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddEmployee(EmployeeModel employee)
        {
            await _repository.AddAsync(employee);
        }
        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task UpdateEmployee(EmployeeModel employee)
        {
            await _repository.UpdateAsync(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}