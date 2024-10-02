using BlazorGridStack;
using BlazorGridStack.Models;
using EmpiriaBMS.Front.Components.KPIS.Helper;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EmpiriaBMS.Front.Components.KPIS.Base;

public partial class KPIDashboard2
{
    BlazorGridStackBody Grid;

    private List<KPIGridItem> kpiCompoments = new();

    #region Only For Development
    int _widgetWidth = 4;
    int _widgetHeight = 3;

    private void _preloadKpisComps()
    {
        kpiCompoments.Add(new KPIGridItem
        {
            Id = 2354,
            ComponentType = typeof(DelayedPaymentsKpi),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 3465546,
                KPIGridItemId = 2354,
                X = 1 * _widgetWidth,
                Y = 1,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 2363546,
            ComponentType = typeof(DelayedProjectsKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 435673654,
                KPIGridItemId = 2363546,
                X = 2 * _widgetWidth,
                Y = 10,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 45645,
            ComponentType = typeof(DelayedProjectTypesKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 65546,
                KPIGridItemId = 45645,
                X = 3 * _widgetWidth,
                Y = 30,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 345654,
            ComponentType = typeof(HoursPerRoleKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 65546,
                KPIGridItemId = 345654,
                X = 4 * _widgetWidth,
                Y = 40,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 342654,
            ComponentType = typeof(HoursPerUserKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 36543,
                KPIGridItemId = 342654,
                X = 5 * _widgetWidth,
                Y = 50,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 32546,
            ComponentType = typeof(IssuesPerProjectCountKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 698769,
                KPIGridItemId = 32546,
                X = 6 * _widgetWidth,
                Y = 60,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 435677,
            ComponentType = typeof(IssuesPerUserCount),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 675688,
                KPIGridItemId = 435677,
                X = 7 * _widgetWidth,
                Y = 70,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 67589875,
            ComponentType = typeof(ProfitPerProjectKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 56786578,
                KPIGridItemId = 67589875,
                X = 8 * _widgetWidth,
                Y = 80,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 6478768,
            ComponentType = typeof(ProfitPerProjectTableKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 45367567,
                KPIGridItemId = 6478768,
                X = 9 * _widgetWidth,
                Y = 90,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 6786579,
            ComponentType = typeof(TenderTable),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 4675568,
                KPIGridItemId = 6786579,
                X = 10 * _widgetWidth,
                Y = 100,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 35476758,
            ComponentType = typeof(TurnoverPerEmployeeKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 9887679,
                KPIGridItemId = 35476758,
                X = 11 * _widgetWidth,
                Y = 110,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 587658,
            ComponentType = typeof(TurnoverPerProjectCategoryKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 3567458,
                KPIGridItemId = 587658,
                X = 12 * _widgetWidth,
                Y = 120,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 586678,
            ComponentType = typeof(TurnoverPerProjectManagerKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 45647867,
                KPIGridItemId = 586678,
                X = 13 * _widgetWidth,
                Y = 130,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        kpiCompoments.Add(new KPIGridItem
        {
            Id = 56765798,
            ComponentType = typeof(TurnoverPerProjectSubCategoryKPI),
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 43765765,
                KPIGridItemId = 56765798,
                X = 14 * _widgetWidth,
                Y = 140,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });
    }
    #endregion

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        _preloadKpisComps();
    }

}
