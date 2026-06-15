using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Bank_Loan_Management.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email {  get; set; }

        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public string PANNumber { get; set; }

        [Precision(18, 2)]
        public decimal AnnualIncome { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
