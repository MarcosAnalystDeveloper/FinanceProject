using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Login.Model;

public class PageLoginViewModel : INotifyPropertyChanged
{
    private PageLoginModel LoginService = new();

    #region Interface
    public new event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    public PageLoginViewModel() { }
    public async Task<AuthenticationResult?> Login(string email, string pasword) { return await LoginService.Authorization(email, pasword); }
}