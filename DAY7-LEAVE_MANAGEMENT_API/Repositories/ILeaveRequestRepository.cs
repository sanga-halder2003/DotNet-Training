using LeaveManagementAPI.Models;

namespace LeaveManagementAPI.Repositories
{
    public interface ILeaveRequestRepository
    {
        Task<List<LeaveRequest>> GetAllAsync();

        Task<LeaveRequest> GetByIdAsync(int id);

        Task AddAsync(LeaveRequest leaveRequest);

        Task UpdateAsync(LeaveRequest leaveRequest);

        Task DeleteAsync(int id);
    }
}