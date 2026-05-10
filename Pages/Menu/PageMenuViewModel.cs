using FinanceProject.Pages.Base;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Menu;

public  class PageMenuViewModel : BaseViewModel
{
    public PageMenuViewModel(string token)
    {
        InitializeBaseService(new PageMenuModel());
        ((PageMenuModel)BaseService).TokenAuthorization = token;
    }
    public async Task<UserFinance?> LoadUser() { return await ((PageMenuModel)BaseService).GetUser(); }
}