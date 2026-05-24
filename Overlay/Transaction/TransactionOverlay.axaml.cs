using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using FinanceProject.Enum;
using FinanceProject.Overlay.Transaction;
using FinanceProject.Transaction;
using System.Linq;

namespace FinanceProject;

public partial class TransactionOverlay : BasePage
{
    #region Properties
    public TransactionOverlayViewModel TransactionOverlayViewModel;
    public EnumTransactionType TransactionType { get; set; }
    public string Token { get; set; }
    public string ButtonTextAddOrUpdate { get; set; } = string.Empty;
    public TransactionFinance? CurrentTransaction;

    private EnumCategoryTransaction _category;
    public EnumCategoryTransaction Category
    {
        get => _category;
        set
        {
            if (_category != value)
            {
                _category = value;
                OnPropertyChanged();
            }
        }
    }

    private double _amount;
    public double Amount
    {
        get => _amount;
        set
        {
            if (_amount != value)
            {
                _amount = value;
                OnPropertyChanged();
            }
        }
    }

    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }

    private string _textButtonConfirm;
    public string TextButtonConfirm
    {
        get => _textButtonConfirm;
        set
        {
            if (_textButtonConfirm != value)
            {
                _textButtonConfirm = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion

    public TransactionOverlay()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    #region Events
    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (Design.IsDesignMode)
            return;

        TransactionOverlayViewModel = new TransactionOverlayViewModel(Token);
        _notificationManager = new WindowNotificationManager(this)
        {
            Position = NotificationPosition.TopRight,
            MaxItems = 2
        };

        InitializeComboBox();
        InitializeTransaction();
    }
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        if (Design.IsDesignMode)
            return;

        btnCancel.PointerPressed += BtnCancel_PointerPressed;
        btnNewOrUpdate.PointerPressed += BtnConfirm_PointerPressed;
    }
    private void BtnConfirm_PointerPressed(object? sender, Avalonia.Interactivity.RoutedEventArgs e) { CreateTransaction(); }
    private void BtnCancel_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e) { Close(false); }
    #endregion

    #region Method
    private async void CreateTransaction()
    {
        string verb = TransactionType == EnumTransactionType.Entrada ? "salário" : "despesa";
        if (CurrentTransaction is not null)
        {
            bool result = await TransactionOverlayViewModel.EditedTransaction(CurrentTransaction.Id, Description, Amount, TransactionType.ToString().ToLower(), Category.ToString().ToLower());
            if (!result)
                _notificationManager.Show(new Notification($"Erro editar {verb}.", "Revise os campos e tente novamente.", NotificationType.Warning));
            else
                Close(true);
        }
        else
        {
            bool result = await TransactionOverlayViewModel.CreateTransaction(Description, Amount, TransactionType.ToString().ToLower(), Category.ToString().ToLower());
            if (!result)
                _notificationManager.Show(new Notification($"Erro criar {verb}.", "Revise os campos e tente novamente.", NotificationType.Warning));
            else
                Close(true);
        }
    }
    private void InitializeComboBox()
    {
        var lista = EnumCategoryTransaction.GetValues(typeof(EnumCategoryTransaction)).Cast<EnumCategoryTransaction>().ToList();
        comboBox.ItemsSource = lista;
    }
    private void InitializeTransaction()
    {
        if (CurrentTransaction is not null)
        {
            Amount = CurrentTransaction.Amount;
            Category = CurrentTransaction.Category;
            Description = CurrentTransaction.Description;
        }
    }
    #endregion
}