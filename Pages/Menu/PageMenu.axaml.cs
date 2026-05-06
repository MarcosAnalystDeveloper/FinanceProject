using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Styling;
using LiveChartsCore.Themes;
using System;
using System.Collections.ObjectModel;

namespace FinanceProject;

public partial class PageMenu : BasePage
{
    #region Properties  
    public string Token { get; set; } = string.Empty;
    public ObservableCollection<TabItemTemplate> ListTabItem { get; } = new()
    {
        new TabItemTemplate("home", "Menu"),
        new TabItemTemplate("menu", "Novo Salário"),
        new TabItemTemplate("menu", "Nova Dispesa"),
        new TabItemTemplate("settings", "Configurações")
    };

    private bool _isPaneOpen = true;
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
    public PageMenu()
    {
        InitializeComponent();
        this.DataContext = this;
        InitializeEvents();
    }

    #region Events
    private void btnMenu_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { IsPaneOpen = !IsPaneOpen; }
    #endregion

    #region Methods
    private void InitializeEvents()
    {
        btnMenu.PointerPressed += btnMenu_PointerPressed;
    }
    #endregion
}

public class TabItemTemplate
{
    public string Title { get; init; }
    public StreamGeometry Icon { get; init; }

    public TabItemTemplate(string icon, string title)
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
    }
}