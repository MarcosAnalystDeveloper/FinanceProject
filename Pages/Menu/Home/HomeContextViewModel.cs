using FinanceProject.Pages.Base;
using FinanceProject.Pages.Menu.Salary;
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

    public async Task<List<TransactionFinance>?> LoadListTransactions() { return await ((SalaryContextModel)BaseService).GetAllTransactions(); }
}