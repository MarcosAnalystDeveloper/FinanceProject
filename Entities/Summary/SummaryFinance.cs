using FinanceProject.Enum;

namespace FinanceProject.Entities;

public class SummaryFinance
{
    public double TotalSalarys { get; set; }
    public double TotalExpanses { get; set; }
    public double CurrentBalance { get; set; }
    public EnumFinanceStatus Status { get; set; }
}