namespace FinanceProject;

public partial class PageMenu : BasePage
{
    #region Properties  
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