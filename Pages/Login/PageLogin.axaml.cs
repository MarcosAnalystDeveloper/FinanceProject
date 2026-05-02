using Avalonia.Controls;

namespace FinanceProject;

public partial class PageLogin : BasePage
{
    public PageLogin()
    {
        InitializeComponent();
        InitializeEvents();
    }

    private void InitializeEvents()
    {
        mainBorder.PointerPressed += MainBorder_PointerPressed;
    }

    private void MainBorder_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        if (WindowState != WindowState.Maximized)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
                this.BeginMoveDrag(e);
        }
    }
}