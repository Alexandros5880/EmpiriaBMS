using BlazorGridStack;
using BlazorGridStack.Models;
using EmpiriaBMS.Front.Components.KPIS.Helper;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EmpiriaBMS.Front.Components.KPIS.Base;

public partial class KPIDashboard2
{
    BlazorGridStackBody Grid;

    private List<KPIGridItem> kpiCompoments = new();

    int _widgetWidth = 2;
    int _widgetHeight = 2;

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
                X = 1,
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
                X = 10,
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
                X = 30,
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
                X = 40,
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
                X = 50,
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
                X = 60,
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
                X = 70,
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
                X = 80,
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
                X = 90,
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
                X = 100,
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
                X = 110,
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
                X = 120,
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
                X = 130,
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
                X = 140,
                Y = 140,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        _preloadKpisComps();
    }

}
