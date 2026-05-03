using Avalonia;
using Avalonia.Controls;
using FinanceProject.Pages.Login.Model;

namespace FinanceProject;

public partial class PageLogin : BasePage
{
    public PageLogin()
    {
        InitializeComponent();
        InitializeEvents();
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
    private async void btnLogin_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { ExecuteRequestGetUser(); }
    #endregion

    #region Methods
    private async void ExecuteRequestGetUser()
    {
        if (!string.IsNullOrEmpty(inputEmail.Text) && !string.IsNullOrEmpty(inputPassword.Text))
        {
            PageLoginViewModel viewModel = new PageLoginViewModel();
            string? token = await viewModel.GetUser(inputEmail.Text, inputPassword.Text);
            if (token is not null) 
            {
                PageMenu pageMenu = new PageMenu();
                pageMenu.Show();
                this.Close();
            }
        }
    }

    #endregion
}