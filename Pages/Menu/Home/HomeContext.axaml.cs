using Avalonia.Controls;

namespace FinanceProject;

public partial class HomeContext : UserControl
{
    public HomeContext()
    {
        InitializeComponent();
        this.DataContext = this;
    }
}