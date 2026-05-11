using Avalonia.Controls;
using Avalonia.Interactivity;
using FinanceProject.Pages;
using FinanceProject.Pages.Menu.Salary;
using FinanceProject.Transaction;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace FinanceProject;

public partial class SalaryContext : BaseContext
{
    public SalaryContext()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    #region Properties
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

        SalaryContextViewModel = new SalaryContextViewModel(Token);
        RefleshListSalary();
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
    private async void OnEditClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.DataContext is TransactionFinance transaction)
        {
            //Fazer lógica para editar um Salário apos implementação do Back-End.
        }
    }

    private async void OnDeleteClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.DataContext is TransactionFinance transaction)
        {
            bool isDeleted = await SalaryContextViewModel.DeleteTransaction(transaction.Id);
            if (isDeleted)
                RefleshListSalary();
        }
    }
    #endregion
}