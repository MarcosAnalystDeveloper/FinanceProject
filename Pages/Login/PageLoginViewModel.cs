using FinanceProject.Pages.Base;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Login.Model;

public class PageLoginViewModel : BaseViewModel
{
    public PageLoginViewModel() { InitializeBaseService(new PageLoginModel()); }
    public async Task<AuthenticationResult?> Login(string email, string pasword) { return await ((PageLoginModel)BaseService).Authorization(email, pasword); }
}