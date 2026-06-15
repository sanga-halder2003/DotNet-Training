using LeaveManagementAPI.Models;
using LeaveManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _service.GetAllEmployees();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(
     EmployeeModel employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddEmployee(employee);

            return Ok(employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _service.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id,EmployeeModel employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest();

            await _service.UpdateEmployee(employee);

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _service.DeleteEmployee(id);

            return Ok($"Employee {id} deleted successfully");
        }
    }
}