using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Loan_Management.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        public int ApplicationId { get; set; }

        public int CustomerId { get; set; }

        public int LoanTypeId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LoanAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EMIAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalInterest { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPayment { get; set; }

        public int TenureMonths { get; set; }

        public DateTime ApprovedDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Active";
    }
}