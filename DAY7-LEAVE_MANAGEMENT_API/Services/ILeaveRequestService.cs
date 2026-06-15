using LeaveManagementAPI.Models;

namespace LeaveManagementAPI.Services
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequest>> GetAllLeaves();

        Task<LeaveRequest> GetLeaveById(int id);

        Task AddLeave(LeaveRequest leaveRequest);

        Task ApproveLeave(int id);

        Task RejectLeave(int id);

        Task DeleteLeave(int id);
    }
}