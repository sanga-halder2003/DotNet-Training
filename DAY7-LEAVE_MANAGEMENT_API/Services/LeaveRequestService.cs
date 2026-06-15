using LeaveManagementAPI.Models;
using LeaveManagementAPI.Repositories;

namespace LeaveManagementAPI.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _repository;

        public LeaveRequestService(ILeaveRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LeaveRequest>> GetAllLeaves()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<LeaveRequest> GetLeaveById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddLeave(LeaveRequest leaveRequest)
        {
            leaveRequest.Status = "Pending";

            await _repository.AddAsync(leaveRequest);
        }

        public async Task ApproveLeave(int id)
        {
            var leave = await _repository.GetByIdAsync(id);

            if (leave != null)
            {
                leave.Status = "Approved";
                await _repository.UpdateAsync(leave);
            }
        }

        public async Task RejectLeave(int id)
        {
            var leave = await _repository.GetByIdAsync(id);

            if (leave != null)
            {
                leave.Status = "Rejected";
                await _repository.UpdateAsync(leave);
            }
        }

        public async Task DeleteLeave(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}