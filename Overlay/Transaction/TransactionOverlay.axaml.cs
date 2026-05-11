using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace FinanceProject;

public partial class TransactionOverlay : Window
{
    public TransactionOverlay()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    #region Events
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        if (Design.IsDesignMode)
            return;

        //btnCancel.PointerPressed += BtnCancel_PointerPressed;
        //BtnConfirm.Click += BtnConfirm_Click;
    }

    private void BtnConfirm_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) { Close(true); }
    private void BtnCancel_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { Close(false); }
    #endregion
}