using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Login;

public class PageLoginModel : ServiceModel
{
    public async Task<AuthenticationResult?> Authorization(string username, string password)
    {
        HttpClient client = new HttpClient() { BaseAddress = BaseUrl };

        Dictionary<string, string> dict = new Dictionary<string, string> { { "username", username }, { "password", password } };

        var content = new FormUrlEncodedContent(dict);
        try
        {
            var response = await client.PostAsync("login", content);
            var result = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<AuthenticationResult>(result, JsonOptions) : null;
        }
        catch (Exception e) { return null; }
    }
}

public record AuthenticationResult(string acess_token);