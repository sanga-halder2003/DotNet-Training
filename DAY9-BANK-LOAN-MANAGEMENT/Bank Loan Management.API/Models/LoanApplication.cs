using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Loan_Management.Models
{
    public class LoanApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("LoanType")]
        public int LoanTypeId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RequestedAmount { get; set; }

        public int TenureMonths { get; set; }

        public string Purpose { get; set; }

        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";

        public Customer Customer { get; set; }

        public LoanType LoanType { get; set; }
    }
}