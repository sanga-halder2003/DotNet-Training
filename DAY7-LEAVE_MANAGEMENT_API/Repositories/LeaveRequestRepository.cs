using LeaveManagementAPI.Data;
using LeaveManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementAPI.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly AppDbContext _context;

        public LeaveRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeaveRequest>> GetAllAsync()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        public async Task<LeaveRequest> GetByIdAsync(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task AddAsync(LeaveRequest leaveRequest)
        {
            await _context.LeaveRequests.AddAsync(leaveRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);

            if (leave != null)
            {
                _context.LeaveRequests.Remove(leave);
                await _context.SaveChangesAsync();
            }
        }
    }
}