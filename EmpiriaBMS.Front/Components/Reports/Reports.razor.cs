using ChartJs.Blazor.BarChart;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Util;

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
                Responsive = true,
                MaintainAspectRatio = false,
                Scales = new BarScales
                {
                    YAxes = new List<CartesianAxis>
                    {
                        new LinearCartesianAxis
                        {
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true
                            }
                        }
                    }
                }
            }
        };

        // Using IndexableOption<string> instead of List<string>
        List<string> dates = new List<string> { "Jul 24", "Jul 25", "Jul 26", "Jul 27" };
        foreach (var date in dates)
        {
            _barChartConfig.Data.Labels.Add(date);
        }

        var dataset = new BarDataset<int>(new List<int> { 8, 9, 7, 6 })
        {
            Label = "Hours Worked",
            BackgroundColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(System.Drawing.Color.LightSkyBlue)),
            BorderColor = new IndexableOption<string>(ColorUtil.FromDrawingColor(System.Drawing.Color.Blue)),
            BorderWidth = 1
        };

        _barChartConfig.Data.Datasets.Add(dataset);
    }

}
