using Bank_Loan_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanEMI> LoanEMIs { get; set; }
    }
}