using FinanceProject.Enum;
using System.Text.Json.Serialization;

namespace FinanceProject.Entities;

public class SummaryFinance
{
    [JsonPropertyName("total_entradas")]
    public double TotalSalarys { get; set; }

    [JsonPropertyName("total_saidas")]
    public double TotalExpanses { get; set; }

    [JsonPropertyName("saldo_atual")]
    public double CurrentBalance { get; set; }

    [JsonPropertyName("status_financeiro")]
    public EnumFinanceStatus Status { get; set; }
}