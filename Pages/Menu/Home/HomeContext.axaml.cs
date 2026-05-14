using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using FinanceProject.Entities;
using FinanceProject.Enum;
using FinanceProject.Pages;
using FinanceProject.Pages.Menu.Home;
using FinanceProject.Pages.Menu.Salary;
using FinanceProject.Transaction;
using LiveChartsCore.Geo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FinanceProject;

public partial class HomeContext : BaseContext
{
    public HomeContext()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    #region Properties
    public string Token { get; set; }
    public UserFinance CurrentProfile { get; set; }
    public HomeContextViewModel HomeContextViewModel;
    public ObservableCollection<TransactionItemMenu> ListTransaction { get; set; } = new();

    private Bitmap _photoUser;
    public Bitmap PhotoUser
    {
        get => _photoUser;
        set
        {
            _photoUser = value;
            OnPropertyChanged();
        }
    }

    private string _balanceTotal;
    public string BalanceTotal
    {
        get => _balanceTotal;
        set
        {
            _balanceTotal = value;
            OnPropertyChanged();
        }
    }

    private string _salaryTotal;
    public string SalaryTotal
    {
        get => _salaryTotal;
        set
        {
            _salaryTotal = value;
            OnPropertyChanged();
        }
    }

    private string _expanseTotal;
    public string ExpenseTotal
    {
        get => _expanseTotal;
        set
        {
            _expanseTotal = value;
            OnPropertyChanged();
        }
    }

    private string _percentageExpanse;
    public string PercentageExpanse
    {
        get => _percentageExpanse;
        set
        {
            _percentageExpanse = value;
            OnPropertyChanged();
        }
    }

    private string _higherSalary;
    public string HigherSalary
    {
        get => _higherSalary;
        set
        {
            _higherSalary = value;
            OnPropertyChanged();
        }
    }

    private string _higherExpanse;
    public string HigherExpense
    {
        get => _higherExpanse;
        set
        {
            _higherExpanse = value;
            OnPropertyChanged();
        }
    }

    private IBrush _bacgroundSalaryTotal;
    public IBrush BacgroundSalaryTotal
    {
        get => _bacgroundSalaryTotal;
        set
        {
            _bacgroundSalaryTotal = value;
            OnPropertyChanged();
        }
    }

    private IBrush _bacgroundProcessBar;
    public IBrush BacgroundProcessBar
    {
        get => _bacgroundProcessBar;
        set
        {
            _bacgroundProcessBar = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region Events
    protected async override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (Design.IsDesignMode)
            return;

        HomeContextViewModel = new HomeContextViewModel(Token);
        await InitializeHomeContext();
    }
    #endregion

    #region Methods
    private async Task InitializeHomeContext()
    {
        await InitializeListTransaction();
        await LoadData();
        await InitializePhotoUser();
    }
    private async Task LoadData()
    {
        SummaryFinance? summaryResult = await HomeContextViewModel.GetSummary();
        if (summaryResult is not null)
        {
            BalanceTotal = $"R$ {summaryResult.CurrentBalance}";
        }
    }
    private async Task InitializeListTransaction()
    {
        List<TransactionFinance>? listResult = await HomeContextViewModel.LoadListTransactions();
        if (listResult is not null)
        {
            ListTransaction.Clear();
            List<TransactionItemMenu> listTransactions = (from i in listResult select new TransactionItemMenu(i)).ToList();
            foreach (TransactionItemMenu item in listTransactions.OrderByDescending(t => t.TransactionDate).ToList())
                ListTransaction.Add(item);

            double higherSalary = listResult.Where(i => i.Type == EnumTransactionType.Entrada).Max(i => i.Amount);
            double higherExpense = listResult.Where(i => i.Type == EnumTransactionType.Saida).Max(i => i.Amount);

            HigherSalary = $"R$ {higherSalary}";
            HigherExpense = $"R$ {higherExpense}";
        }
    }
    private async Task InitializePhotoUser() 
    {
        LoadPhotoUser(default!);
    }
    public void LoadPhotoUser(string uri = "avares://FinanceProject/Assets/defaulPhotoUser.jpg")
    {
        var assets = AssetLoader.Open(new Uri(uri));
        PhotoUser = new Bitmap(assets);
    }
    #endregion
}

public class TransactionItemMenu : INotifyPropertyChanged
{
    public TransactionItemMenu(TransactionFinance transactionFinance)
    {

    }

    #region Interface
    public new event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    #endregion

    #region Properties
    private StreamGeometry _iconItem;
    public StreamGeometry IconItem
    {
        get => _iconItem;
        set
        {
            _iconItem = value;
            OnPropertyChanged();
        }
    }

    private IBrush _bacgroundValue;
    public IBrush BacgroundValue
    {
        get => _bacgroundValue;
        set
        {
            _bacgroundValue = value;
            OnPropertyChanged();
        }
    }

    private DateTime _transactionDate;
    public DateTime TransactionDate
    {
        get => _transactionDate;
        set
        {
            _transactionDate = value;
            OnPropertyChanged();
        }
    }

    private EnumCategoryTransaction _category;
    public EnumCategoryTransaction Category
    {
        get => _category;
        set
        {
            _category = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Methods

    #endregion
}