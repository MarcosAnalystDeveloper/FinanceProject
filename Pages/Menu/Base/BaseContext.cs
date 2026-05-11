using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinanceProject.Pages;

public class BaseContext : UserControl, INotifyPropertyChanged
{
    protected WindowNotificationManager _notificationManager;
    public new event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
}
