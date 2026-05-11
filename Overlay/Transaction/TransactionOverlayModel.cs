using FinanceProject.Pages;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FinanceProject.Overlay.Transaction;

public class TransactionOverlayModel : ServiceModel
{
    public string TokenAuthorization { get; set; }

    public async Task<bool> EditTransaction(long id)
    {
        HttpClient client = new HttpClient() { BaseAddress = BaseUrl };

        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAuthorization);
            HttpResponseMessage? response = await client.PutAsync($"transactions/transactions/{id}", default);
            string? result = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? true : false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}