using Bank_Loan_Management.Models;

namespace Bank_Loan_Management.Repositories
{
    public interface ILoanApplicationRepository
    {
        Task<List<LoanApplication>> GetAllAsync();

        Task<LoanApplication?> GetByIdAsync(int id);

        Task AddAsync(LoanApplication application);

        Task UpdateAsync(LoanApplication application);

        Task DeleteAsync(int id);
    }
}