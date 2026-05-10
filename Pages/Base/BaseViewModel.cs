using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinanceProject.Pages.Base;

public class BaseViewModel : INotifyPropertyChanged
{
    #region Interface
    public new event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    protected ServiceModel BaseService;
    protected void InitializeBaseService(ServiceModel serviceModel) { BaseService = serviceModel; }
}