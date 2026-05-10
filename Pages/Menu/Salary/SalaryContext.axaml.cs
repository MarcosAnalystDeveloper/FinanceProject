using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using FinanceProject.Enum;
using FinanceProject.Transaction;
using System.Collections.ObjectModel;

namespace FinanceProject;

public partial class SalaryContext : UserControl
{
    public SalaryContext()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    public ObservableCollection<TransactionFinance> Salaries { get; set; } = new()
    {
        new TransactionFinance() { Id = 1, Type = EnumTransactionType.Entrada, Date = "10/05/2026",
         Amount = 2500, Category = EnumCategoryTransaction.Renda, Description = "salario atual"}
    };
}