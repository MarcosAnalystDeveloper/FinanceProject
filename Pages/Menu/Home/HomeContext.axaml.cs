using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Styling;
using FinanceProject.Entities;
using FinanceProject.Enum;
using FinanceProject.Pages;
using FinanceProject.Pages.Menu.Home;
using FinanceProject.Transaction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    private string _percentageSalary;
    public string PercentageSalary
    {
        get => _percentageSalary;
        set
        {
            _percentageSalary = value;
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
        LoadPhotoUser();
    }
    private async Task LoadData()
    {
        SummaryFinance? summaryResult = await HomeContextViewModel.GetSummary();
        if (summaryResult is not null)
        {
            BalanceTotal = $"R$ {summaryResult.CurrentBalance}";

            double salary = double.Parse(HigherSalary.Replace("R$", "").Trim());
            double expense = double.Parse(HigherExpense.Replace("R$", "").Trim());
            PercentageSalary = $"▲ {((salary / summaryResult.TotalSalarys) * 100):F2}%";
            PercentageExpanse = $"▼ {((expense / summaryResult.TotalExpanses) * 100):F2}%";
        }
    }
    private async Task InitializeListTransaction()
    {
        List<TransactionFinance>? listResult = await HomeContextViewModel.LoadListTransactions();
        if (listResult is not null)
        {
            ListTransaction.Clear();
            List<TransactionItemMenu> listTransactions = (from i in listResult select new TransactionItemMenu(i)).ToList();
            foreach (TransactionItemMenu item in listTransactions.OrderByDescending(t => t.Date).ToList())
                ListTransaction.Add(item);

            double higherSalary = listResult.Where(i => i.Type == EnumTransactionType.Entrada).Max(i => i.Amount);
            double higherExpense = listResult.Where(i => i.Type == EnumTransactionType.Saida).Max(i => i.Amount);

            HigherSalary = $"R$ {higherSalary}";
            HigherExpense = $"R$ {higherExpense}";
        }
    }
    public void LoadPhotoUser()
    {
        Stream? assets = default;
        string uri = "avares://FinanceProject/Assets/defaulPhotoUser.jpg";

        //if (!string.IsNullOrEmpty(CurrentProfile.ProfilePicture))
        //{
        //    assets = AssetLoader.Open(new Uri(CurrentProfile.ProfilePicture)) ?? default;
        //    if (assets is not null)
        //        PhotoUser = new Bitmap(assets);
        //    else 
        //    {
        assets = AssetLoader.Open(new Uri(uri));
        PhotoUser = new Bitmap(assets);
        //    }
        //}
    }
    #endregion
}

public class TransactionItemMenu : INotifyPropertyChanged
{
    public TransactionItemMenu(TransactionFinance transactionFinance)
    {
        switch (transactionFinance.Category)
        {
            case EnumCategoryTransaction.Moradia:
                IconItem = GetIconTemplate("home");
                break;
            case EnumCategoryTransaction.Alimentação:
                IconItem = GetIconTemplate("food");
                break;
            case EnumCategoryTransaction.Transporte:
                IconItem = GetIconTemplate("transport");
                break;
            case EnumCategoryTransaction.Renda:
                IconItem = GetIconTemplate("savings");
                break;
            case EnumCategoryTransaction.Lazer:
                IconItem = GetIconTemplate("leisure");
                break;
        }

        Title = transactionFinance.Category.ToString();

        DateTime dateInverted = DateTime.Parse(transactionFinance.Date);
        Date = dateInverted;
        string date = dateInverted.ToString("MMM dd, hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
        Description = $"{transactionFinance.Description} • {date}";

        string valorPositivo = Math.Abs(transactionFinance.Amount).ToString("N2");
        string sinal = transactionFinance.Type == EnumTransactionType.Saida ? "-" : "+";
        Value = $"{sinal} R$ {valorPositivo}";

        switch (sinal)
        {
            case "-":
                BacgroundValue = Brush.Parse("#EE5D50");
                break;
            case "+":
                BacgroundValue = Brush.Parse("#05CD99");
                break;
        }
    }

    #region Interface
    public new event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    #endregion

    #region Properties

    private DateTime _date;
    public DateTime Date
    {
        get => _date;
        set
        {
            _date = value;
            OnPropertyChanged();
        }
    }
    private StreamGeometry? _iconItem;
    public StreamGeometry? IconItem
    {
        get => _iconItem;
        set
        {
            _iconItem = value;
            OnPropertyChanged();
        }
    }

    private string _title;
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged();
        }
    }

    private string _value;
    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged();
        }
    }

    #region Colors

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

    #endregion

    #endregion

    #region Methods
    private StreamGeometry? GetIconTemplate(string icon)
    {
        if (!string.IsNullOrEmpty(icon))
        {
            if (Application.Current!.TryFindResource(icon, ThemeVariant.Default, out var result))
            {
                if (result is StreamGeometry themeIcon)
                    return themeIcon;
            }
        }

        return null;
    }
    #endregion
}