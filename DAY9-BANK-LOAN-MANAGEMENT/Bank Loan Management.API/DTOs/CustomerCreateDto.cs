namespace Bank_Loan_Management.DTOs
{
    public class CustomerCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; } 
        public string MobileNumber { get; set; } 
        public string Address { get; set; }

        public string PANNumber { get; set; }

        public decimal AnnualIncome { get; set; }
    }
}
