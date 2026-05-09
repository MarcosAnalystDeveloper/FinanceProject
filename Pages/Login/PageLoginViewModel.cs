using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FinanceProject.Pages.Login.Model;

public class PageLoginViewModel : INotifyPropertyChanged
{
    #region Interface
    public new event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    #region Properties
    private PageLoginModel LoginService = new();

    private string _userName = string.Empty;
    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName != value)
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
    }

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion

    public PageLoginViewModel() { }

    public async Task<AuthenticationResult?> Login() { return await LoginService.Authorization("userTest@example.com", "123"); }
}