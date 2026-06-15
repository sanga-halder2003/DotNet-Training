using Bank_Loan_Management.DTOs;
using Bank_Loan_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Loan_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customer = await _service.GetAllCustomersAsync();
            return Ok(customer);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }


            return Ok(customer);
        }

        [HttpPost]

        public async Task<IActionResult> AddCustomer(CustomerCreateDto dto)
        {
            await _service.AddCustomerAsync(dto);

            return Ok("Customer added successfully");
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateCustomer(int id, CustomerCreateDto dto)
        {
            await _service.UpdateCustomerAsync(id,dto);

            return Ok("Customer updated successfully");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _service.DeleteCustomerAsync(id);
            return Ok("Customer deleted successfully");
        }


    }
}
