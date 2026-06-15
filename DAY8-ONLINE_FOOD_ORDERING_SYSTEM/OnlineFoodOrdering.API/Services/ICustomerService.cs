using OnlineFoodOrdering.API.Models;

namespace OnlineFoodOrdering.API.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomerById(int id);
        Task<Customer> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(int id, Customer customer);
        Task<bool> DeleteCustomer(int id);
    }
}