using Bank_Loan_Management.DTOs;
using Bank_Loan_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Loan_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypesController : ControllerBase
    {
        private readonly ILoanTypeService _service;

        public LoanTypesController(ILoanTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoanTypes()
        {
            var loanTypes = await _service.GetAllAsync();
            return Ok(loanTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanTypeById(int id)
        {
            var loanType = await _service.GetByIdAsync(id);

            if (loanType == null)
                return NotFound("Loan Type not found");

            return Ok(loanType);
        }

        [HttpPost]
        public async Task<IActionResult> AddLoanType(LoanTypeCreateDto dto)
        {
            await _service.AddAsync(dto);
            return Ok("Loan Type added successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoanType(int id, LoanTypeCreateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok("Loan Type updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanType(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Loan Type deleted successfully");
        }
    }
}
