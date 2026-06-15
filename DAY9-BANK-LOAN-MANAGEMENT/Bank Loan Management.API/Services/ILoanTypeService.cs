using Bank_Loan_Management.DTOs;

namespace Bank_Loan_Management.Services
{
    public interface ILoanTypeService
    {
        Task<List<LoanTypeResponseDto>> GetAllAsync();

        Task<LoanTypeResponseDto?> GetByIdAsync(int id);

        Task AddAsync(LoanTypeCreateDto dto);

        Task UpdateAsync(int id, LoanTypeCreateDto dto);

        Task DeleteAsync(int id);
    }
}
