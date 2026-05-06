using Avalonia;
using Avalonia.Controls;
using FinanceProject.Pages.Login;
using FinanceProject.Pages.Login.Model;

namespace FinanceProject;

public partial class PageLogin : BasePage
{
    public PageLoginViewModel LoginViewModel => (PageLoginViewModel)this.DataContext!;

    public PageLogin()
    {
        InitializeComponent();
        InitializeEvents();
        DataContext = new PageLoginViewModel();
    }

    #region Events
    private void InitializeEvents()
    {
        btnMinimize.PointerPressed += btnMinimize_PointerPressed;
        btnClose.PointerPressed += btnClose_PointerPressed;
        btnLogin.PointerPressed += btnLogin_PointerPressed;
    }
    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == WindowStateProperty)
        {
            var newState = change.GetNewValue<WindowState>();
            var oldState = change.GetOldValue<WindowState>();

            if (oldState == WindowState.Minimized && newState != WindowState.Minimized)
                this.WindowState = WindowState.FullScreen;
        }
    }
    private void btnMinimize_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { this.WindowState = WindowState.Minimized; }
    private void btnClose_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { this.Close(); }
    private async void btnLogin_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { Execute_Login(); }
    #endregion

    #region Methods
    private async void Execute_Login()
    {
        if (!string.IsNullOrEmpty(inputEmail.Text) && !string.IsNullOrEmpty(inputPassword.Text))
        {
            AuthenticationResult authentication = await LoginViewModel.Login();
            PageMenu pageMenu = new PageMenu();
            pageMenu.Token = authentication.Token;
            pageMenu.Show();
            this.Close();
        }
    }

    #endregion
}