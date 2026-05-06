using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Login;

public class PageLoginModel
{
    private Uri BaseUrl { get; } = new Uri("https://localhost:800/");
    public static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };


    public async Task<AuthenticationResult?> Authorization(string userName, string password)
    {
        HttpClient client = new HttpClient() { BaseAddress = BaseUrl };
        var response = await client.PostAsync("POST/token/", JsonContent.Create(new
        {
            userName,
            password
        }));
        var content = await response.Content.ReadAsStringAsync();
        return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<AuthenticationResult>(content, JsonOptions) : null;
    }
}

public record AuthenticationResult(string Token);