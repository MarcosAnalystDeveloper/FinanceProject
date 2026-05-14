using FinanceProject.Entities;
using FinanceProject.Pages.Base;
using FinanceProject.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Menu.Home;

public class HomeContextViewModel : BaseViewModel
{
    public HomeContextViewModel(string token)
    {
        InitializeBaseService(new HomeContextModel());
        ((HomeContextModel)BaseService).TokenAuthorization = token;
    }

    public async Task<SummaryFinance?> GetSummary() { return await ((HomeContextModel)BaseService).GetSummary(); }
    public async Task<List<TransactionFinance>?> LoadListTransactions() { return await ((HomeContextModel)BaseService).GetAllTransactions(); }
}