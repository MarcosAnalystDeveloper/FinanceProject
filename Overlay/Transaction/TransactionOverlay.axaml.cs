using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using FinanceProject.Enum;
using FinanceProject.Transaction;

namespace FinanceProject;

public partial class TransactionOverlay : Window
{
    #region Properties
    public EnumTransactionType TransactionType { get; set; }
    public string ButtonTextAddOrUpdate { get; set; } = string.Empty;
    public TransactionFinance? CurrentTransaction;
    public string Category { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    #endregion

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

        btnCancel.PointerPressed += BtnCancel_PointerPressed;
        btnNewOrUpdate.PointerPressed += BtnConfirm_PointerPressed;
    }

    private void BtnConfirm_PointerPressed(object? sender, Avalonia.Interactivity.RoutedEventArgs e) { Close(true); }
    private void BtnCancel_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { Close(false); }
    #endregion

    #region Method
    private void CreateTransaction()
    {
        if (CurrentTransaction is not null)
        {


            Close(true);
        }
    }
    #endregion
}