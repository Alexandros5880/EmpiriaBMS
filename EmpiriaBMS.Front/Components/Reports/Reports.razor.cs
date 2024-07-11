using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.BarChart.Axes;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Util;
using System.Drawing;
using ChartEnums = ChartJs.Blazor.Common.Enums;

namespace EmpiriaBMS.Front.Components.Reports;

public partial class Reports
{

    #region For Development
    private List<ReportEntry> reportEntries = new()
    {
        new ReportEntry { ProjectName = "General Services", Date = new DateTime(2024, 7, 24), Hours = 8 },
        new ReportEntry { ProjectName = "General Services", Date = new DateTime(2024, 7, 25), Hours = 9 },
        new ReportEntry { ProjectName = "General Services", Date = new DateTime(2024, 7, 26), Hours = 7 },
        new ReportEntry { ProjectName = "General Services", Date = new DateTime(2024, 7, 27), Hours = 6 }
    };

    public class ReportEntry
    {
        public string ProjectName { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
    }
    #endregion


    private BarConfig _barChartConfig;

    protected override void OnInitialized()
    {
        _barChartConfig = new BarConfig
        {
            Options = new BarOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Projects Profit",
                    Position = ChartEnums.Position.Left,
                    FontSize = 24
                },
                Scales = new BarScales
                {
                    XAxes = new List<CartesianAxis>
                    {
                        new BarCategoryAxis
                        {
                            Stacked = true,
                            Ticks = new CategoryTicks
                            {
                                FontColor = ColorUtil.FromDrawingColor(Color.FromArgb(255, 99, 132, 1)),
                            }
                        }
                    },
                    YAxes = new List<CartesianAxis>
                    {
                        new BarLinearCartesianAxis
                        {
                            Stacked = true,
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true
                            }
                        }
                    }
                },
                Responsive = true,
                AspectRatio = 3.5,
            }
        };

        // Labels (Dates for start date to end date per 1 week)
        List<string> dates = new List<string> { "Jul 24", "Jul 25", "Jul 26", "Jul 27" };
        foreach (var date in dates)
        {
            _barChartConfig.Data.Labels.Add(date);
        }

        // Dataset Labes are Projects.Client.CompanyName
        // Dataset Values are Client.Projects.Invoices.Payments.Sum
        var dataset1 = new BarDataset<int>(new List<int> { 10, 20, 30 })
        {
            Label = "dataset1",
            BackgroundColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(Color.LightSkyBlue)),
            BorderColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(Color.SkyBlue)),
            BorderWidth = 1
        };
        _barChartConfig.Data.Datasets.Add(dataset1);

        var dataset2 = new BarDataset<int>(new List<int> { 8, 9, 7, 6 })
        {
            Label = "dataset2",
            BackgroundColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(Color.LightSeaGreen)),
            BorderColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(Color.SeaGreen)),
            BorderWidth = 1
        };
        _barChartConfig.Data.Datasets.Add(dataset2);

    }

}
