using Bank_Loan_Management.Models;

namespace Bank_Loan_Management.Repositories
{
    public interface ILoanTypeRepository
    {
        Task<List<LoanType>> GetAllAsync();

        Task<LoanType?> GetByIdAsync(int id);

        Task AddAsync(LoanType loan);

        Task UpdateAsync(LoanType loan);

        Task DeleteAsync(int id);
    }
}
