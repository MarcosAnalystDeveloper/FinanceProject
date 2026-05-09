using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using FinanceProject.Pages.Login;
using FinanceProject.Pages.Login.Model;

namespace FinanceProject;

public partial class PageLogin : BasePage
{
    private WindowNotificationManager _notificationManager;
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
    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (Design.IsDesignMode)
            return;

        _notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.TopRight,
            MaxItems = 2
        };
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
        if (!string.IsNullOrEmpty(inputEmail.Value) & !string.IsNullOrEmpty(inputPassword.Value))
        {
            LoadingOverlay.IsVisible = true;
            AuthenticationResult? authentication = await LoginViewModel.Login();
            LoadingOverlay.IsVisible = false;
            if (authentication is not null)
            {
                PageMenu pageMenu = new PageMenu();
                pageMenu.Token = authentication.acess_token;
                pageMenu.Show();
                this.Close();
            }
            else
                _notificationManager.Show(new Notification("Erro", "Email ou Senha errados.", NotificationType.Error));
        }
        else
            _notificationManager.Show(new Notification("Campos vazios", "Preencha todos os campos para continuar.", NotificationType.Warning));
    }
    #endregion
}