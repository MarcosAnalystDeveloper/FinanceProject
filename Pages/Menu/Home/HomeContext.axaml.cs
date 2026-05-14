using Avalonia.Controls;
using Avalonia.Interactivity;

namespace FinanceProject;

public partial class HomeContext : UserControl
{
    public HomeContext()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (Design.IsDesignMode)
            return;
    }
}