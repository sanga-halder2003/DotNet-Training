using Bank_Loan_Management.DTOs;
using Bank_Loan_Management.Models;
using Bank_Loan_Management.Repositories;

namespace Bank_Loan_Management.Services
{
    public class LoanTypeService : ILoanTypeService
    {
        private readonly ILoanTypeRepository _repository;

        public LoanTypeService(ILoanTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LoanTypeResponseDto>> GetAllAsync()
        {
            var loans = await _repository.GetAllAsync();

            return loans.Select(l => new LoanTypeResponseDto
            {
                LoanTypeId = l.LoanTypeId,
                LoanName = l.LoanName,
                InterestRate = l.InterestRate,
                MaxLoanAmount = l.MaxLoanAmount,
                MaxTenureMonths = l.MaxTenureMonths
            }).ToList();
        }

        public async Task<LoanTypeResponseDto?> GetByIdAsync(int id)
        {
            var loan = await _repository.GetByIdAsync(id);

            if (loan == null)
                return null;

            return new LoanTypeResponseDto
            {
                LoanTypeId = loan.LoanTypeId,
                LoanName = loan.LoanName,
                InterestRate = loan.InterestRate,
                MaxLoanAmount = loan.MaxLoanAmount,
                MaxTenureMonths = loan.MaxTenureMonths
            };
        }

        public async Task AddAsync(LoanTypeCreateDto dto)
        {
            var loan = new LoanType
            {
                LoanName = dto.LoanName,
                InterestRate = dto.InterestRate,
                MaxLoanAmount = dto.MaxLoanAmount,
                MaxTenureMonths = dto.MaxTenureMonths
            };

            await _repository.AddAsync(loan);
        }

        public async Task UpdateAsync(int id, LoanTypeCreateDto dto)
        {
            var loan = await _repository.GetByIdAsync(id);

            if (loan == null)
                throw new Exception("Loan Type not found");

            loan.LoanName = dto.LoanName;
            loan.InterestRate = dto.InterestRate;
            loan.MaxLoanAmount = dto.MaxLoanAmount;
            loan.MaxTenureMonths = dto.MaxTenureMonths;

            await _repository.UpdateAsync(loan);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
