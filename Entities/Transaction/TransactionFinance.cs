using FinanceProject.Enum;

namespace FinanceProject.Transaction;

public class TransactionFinance
{
    public long Id { get; set; }
    public double Amount { get; set; }
    public string Description { get; set; }
    public EnumCategoryTransaction Category { get; set; }
    public EnumTransactionType Type { get; set; } 
    public string Date { get; set; }
}