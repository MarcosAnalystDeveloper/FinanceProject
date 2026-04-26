using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace FinanceProject;

public partial class PageLogin : Window
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
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            this.BeginMoveDrag(e);
    }
}