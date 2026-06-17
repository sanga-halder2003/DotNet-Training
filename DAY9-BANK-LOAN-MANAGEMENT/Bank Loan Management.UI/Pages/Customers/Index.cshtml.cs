using BankLoanManagement.UI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BankLoanManagement.UI.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _factory;

        public List<CustomerViewModel> Customers { get; set; } = new();

        public IndexModel(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task OnGetAsync()
        {
            var client = _factory.CreateClient();

            var response = await client.GetStringAsync(
                "https://localhost:7011/api/Customer");

            Customers = JsonConvert.DeserializeObject<List<CustomerViewModel>>(response)
                        ?? new List<CustomerViewModel>();
        }
    }
}