using LeaveManagementAPI.Models;
using LeaveManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly ILeaveRequestService _service;

        public LeaveRequestsController(ILeaveRequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaves()
        {
            var leaves = await _service.GetAllLeaves();

            return Ok(leaves);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeave(int id)
        {
            var leave = await _service.GetLeaveById(id);

            if (leave == null)
                return NotFound();

            return Ok(leave);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyLeave(
            LeaveRequest leave)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddLeave(leave);

            return Ok(leave);
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            await _service.ApproveLeave(id);

            return Ok($"Leave Request {id} Approved");
        }

        [HttpPut("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            await _service.RejectLeave(id);

            return Ok($"Leave Request {id} Rejected");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteLeave(id);

            return Ok($"Leave Request {id} Deleted");
        }
    }
}