using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using FinanceProject.Enum;
using FinanceProject.Pages;
using FinanceProject.Pages.Menu.Salary;
using FinanceProject.Transaction;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FinanceProject;

public partial class SalaryContext : BaseContext
{
    public SalaryContext()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    #region Properties
    public Window? MainWindow { get; set; }
    public string Token { get; set; }
    private string _totalSalary;
    public string TotalSalary
    {
        get => _totalSalary;
        set
        {
            _totalSalary = value;
            OnPropertyChanged();
        }
    }

    public SalaryContextViewModel SalaryContextViewModel;
    public ObservableCollection<TransactionFinance> Salaries { get; set; } = new();
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
        SalaryContextViewModel = new SalaryContextViewModel(Token);
        RefleshListSalary();
    }
    private async void OnEditClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.DataContext is TransactionFinance transaction)
        {
            if (MainWindow is not null)
            {
                TransactionOverlay dialog = new TransactionOverlay();
                dialog.TransactionType = EnumTransactionType.Entrada;
                dialog.CurrentTransaction = transaction;

                Border? overlay = MainWindow.FindControl<Border>("DarkOverlay");
                if (overlay is not null)
                    overlay.IsVisible = true;

                bool result = await dialog.ShowDialog<bool>(MainWindow);
                if(result)
                    _notificationManager.Show(new Notification("Sucesso", "Salário editado com sucesso.", NotificationType.Success));

                RefleshListSalary();

                if (overlay != null)
                    overlay.IsVisible = false;
            }
        }
    }
    private async void OnDeleteClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.DataContext is TransactionFinance transaction)
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
                    bool isDeleted = await SalaryContextViewModel.DeleteTransaction(transaction.Id);
                    if (isDeleted)
                    {
                        _notificationManager.Show(new Notification("Sucesso", "Salário deletado com sucesso.", NotificationType.Success));
                        RefleshListSalary();
                    }
                    else
                        _notificationManager.Show(new Notification("Erro ao deletar salário.", "Tente novamente.", NotificationType.Error));
                }

                if (overlay != null)
                    overlay.IsVisible = false;
            }
        }
    }
    private async void BtnNewSalary_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        if (MainWindow is not null)
        {
            TransactionOverlay dialog = new TransactionOverlay();
            dialog.TransactionType = EnumTransactionType.Entrada;

            Border? overlay = MainWindow.FindControl<Border>("DarkOverlay");
            if (overlay is not null)
                overlay.IsVisible = true;

            bool result = await dialog.ShowDialog<bool>(MainWindow);
            if (result)
                _notificationManager.Show(new Notification("Sucesso", "Salário criado com sucesso.", NotificationType.Success));

            RefleshListSalary();

            if (overlay != null)
                overlay.IsVisible = false;
        }
    }
    #endregion

    #region Methods
    private async void RefleshListSalary()
    {
        List<TransactionFinance>? listSalaries = await SalaryContextViewModel.LoadListSalary();
        if (listSalaries is not null)
        {
            double salary = 0;
            Salaries.Clear();
            foreach (TransactionFinance transactionFinance in listSalaries)
            {
                salary += transactionFinance.Amount;
                Salaries.Add(transactionFinance);
            }

            TotalSalary = $"R$ {salary}";
        }
    }
    #endregion
}