
using Bank_Loan_Management.Models;
using BankLoanManagement.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Bank_Loan_Management.Repositories
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        private readonly AppDbContext _context;

        public LoanApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoanApplication>> GetAllAsync()
        {
            return await _context.LoanApplications
                .Include(x => x.Customer)
                .Include(x => x.LoanType)
                .ToListAsync();
        }

        public async Task<LoanApplication?> GetByIdAsync(int id)
        {
            return await _context.LoanApplications
                .Include(x => x.Customer)
                .Include(x => x.LoanType)
                .FirstOrDefaultAsync(x => x.ApplicationId == id);
        }

        public async Task AddAsync(LoanApplication application)
        {
            await _context.LoanApplications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoanApplication application)
        {
            _context.LoanApplications.Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var application = await _context.LoanApplications.FindAsync(id);

            if (application != null)
            {
                _context.LoanApplications.Remove(application);
                await _context.SaveChangesAsync();
            }
        }
    }
}