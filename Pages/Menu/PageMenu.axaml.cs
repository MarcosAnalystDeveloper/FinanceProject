using Avalonia.Controls;
using System;
using System.Collections.ObjectModel;

namespace FinanceProject;

public partial class PageMenu : BasePage
{
    #region Properties  
    public ObservableCollection<TabItemTemplate> ListTabItem { get; } = new() { new TabItemTemplate(typeof(HomeContext)) };

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
    public string TabName { get; }
    public Type ModelType { get; }

    public TabItemTemplate(Type type)
    {
        ModelType = type;
        TabName = ModelType.Name.Replace("Context", "");
    }
}