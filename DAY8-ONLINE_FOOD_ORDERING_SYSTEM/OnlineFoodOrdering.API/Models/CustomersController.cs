using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrdering.API.Models;
using OnlineFoodOrdering.API.Services;

namespace OnlineFoodOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);

            if (customer == null)
                return NotFound("Customer not found");

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            var createdCustomer = await _customerService.AddCustomer(customer);

            return CreatedAtAction(
                nameof(GetCustomerById),
                new { id = createdCustomer.CustomerId },
                createdCustomer
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            var result = await _customerService.UpdateCustomer(id, customer);

            if (result == false)
                return NotFound("Customer not found");

            return Ok("Customer updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);

            if (result == false)
                return NotFound("Customer not found");

            return Ok("Customer deleted successfully");
        }
    }
}