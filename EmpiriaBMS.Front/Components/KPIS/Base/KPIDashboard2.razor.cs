using BlazorDateRangePicker;
using BlazorGridStack;
using BlazorGridStack.Models;
using EmpiriaBMS.Front.Components.KPIS.Contract;
using EmpiriaBMS.Front.Components.KPIS.Helper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Fast.Components.FluentUI.DesignTokens;
using NuGet.Packaging.Core;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace EmpiriaBMS.Front.Components.KPIS.Base;

public partial class KPIDashboard2
{
    #region Only for development
    int _widgetWidth = 4;
    int _widgetHeight = 4;

    private List<KPIGridItem> _loadSeedDbData(int id = 0)
    {
        List<KPIGridItem> dbCollection = new List<KPIGridItem>();

        dbCollection.Add(new KPIGridItem
        {
            Id = 2354,
            ComponentType = typeof(DelayedPaymentsKpi),
            Name = "DelayedPaymentsKpi",
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

        dbCollection.Add(new KPIGridItem
        {
            Id = 2363546,
            ComponentType = typeof(DelayedProjectsKPI),
            Name = "DelayedProjectsKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 435673654,
                KPIGridItemId = 2363546,
                X = 2 * _widgetWidth,
                Y = 1,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 45645,
            ComponentType = typeof(DelayedProjectTypesKPI),
            Name = "DelayedProjectTypesKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 65546,
                KPIGridItemId = 45645,
                X = 3 * _widgetWidth,
                Y = 1,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 345654,
            ComponentType = typeof(HoursPerRoleKPI),
            Name = "HoursPerRoleKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 65546,
                KPIGridItemId = 345654,
                X = 4 * _widgetWidth,
                Y = 5,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 342654,
            ComponentType = typeof(HoursPerUserKPI),
            Name = "HoursPerUserKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 36543,
                KPIGridItemId = 342654,
                X = 5 * _widgetWidth,
                Y = 5,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 32546,
            ComponentType = typeof(IssuesPerProjectCountKPI),
            Name = "IssuesPerProjectCountKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 698769,
                KPIGridItemId = 32546,
                X = 6 * _widgetWidth,
                Y = 5,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 435677,
            ComponentType = typeof(IssuesPerUserCount),
            Name = "IssuesPerUserCount",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 675688,
                KPIGridItemId = 435677,
                X = 7 * _widgetWidth,
                Y = 9,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 67589875,
            ComponentType = typeof(ProfitPerProjectKPI),
            Name = "ProfitPerProjectKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 56786578,
                KPIGridItemId = 67589875,
                X = 8 * _widgetWidth,
                Y = 9,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 6478768,
            ComponentType = typeof(ProfitPerProjectTableKPI),
            Name = "ProfitPerProjectTableKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 45367567,
                KPIGridItemId = 6478768,
                X = 9 * _widgetWidth,
                Y = 9,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 6786579,
            ComponentType = typeof(TenderTable),
            Name = "TenderTable",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 4675568,
                KPIGridItemId = 6786579,
                X = 10 * _widgetWidth,
                Y = 13,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 35476758,
            ComponentType = typeof(TurnoverPerEmployeeKPI),
            Name = "TurnoverPerEmployeeKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 9887679,
                KPIGridItemId = 35476758,
                X = 11 * _widgetWidth,
                Y = 13,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 587658,
            ComponentType = typeof(TurnoverPerProjectCategoryKPI),
            Name = "TurnoverPerProjectCategoryKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 3567458,
                KPIGridItemId = 587658,
                X = 12 * _widgetWidth,
                Y = 13,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 586678,
            ComponentType = typeof(TurnoverPerProjectManagerKPI),
            Name = "TurnoverPerProjectManagerKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 45647867,
                KPIGridItemId = 586678,
                X = 13 * _widgetWidth,
                Y = 18,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        dbCollection.Add(new KPIGridItem
        {
            Id = 56765798,
            ComponentType = typeof(TurnoverPerProjectSubCategoryKPI),
            Name = "TurnoverPerProjectSubCategoryKPI",
            IsSelected = true,
            Position = new KPIGridItemPosition()
            {
                Id = 43765765,
                KPIGridItemId = 56765798,
                X = 14 * _widgetWidth,
                Y = 18,
                W = _widgetWidth,
                H = _widgetHeight
            }
        });

        if (id != 0)
            return dbCollection.Where(r => r.Id == id).ToList();

        return dbCollection;
    }
    #endregion


    BlazorGridStackBody Grid;

    private ObservableCollection<KPIGridItem> kpiCompoments = new();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await _getKPIS();

        kpiCompoments.CollectionChanged += _onlistChange;
    }

    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    await base.OnAfterRenderAsync(firstRender);

    //    if (firstRender)
    //    {
    //        await RefreshGridAsync();
    //    }
    //}

    private Task _getKPIS(List<KPIGridItem> list = null)
    {
        var dto = _loadSeedDbData();
        kpiCompoments.Clear();

        foreach(var item in dto)
        {
            if (list != null && list.Select(i => i.Id).Contains(item.Id))
            {
                var updated = list.FirstOrDefault(i => i.Id == item.Id);
                item.IsSelected = updated.IsSelected;
            }
            kpiCompoments.Add(item);
        }

        return Task.Delay(100);
    }

    private async Task RefreshGridAsync()
    {
        Grid?.RemoveAll();

        await Task.Delay(50);

        foreach (var component in kpiCompoments.Where(kpi => kpi.IsSelected))
        {
            Grid?.AddWidget(new BlazorGridStackWidgetOptions
            {
                X = component.Position.X,
                Y = component.Position.Y,
                W = component.Position.W,
                H = component.Position.H
            });

            Grid?.Movable(component.Id.ToString(), true);
            Grid?.Resizable(component.Id.ToString(), true);
        }

        Grid?.BatchUpdate();
    }

    private async void _onlistChange(object? sender, NotifyCollectionChangedEventArgs e)
    {
        var updated = e.NewItems.Cast<KPIGridItem>().ToList();

        await _getKPIS(updated);

        //await RefreshGridAsync();

        Grid?.BatchUpdate();

        foreach (var i in kpiCompoments)
        {
            Grid?.Movable(i.Id.ToString(), true);
            Grid?.Resizable(i.Id.ToString(), true);
        }

        StateHasChanged();
    }

    private Task _onUIChanged(BlazorGridStackWidgetEventArgs e)
    {
        if (e == null)
            return Task.CompletedTask;

        var item = e.Item;
        Logger.LogInformation($"\n\nWidget Item[{item.Id}] {item.ClassName}. New width: {item.W}, New height: {item.H}, New X: {item.X}, New Y: {item.Y}.\n\n");

        return Task.CompletedTask;
    }

    #region Date Range Filter
    DateTimeOffset? StartDate { get; set; } = new DateTimeOffset(DateTime.Parse("8-1-2023"));
    DateTimeOffset? EndDate { get; set; } = new DateTimeOffset(DateTime.Parse("10-1-2024"));

    public Task OnDateSelect(DateRange range)
    {
        if (StartDate.HasValue && EndDate.HasValue)
        {
            StartDate = range.Start;
            EndDate = range.End;
            Grid.BatchUpdate();
            //StateHasChanged();
        }

        return Task.CompletedTask;
    }
    #endregion
}
