using OnlineFoodOrdering.API.Models;
using OnlineFoodOrdering.API.Repositories;

namespace OnlineFoodOrdering.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _customerRepository.GetCustomerById(id);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FullName))
                throw new Exception("Full name is required");

            if (string.IsNullOrWhiteSpace(customer.Email))
                throw new Exception("Email is required");

            if (string.IsNullOrWhiteSpace(customer.Phone) || customer.Phone.Length != 10)
                throw new Exception("Phone number must be 10 digits");

            await _customerRepository.AddCustomer(customer);
            return customer;
        }

        public async Task<bool> UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = await _customerRepository.GetCustomerById(id);

            if (existingCustomer == null)
                return false;

            existingCustomer.FullName = customer.FullName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;

            await _customerRepository.UpdateCustomer(existingCustomer);

            return true;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var existingCustomer = await _customerRepository.GetCustomerById(id);

            if (existingCustomer == null)
                return false;

            await _customerRepository.DeleteCustomer(existingCustomer);

            return true;
        }
    }
}