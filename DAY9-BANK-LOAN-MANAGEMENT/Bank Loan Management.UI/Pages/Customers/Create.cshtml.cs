using BankLoanManagement.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace BankLoanManagement.UI.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _factory;

        [BindProperty]
        public CustomerViewModel Customer { get; set; } = new();

        public CreateModel(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _factory.CreateClient();

            var json = JsonConvert.SerializeObject(Customer);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            await client.PostAsync(
                "https://localhost:7011/api/Customer",
                content);

            return RedirectToPage("Index");
        }
    }
}