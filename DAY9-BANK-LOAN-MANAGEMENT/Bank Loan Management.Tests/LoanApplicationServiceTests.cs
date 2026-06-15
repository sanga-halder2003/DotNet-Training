using Bank_Loan_Management.DTOs;
using Bank_Loan_Management.Models;
using Bank_Loan_Management.Repositories;
using Bank_Loan_Management.Services;
using Moq;

namespace BankLoanManagement.Tests
{
    public class LoanApplicationServiceTests
    {
        [Fact]
        public async Task ApplyLoan_Should_CreateApplication_WhenValidData()
        {
            var loanRepo = new Mock<ILoanApplicationRepository>();
            var customerRepo = new Mock<ICustomerRepository>();
            var loanTypeRepo = new Mock<ILoanTypeRepository>();

            customerRepo.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(new Customer
                {
                    CustomerId = 1,
                    AnnualIncome = 600000
                });

            loanTypeRepo.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(new LoanType
                {
                    LoanTypeId = 1,
                    MaxLoanAmount = 500000,
                    MaxTenureMonths = 60
                });

            var service = new LoanApplicationService(
                loanRepo.Object,
                customerRepo.Object,
                loanTypeRepo.Object);

            var dto = new LoanApplicationCreateDto
            {
                CustomerId = 1,
                LoanTypeId = 1,
                RequestedAmount = 300000,
                TenureMonths = 36,
                Purpose = "Education"
            };

            await service.ApplyLoanAsync(dto);

            loanRepo.Verify(r => r.AddAsync(It.IsAny<LoanApplication>()), Times.Once);
        }

        [Fact]
        public async Task ApplyLoan_Should_ThrowException_WhenIncomeBelowMinimum()
        {
            var loanRepo = new Mock<ILoanApplicationRepository>();
            var customerRepo = new Mock<ICustomerRepository>();
            var loanTypeRepo = new Mock<ILoanTypeRepository>();

            customerRepo.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(new Customer
                {
                    CustomerId = 1,
                    AnnualIncome = 200000
                });

            var service = new LoanApplicationService(
                loanRepo.Object,
                customerRepo.Object,
                loanTypeRepo.Object);

            var dto = new LoanApplicationCreateDto
            {
                CustomerId = 1,
                LoanTypeId = 1,
                RequestedAmount = 300000,
                TenureMonths = 36,
                Purpose = "Education"
            };

            var ex = await Assert.ThrowsAsync<Exception>(() =>
                service.ApplyLoanAsync(dto));

            Assert.Equal("Customer income must be greater than 3 lakh", ex.Message);
        }
    }
}