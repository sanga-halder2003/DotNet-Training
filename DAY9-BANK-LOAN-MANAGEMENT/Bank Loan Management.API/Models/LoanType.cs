using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Bank_Loan_Management.Models
{
    public class LoanType
    {
        [Key]
        public int LoanTypeId {  get; set; }

        public string LoanName { get; set; }
        [Precision(18, 2)]
        public decimal InterestRate { get; set; }
        [Precision(18, 2)]
        public decimal MaxLoanAmount { get; set; }

        public int MaxTenureMonths { get; set; }
    }
}
