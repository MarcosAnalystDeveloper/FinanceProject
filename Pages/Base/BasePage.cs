using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinanceProject;

public class BasePage : Window, INotifyPropertyChanged
{
    protected WindowNotificationManager _notificationManager;
    public new event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
}