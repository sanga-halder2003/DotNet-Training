using Bank_Loan_Management.DTOs;
using Bank_Loan_Management.Models;
using Bank_Loan_Management.Repositories;

namespace Bank_Loan_Management.Services
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILoanApplicationRepository _loanRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly ILoanTypeRepository _loanTypeRepo;
        private readonly ILoanRepository _loanRepository;
        private readonly IEMIRepository _emiRepository;

        public LoanApplicationService(
            ILoanApplicationRepository loanRepo,
            ICustomerRepository customerRepo,
            ILoanTypeRepository loanTypeRepo,
            ILoanRepository loanRepository,
            IEMIRepository emiRepository)
        {
            _loanRepo = loanRepo;
            _customerRepo = customerRepo;
            _loanTypeRepo = loanTypeRepo;
            _loanRepository = loanRepository;
            _emiRepository = emiRepository;
        }

        public async Task<List<LoanApplicationResponseDto>> GetAllAsync()
        {
            var applications = await _loanRepo.GetAllAsync();

            return applications.Select(a => new LoanApplicationResponseDto
            {
                ApplicationId = a.ApplicationId,
                CustomerId = a.CustomerId,
                LoanTypeId = a.LoanTypeId,
                RequestedAmount = a.RequestedAmount,
                TenureMonths = a.TenureMonths,
                Purpose = a.Purpose,
                ApplicationDate = a.ApplicationDate,
                Status = a.Status
            }).ToList();
        }

        public async Task<LoanApplicationResponseDto?> GetByIdAsync(int id)
        {
            var application = await _loanRepo.GetByIdAsync(id);

            if (application == null)
                return null;

            return new LoanApplicationResponseDto
            {
                ApplicationId = application.ApplicationId,
                CustomerId = application.CustomerId,
                LoanTypeId = application.LoanTypeId,
                RequestedAmount = application.RequestedAmount,
                TenureMonths = application.TenureMonths,
                Purpose = application.Purpose,
                ApplicationDate = application.ApplicationDate,
                Status = application.Status
            };
        }

        public async Task ApplyLoanAsync(LoanApplicationCreateDto dto)
        {
            var customer = await _customerRepo.GetByIdAsync(dto.CustomerId);

            if (customer == null)
                throw new Exception("Customer not found");

            if (customer.AnnualIncome < 300000)
                throw new Exception("Customer income must be greater than 3 lakh");

            var loanType = await _loanTypeRepo.GetByIdAsync(dto.LoanTypeId);

            if (loanType == null)
                throw new Exception("Loan type not found");

            if (dto.RequestedAmount > loanType.MaxLoanAmount)
                throw new Exception("Loan amount exceeds maximum limit");

            if (dto.TenureMonths > loanType.MaxTenureMonths)
                throw new Exception("Tenure exceeds maximum allowed");

            var application = new LoanApplication
            {
                CustomerId = dto.CustomerId,
                LoanTypeId = dto.LoanTypeId,
                RequestedAmount = dto.RequestedAmount,
                TenureMonths = dto.TenureMonths,
                Purpose = dto.Purpose,
                ApplicationDate = DateTime.Now,
                Status = "Pending"
            };

            await _loanRepo.AddAsync(application);
        }

        public async Task ApproveLoanAsync(int id)
        {
            var application = await _loanRepo.GetByIdAsync(id);

            if (application == null)
                throw new Exception("Application not found");

            if (application.Status == "Approved")
                throw new Exception("Loan already approved");

            if (application.Status == "Rejected")
                throw new Exception("Rejected loan cannot be approved");

            var loanType = await _loanTypeRepo.GetByIdAsync(application.LoanTypeId);

            if (loanType == null)
                throw new Exception("Loan type not found");

            decimal principal = application.RequestedAmount;
            decimal monthlyRate = loanType.InterestRate / 12 / 100;
            int months = application.TenureMonths;

            decimal emi;

            if (monthlyRate == 0)
            {
                emi = principal / months;
            }
            else
            {
                double p = (double)principal;
                double r = (double)monthlyRate;
                double n = months;

                emi = (decimal)(p * r * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1));
            }

            emi = Math.Round(emi, 2);

            decimal totalPayment = emi * months;
            decimal totalInterest = totalPayment - principal;

            var loan = new Loan
            {
                ApplicationId = application.ApplicationId,
                CustomerId = application.CustomerId,
                LoanTypeId = application.LoanTypeId,
                LoanAmount = principal,
                EMIAmount = emi,
                TotalInterest = Math.Round(totalInterest, 2),
                TotalPayment = Math.Round(totalPayment, 2),
                TenureMonths = months,
                ApprovedDate = DateTime.Now,
                Status = "Active"
            };

            await _loanRepository.AddAsync(loan);

            var emiList = new List<LoanEMI>();

            for (int i = 1; i <= months; i++)
            {
                emiList.Add(new LoanEMI
                {
                    LoanId = loan.LoanId,
                    InstallmentNumber = i,
                    DueDate = DateTime.Now.AddMonths(i),
                    EMIAmount = emi,
                    PaymentStatus = "Pending"
                });
            }

            await _emiRepository.AddRangeAsync(emiList);

            application.Status = "Approved";
            await _loanRepo.UpdateAsync(application);
        }

        public async Task RejectLoanAsync(int id)
        {
            var application = await _loanRepo.GetByIdAsync(id);

            if (application == null)
                throw new Exception("Application not found");

            if (application.Status != "Pending")
                throw new Exception("Only pending loans can be rejected");

            application.Status = "Rejected";

            await _loanRepo.UpdateAsync(application);
        }

        public async Task DeleteAsync(int id)
        {
            await _loanRepo.DeleteAsync(id);
        }
    }
}