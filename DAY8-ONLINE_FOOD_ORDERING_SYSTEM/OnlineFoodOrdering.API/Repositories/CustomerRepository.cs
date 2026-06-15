using Microsoft.EntityFrameworkCore;
using OnlineFoodOrdering.API.Data;
using OnlineFoodOrdering.API.Models;

namespace OnlineFoodOrdering.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FoodOrderingDbContext _context;

        public CustomerRepository(FoodOrderingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}