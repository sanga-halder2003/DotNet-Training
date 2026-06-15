using Bank_Loan_Management.DTOs;
using Bank_Loan_Management.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Loan_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationsController : ControllerBase
    {
        private readonly ILoanApplicationService _service;

        public LoanApplicationsController(ILoanApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var application = await _service.GetByIdAsync(id);

            if (application == null)
                return NotFound("Loan application not found");

            return Ok(application);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyLoan(LoanApplicationCreateDto dto)
        {
            await _service.ApplyLoanAsync(dto);
            return Ok("Loan Application Submitted Successfully");
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveLoan(int id)
        {
            await _service.ApproveLoanAsync(id);
            return Ok("Loan Approved Successfully. EMI schedule generated.");
        }

        [HttpPut("reject/{id}")]
        public async Task<IActionResult> RejectLoan(int id)
        {
            await _service.RejectLoanAsync(id);
            return Ok("Loan Rejected Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Loan Application Deleted");
        }
    }
}