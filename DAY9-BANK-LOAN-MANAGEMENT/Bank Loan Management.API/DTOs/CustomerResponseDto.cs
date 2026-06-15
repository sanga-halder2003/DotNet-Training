namespace Bank_Loan_Management.DTOs
{
    public class CustomerResponseDto
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public decimal AnnualIncome { get; set; }
    }
}
