using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace FinanceProject;

public partial class PrincipalOverlay : Window
{
    public PrincipalOverlay()
    {
        InitializeComponent();
    }

    #region Events
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        if (Design.IsDesignMode)
            return;

        btnCancel.PointerPressed += BtnCancel_PointerPressed;
        btnConfirm.PointerPressed += BtnConfirm_Click;
    }

    private void BtnConfirm_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) { Close(true); }
    private void BtnCancel_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { Close(false); }
    #endregion
}