using Bank_Loan_Management.DTOs;

namespace Bank_Loan_Management.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerResponseDto>> GetAllCustomersAsync();

        Task<CustomerResponseDto?> GetCustomerByIdAsync(int id);

        Task AddCustomerAsync(CustomerCreateDto dto);

        Task UpdateCustomerAsync(int id, CustomerCreateDto dto);

        Task DeleteCustomerAsync(int id);
    }
}