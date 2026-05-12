using FinanceProject.Pages;
using FinanceProject.Transaction;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FinanceProject.Overlay.Transaction;

public class TransactionOverlayModel : ServiceModel
{
    public string TokenAuthorization { get; set; }

    public async Task<bool> CreateTransaction(string description, double amount, string type, string category)
    {
        HttpClient client = new HttpClient() { BaseAddress = BaseUrl };

        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAuthorization);
            HttpResponseMessage? response = await client.PostAsync($"transactions/", JsonContent.Create(new
            {
                description = description, amount = amount,
                type = type, category = category
            }, 
            options: JsonOptions));

            string? result = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode ? true : false;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> EditTransaction(TransactionFinance transactionFinance)
    {
        HttpClient client = new HttpClient() { BaseAddress = BaseUrl };

        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAuthorization);
            HttpResponseMessage? response = await client.PutAsync($"transactions/transactions/{transactionFinance.Id}", JsonContent.Create(new
            {
                description = transactionFinance.Description,
                amount = transactionFinance.Amount,
                type = transactionFinance.Type,
                category = transactionFinance.Category
            }, options: JsonOptions));

            string? result = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode ? true : false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}