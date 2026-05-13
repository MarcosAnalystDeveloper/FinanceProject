using Avalonia.Controls;
using Avalonia.Interactivity;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using ScottPlot;
using ScottPlot.Avalonia;
using System.Collections.Generic;

namespace FinanceProject;

public partial class HomeContext : UserControl
{
    public ISeries[] Series { get; set; } = new ISeries[]
    {
        new LineSeries<double>
        {
            Values = new double[] { 2,1,3,5,3,4,6},
            Fill = null
        }
    };

    public HomeContext()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (Design.IsDesignMode)
            return;

        ConfigurarGraficoLinha();
        //ConfigurarGraficoPizza();
    }

    private void ConfigurarGraficoLinha()
    {
        var plot = this.FindControl<AvaPlot>("PlotLinha");
        if (plot == null) return;

        double[] dataY = { 10, 15, 12, 18, 20 };
        plot.Plot.Add.Signal(dataY);

        // Cores e Estilo
        plot.Plot.FigureBackground.Color = Color.FromHex("#1F222C");
        plot.Plot.DataBackground.Color = Color.FromHex("#1F222C");
        plot.Plot.Axes.Color(Color.FromHex("#FFFFFF"));

        plot.Refresh();
    }

    private void ConfigurarGraficoPizza()
    {
        var plot = this.FindControl<AvaPlot>("PlotPizza");
        if (plot == null) return;

        List<PieSlice> slices = new()
        {
            new() { Value = 40, Fill = new FillStyle { Color = Color.FromHex("#7FD9F9") }, Label = "Salário" },
            new() { Value = 60, Fill = new FillStyle { Color = Color.FromHex("#F87171") }, Label = "Despesas" },
        };

        var pie = plot.Plot.Add.Pie(slices);
        pie.DonutFraction = 0.5; // Deixa com cara de gráfico de rosca (opcional)

        plot.Plot.FigureBackground.Color = Color.FromHex("#1F222C");
        plot.Plot.Axes.Frameless();
        plot.Plot.HideGrid();

        plot.Refresh();
    }
}