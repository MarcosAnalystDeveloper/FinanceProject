using CommunityToolkit.Mvvm.ComponentModel;

namespace FinanceProject.Pages;

public partial class PageMenuViewModel : ObservableObject 
{
    [ObservableProperty]
    private bool _isPaneOpen = true;
}