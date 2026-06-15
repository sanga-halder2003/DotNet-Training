using Bank_Loan_Management.DTOs;

namespace Bank_Loan_Management.Services
   

{
    public interface ILoanApplicationService
    {
        Task<List<LoanApplicationResponseDto>> GetAllAsync();
        Task<LoanApplicationResponseDto?> GetByIdAsync(int id);
        Task ApplyLoanAsync(LoanApplicationCreateDto dto);

        Task DeleteAsync(int id);
    }
}
