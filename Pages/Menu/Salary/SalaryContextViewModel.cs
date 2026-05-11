using FinanceProject.Enum;
using FinanceProject.Pages.Base;
using FinanceProject.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Menu.Salary;

public class SalaryContextViewModel : BaseViewModel
{
    public SalaryContextViewModel(string token)
    {
        InitializeBaseService(new SalaryContextModel());
        ((SalaryContextModel)BaseService).TokenAuthorization = token;
    }

    public async Task<List<TransactionFinance>?> LoadListSalary()
    {
        List<TransactionFinance>? listTransactions = await ((SalaryContextModel)BaseService).GetAllTransactions();
        if (listTransactions is not null && listTransactions.Count > 0)
            listTransactions.RemoveAll(t => t.Type == EnumTransactionType.Saida);

        return listTransactions;
    }
    public async Task<bool> DeleteTransaction(long salaryId) { return await ((SalaryContextModel)BaseService).DeleteSalary(salaryId); }
}