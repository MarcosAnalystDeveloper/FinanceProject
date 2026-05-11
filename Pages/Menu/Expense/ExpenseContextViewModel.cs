using FinanceProject.Enum;
using FinanceProject.Pages.Base;
using FinanceProject.Pages.Menu.Salary;
using FinanceProject.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Menu.Expense;

public class ExpenseContextViewModel : BaseViewModel
{
    public ExpenseContextViewModel(string token)
    {
        InitializeBaseService(new ExpenseContextModel());
        ((ExpenseContextModel)BaseService).TokenAuthorization = token;
    }

    public async Task<List<TransactionFinance>?> LoadListExpense()
    {
        List<TransactionFinance>? listTransactions = await ((ExpenseContextModel)BaseService).GetAllTransactions();
        if (listTransactions is not null && listTransactions.Count > 0)
            listTransactions.RemoveAll(t => t.Type == EnumTransactionType.Entrada);

        return listTransactions;
    }
    public async Task<bool> DeleteTransaction(long expenseId) { return await ((ExpenseContextModel)BaseService).DeleteExpense(expenseId); }
}