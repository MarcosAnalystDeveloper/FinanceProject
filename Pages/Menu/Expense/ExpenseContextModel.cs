using FinanceProject.Transaction;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Menu.Expense;

public class ExpenseContextModel : ServiceModel
{
    public string TokenAuthorization { get; set; }

    public async Task<List<TransactionFinance>?> GetAllTransactions()
    {
        HttpClient client = new HttpClient() { BaseAddress = BaseUrl };

        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAuthorization);
            HttpResponseMessage? response = await client.GetAsync("transactions/listar");
            string? result = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<List<TransactionFinance>>(result, JsonOptions) : null;
        }
        catch (Exception)
        {
            return null;
        }
    }
    public async Task<bool> DeleteExpense(long id)
    {
        HttpClient client = new HttpClient() { BaseAddress = BaseUrl };

        try
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAuthorization);
            HttpResponseMessage? response = await client.DeleteAsync($"transactions/{id}");
            string? result = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode ? true : false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}