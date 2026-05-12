using FinanceProject.Pages.Base;
using FinanceProject.Transaction;
using System.Threading.Tasks;

namespace FinanceProject.Overlay.Transaction;

public class TransactionOverlayViewModel : BaseViewModel
{
    public TransactionOverlayViewModel(string token)
    {
        InitializeBaseService(new TransactionOverlayModel());
        ((TransactionOverlayModel)BaseService).TokenAuthorization = token;
    }

    #region Method
    public async Task<bool> CreateTransaction(string description, double amount, string type, string category) { return await ((TransactionOverlayModel)BaseService).CreateTransaction(description, amount, type, category); }
    public async Task<bool> EditedTransaction(TransactionFinance transactionFinance) { return await ((TransactionOverlayModel)BaseService).EditTransaction(transactionFinance); }
    #endregion
}