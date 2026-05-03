using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Login.Model;

public class PageLoginViewModel
{
    private Uri BaseUrl { get; } = new Uri("https://localhost:800/");

    public async Task<string?> GetUser(string email, string password)
    {
        HttpClient client = new HttpClient() { BaseAddress = BaseUrl };
        await client.GetFromJsonAsync<UserFinance>($"POST/token/{email}");
        return null;
    }
}