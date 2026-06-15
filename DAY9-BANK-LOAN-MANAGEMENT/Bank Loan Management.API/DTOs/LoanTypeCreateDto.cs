namespace Bank_Loan_Management.DTOs
{
    public class LoanTypeCreateDto
    {
        public string LoanName { get; set; }
        public decimal InterestRate { get; set; }

        public decimal MaxLoanAmount { get; set; }

        public int MaxTenureMonths { get; set; }
    }
}
