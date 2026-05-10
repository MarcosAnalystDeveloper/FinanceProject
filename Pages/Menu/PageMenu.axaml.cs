using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using FinanceProject.Pages.Menu;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FinanceProject;

public partial class PageMenu : BasePage
{
    public PageMenuViewModel MenuViewModel;
    public PageMenu()
    {
        InitializeComponent();
        this.DataContext = this;
        lbxDrawer.SelectedItem = lbxDrawer.Items.First();
        hasFirstSelected = false;
        InitializeEvents(); 
    }

    #region Properties  
    public UserFinance Profile { get; set; }
    public string Token { get; set; }
    public ObservableCollection<TabItemTemplate> ListTabItem { get; } = new()
    {
        new TabItemTemplate("home", "Menu", typeof(HomeContext)),
        new TabItemTemplate("savings", "Novo Salário", typeof(SalaryContext)),
        new TabItemTemplate("receipt", "Nova Dispesa", typeof(ExpenseContext)),
        new TabItemTemplate("settings", "Configurações", typeof(SettingsContext))
    };
    public bool hasFirstSelected { get; set; } = true;

    private bool _isPaneOpen = false;
    public bool IsPaneOpen
    {
        get => _isPaneOpen;
        set
        {
            if (_isPaneOpen != value)
            {
                _isPaneOpen = value;
                OnPropertyChanged();
            }
        }
    }

    private UserControl _currentPage = new HomeContext();
    public UserControl CurrentPage
    {
        get => _currentPage;
        set
        {
            if (_currentPage != value)
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion

    #region Methods
    private void InitializeEvents()
    {
        lbxDrawer.SelectionChanged += LbxDrawer_SelectionChanged;
        btnLogout.PointerPressed += btnLogout_PointerPressed;
        btnMenu.PointerPressed += btnMenu_PointerPressed;
    }
    private async void InitializeUserProfile()
    {
        MenuViewModel = new PageMenuViewModel(Token);
        UserFinance? user = await MenuViewModel.LoadUser();
        if (user is not null)
            Profile = user;
    }
    #endregion

    #region Events
    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (Design.IsDesignMode)
            return;

        InitializeUserProfile();
    }
    private void btnLogout_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        PageLogin pageLogin = new PageLogin();
        pageLogin.Show();
        this.Close();
    }
    private void LbxDrawer_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (!hasFirstSelected)
        {
            if (sender is ListBox listBox)
            {
                if (listBox.SelectedItem is not null && listBox.SelectedItem is TabItemTemplate tabItemTemplate)
                {
                    switch (tabItemTemplate.PageType)
                    {
                        case Type t when t == typeof(HomeContext):
                            CurrentPage = new HomeContext();
                            break;
                        case Type t when t == typeof(SalaryContext):
                            CurrentPage = new SalaryContext();
                            break;
                        case Type t when t == typeof(ExpenseContext):
                            CurrentPage = new ExpenseContext();
                            break;
                        case Type t when t == typeof(SettingsContext):
                            CurrentPage = new SettingsContext();
                            break;
                    }
                }
            }
        }
    }
    private void btnMenu_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { IsPaneOpen = !IsPaneOpen; }
    #endregion

}

public class TabItemTemplate
{
    public string Title { get; init; }
    public StreamGeometry Icon { get; init; }
    public Type PageType { get; set; }

    public TabItemTemplate(string icon, string title, Type type)
    {
        Title = title;
        if (!string.IsNullOrEmpty(icon))
        {
            if (Application.Current!.TryFindResource(icon, ThemeVariant.Default, out var result))
            {
                if (result is StreamGeometry themeIcon)
                    Icon = themeIcon;
            }
        }
        PageType = type;
    }
}