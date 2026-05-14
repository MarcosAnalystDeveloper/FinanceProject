using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using FinanceProject.Elements;
using FinanceProject.Enum;
using FinanceProject.Pages;
using FinanceProject.Pages.Menu.Expense;
using FinanceProject.Transaction;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FinanceProject;

public partial class ExpenseContext : BaseContext
{
    public ExpenseContext()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    #region Properties
    public Window? MainWindow { get; set; }
    public string Token { get; set; }
    private string _totalExpense;
    public string TotalExpense
    {
        get => _totalExpense;
        set
        {
            _totalExpense = value;
            OnPropertyChanged();
        }
    }

    public ExpenseContextViewModel ExpenseContextViewModel;
    public ObservableCollection<TransactionFinance> Expenses { get; set; } = new();
    #endregion

    #region Events
    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (Design.IsDesignMode)
            return;

        MainWindow = this.GetVisualAncestors().FirstOrDefault(x => x is Window) as Window;
        if (MainWindow is not null)
        {
            _notificationManager = new WindowNotificationManager(MainWindow)
            {
                Position = NotificationPosition.TopRight,
                MaxItems = 2
            };
        }

        ExpenseContextViewModel = new ExpenseContextViewModel(Token);
        RefleshListExpense();
    }
    private async void OnEdit_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        if (sender is ButtonElement btn && btn.Parent!.DataContext is TransactionFinance transaction)
        {
            if (MainWindow is not null)
            {
                TransactionOverlay dialog = new TransactionOverlay();
                dialog.TransactionType = EnumTransactionType.Saida;
                dialog.CurrentTransaction = transaction;
                dialog.Token = Token;

                Border? overlay = MainWindow.FindControl<Border>("DarkOverlay");
                if (overlay is not null)
                    overlay.IsVisible = true;

                bool result = await dialog.ShowDialog<bool>(MainWindow);
                if (result)
                    _notificationManager.Show(new Notification("Sucesso", "Dispesa editada com sucesso.", NotificationType.Success));

                RefleshListExpense();

                if (overlay != null)
                    overlay.IsVisible = false;
            }
        }
    }
    private async void OnDelete_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        if (sender is ButtonElement btn && btn.Parent!.DataContext is TransactionFinance transaction)
        {
            if (MainWindow is not null)
            {
                PrincipalOverlay dialog = new PrincipalOverlay();
                Border? overlay = MainWindow.FindControl<Border>("DarkOverlay");
                if (overlay is not null)
                    overlay.IsVisible = true;

                bool result = await dialog.ShowDialog<bool>(MainWindow);
                if (result)
                {
                    bool isDeleted = await ExpenseContextViewModel.DeleteTransaction(transaction.Id);
                    if (isDeleted)
                    {
                        _notificationManager.Show(new Notification("Sucesso", "Dispesa deletado com sucesso.", NotificationType.Success));
                        RefleshListExpense();
                    }
                    else
                        _notificationManager.Show(new Notification("Erro ao deletar dispesa.", "Tente novamente.", NotificationType.Error));
                }

                if (overlay != null)
                    overlay.IsVisible = false;
            }
        }
    }
    private async void BtnNewExpense_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        if (MainWindow is not null)
        {
            TransactionOverlay dialog = new TransactionOverlay();
            dialog.TransactionType = EnumTransactionType.Saida;
            dialog.Token = Token;

            Border? overlay = MainWindow.FindControl<Border>("DarkOverlay");
            if (overlay is not null)
                overlay.IsVisible = true;

            bool result = await dialog.ShowDialog<bool>(MainWindow);
            if (result)
                _notificationManager.Show(new Notification("Sucesso", "Dispesa criada com sucesso.", NotificationType.Success));

            RefleshListExpense();

            if (overlay != null)
                overlay.IsVisible = false;
        }
    }
    #endregion

    #region Methods
    private async void RefleshListExpense()
    {
        List<TransactionFinance>? listExpenses = await ExpenseContextViewModel.LoadListExpense();
        if (listExpenses is not null)
        {
            double expense = 0;
            Expenses.Clear();
            foreach (TransactionFinance transactionFinance in listExpenses)
            {
                expense += transactionFinance.Amount;
                Expenses.Add(transactionFinance);
            }

            TotalExpense = $"R$ {expense}";
        }
    }
    #endregion
}