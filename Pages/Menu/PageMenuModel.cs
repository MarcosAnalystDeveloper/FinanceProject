using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Menu;

public class PageMenuModel : ServiceModel
{
    public string TokenAuthorization { get; set; }

    public async Task<UserFinance?> GetUser()
    {
        HttpClient client = new HttpClient() { BaseAddress = BaseUrl };

        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAuthorization);

            var response = await client.GetAsync("users/me",  HttpCompletionOption.ResponseContentRead);
            var result = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<UserFinance>(result, JsonOptions) : null;
        }
        catch (Exception e) { return null; }
    }
}