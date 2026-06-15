using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_Loan_Management.Models
{
    public class LoanEMI
    {
        [Key]
        public int EMIId { get; set; }

        public int LoanId { get; set; }

        public int InstallmentNumber { get; set; }

        public DateTime DueDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EMIAmount { get; set; }

        public DateTime? PaidDate { get; set; }

        public string PaymentStatus { get; set; } = "Pending";
    }
}