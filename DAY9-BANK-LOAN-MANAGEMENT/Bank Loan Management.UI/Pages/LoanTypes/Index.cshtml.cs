using BankLoanManagement.UI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BankLoanManagement.UI.Pages.LoanTypes
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _factory;

        public List<LoanTypeViewModel> LoanTypes { get; set; } = new();

        public IndexModel(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task OnGetAsync()
        {
            var client = _factory.CreateClient();

            var response = await client.GetStringAsync(
                "https://localhost:7011/api/LoanTypes");

            LoanTypes = JsonConvert.DeserializeObject<List<LoanTypeViewModel>>(response)
                        ?? new List<LoanTypeViewModel>();
        }
    }
}