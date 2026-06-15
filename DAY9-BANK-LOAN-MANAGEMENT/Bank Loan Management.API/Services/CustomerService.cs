using Bank_Loan_Management.DTOs;
using Bank_Loan_Management.Models;
using Bank_Loan_Management.Repositories;

namespace Bank_Loan_Management.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerResponseDto>> GetAllCustomersAsync()
        {
            var customers = await _repository.GetAllAsync();

            return customers.Select(c => new CustomerResponseDto
            {
                CustomerId = c.CustomerId,
                FullName = c.FullName,
                Email = c.Email,
                AnnualIncome = c.AnnualIncome
            }).ToList();
        }

        public async Task<CustomerResponseDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
                return null;

            return new CustomerResponseDto
            {
                CustomerId = customer.CustomerId,
                FullName = customer.FullName,
                Email = customer.Email,
                AnnualIncome = customer.AnnualIncome
            };
        }

        public async Task AddCustomerAsync(CustomerCreateDto dto)
        {
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                MobileNumber = dto.MobileNumber,
                Address = dto.Address,
                PANNumber = dto.PANNumber,
                AnnualIncome = dto.AnnualIncome,
                CreatedDate = DateTime.Now
            };

            await _repository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, CustomerCreateDto dto)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
                throw new Exception("Customer not found");

            customer.FullName = dto.FullName;
            customer.Email = dto.Email;
            customer.MobileNumber = dto.MobileNumber;
            customer.Address = dto.Address;
            customer.PANNumber = dto.PANNumber;
            customer.AnnualIncome = dto.AnnualIncome;

            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}