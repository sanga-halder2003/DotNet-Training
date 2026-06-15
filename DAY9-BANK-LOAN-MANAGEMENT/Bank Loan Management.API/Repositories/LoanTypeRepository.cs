using Bank_Loan_Management.Models;
using Bank_Loan_Management.Repositories;
using BankLoanManagement.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Bank_Loan_Management.Repositories
{
    public class LoanTypeRepository : ILoanTypeRepository
    {
        private readonly AppDbContext _context;

        public LoanTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoanType>> GetAllAsync()
        {
            return await _context.LoanTypes.ToListAsync();
        }

        public async Task<LoanType?> GetByIdAsync(int id)
        {
            return await _context.LoanTypes.FindAsync(id);
        }

        public async Task AddAsync(LoanType loan)
        {
            await _context.LoanTypes.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LoanType loan)
        {
            _context.LoanTypes.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var loan = await _context.LoanTypes.FindAsync(id);

            if (loan != null)
            {
                _context.LoanTypes.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
