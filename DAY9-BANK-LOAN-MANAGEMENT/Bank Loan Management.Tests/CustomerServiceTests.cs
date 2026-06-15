using Bank_Loan_Management.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Bank_Loan_Management.Models;
using Bank_Loan_Management.Services;
using Bank_Loan_Management.DTOs;

namespace BankLoanManagement.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task AddCustomer_Should_CallRepositoryAdd()
        {
            var mockRepo = new Mock<ICustomerRepository>();
            var service = new CustomerService(mockRepo.Object);
            var dto = new CustomerCreateDto
            {
                FullName = "Sanga Halder",
                Email = "sangahalder@gmail.com",
                MobileNumber = "6789054312",
                Address = "Bangalore",
                PANNumber = "ABCDE1234F",
                AnnualIncome = 600000
            };

            await service.AddCustomerAsync(dto);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Customer>()), Times.Once);

        }
        [Fact]
        public async Task GetCustomerById_Should_ReturnCustomer_WhenCustomerExists()
        {
            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(new Customer
                {
                    CustomerId = 1,
                    FullName = "Sanga Halder",
                    Email = "sanga@gmail.com",
                    AnnualIncome = 600000
                });

            var service = new CustomerService(mockRepo.Object);

            var result = await service.GetCustomerByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Sanga Halder", result.FullName);
            Assert.Equal(600000, result.AnnualIncome);
        }






    }
}
