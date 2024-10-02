using EmpiriaBMS.Front.Components.KPIS.Helper;
using Microsoft.JSInterop;

namespace EmpiriaBMS.Front.Components.KPIS.Base;

public partial class KPIDashboard2
{
    private List<KPIGridItem> preLoadCompoments = new();
    private List<KPIGridItem> displayedCompoments = new();

    private void _preloadKpisComps()
    {
        preLoadCompoments.Add(new KPIGridItem
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
                W = 500,
                H = 500
            }
        });

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 2363546,
        //    ComponentType = typeof(DelayedProjectsKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 435673654,
        //        KPIGridItemId = 2363546,
        //        X = 10,
        //        Y = 10,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 45645,
        //    ComponentType = typeof(DelayedProjectTypesKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 65546,
        //        KPIGridItemId = 45645,
        //        X = 30,
        //        Y = 30,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 345654,
        //    ComponentType = typeof(HoursPerRoleKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 65546,
        //        KPIGridItemId = 345654,
        //        X = 40,
        //        Y = 40,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 342654,
        //    ComponentType = typeof(HoursPerUserKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 36543,
        //        KPIGridItemId = 342654,
        //        X = 50,
        //        Y = 50,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 32546,
        //    ComponentType = typeof(IssuesPerProjectCountKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 698769,
        //        KPIGridItemId = 32546,
        //        X = 60,
        //        Y = 60,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 435677,
        //    ComponentType = typeof(IssuesPerUserCount),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 675688,
        //        KPIGridItemId = 435677,
        //        X = 70,
        //        Y = 70,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 67589875,
        //    ComponentType = typeof(ProfitPerProjectKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 56786578,
        //        KPIGridItemId = 67589875,
        //        X = 80,
        //        Y = 80,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 6478768,
        //    ComponentType = typeof(ProfitPerProjectTableKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 45367567,
        //        KPIGridItemId = 6478768,
        //        X = 90,
        //        Y = 90,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 6786579,
        //    ComponentType = typeof(TenderTable),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 4675568,
        //        KPIGridItemId = 6786579,
        //        X = 100,
        //        Y = 100,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 35476758,
        //    ComponentType = typeof(TurnoverPerEmployeeKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 9887679,
        //        KPIGridItemId = 35476758,
        //        X = 110,
        //        Y = 110,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 587658,
        //    ComponentType = typeof(TurnoverPerProjectCategoryKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 3567458,
        //        KPIGridItemId = 587658,
        //        X = 120,
        //        Y = 120,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 586678,
        //    ComponentType = typeof(TurnoverPerProjectManagerKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 45647867,
        //        KPIGridItemId = 586678,
        //        X = 130,
        //        Y = 130,
        //        W = 500,
        //        H = 500
        //    }
        //});

        //preLoadCompoments.Add(new KPIGridItem
        //{
        //    Id = 56765798,
        //    ComponentType = typeof(TurnoverPerProjectSubCategoryKPI),
        //    IsSelected = true,
        //    Position = new KPIGridItemPosition()
        //    {
        //        Id = 43765765,
        //        KPIGridItemId = 56765798,
        //        X = 140,
        //        Y = 140,
        //        W = 500,
        //        H = 500
        //    }
        //});
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await MicrosoftTeams.InitializeGridStack();

            _preloadKpisComps();

            _addNextCompoment();
        }
    }

    private void _addNextCompoment()
    {
        foreach (var comp in preLoadCompoments)
        {
            if (!displayedCompoments.Select(c => c.Id).Contains(comp.Id))
            {
                displayedCompoments.Add(comp);
                //break;
            } 
        }
        StateHasChanged();
    }

    [JSInvokable]
    public static Task SaveLayout(List<GridItem> layout)
    {
        foreach(var l in layout)
        {
            // Get Display KPI Item From DB Of Type DashboardComponent
            //var item = displayedCompoments.FirstOrDefault(i => i.Id == l.Id);

            // Update Position
            //item.Position = l.Position;

            // Save To Database
        }

        // Save the layout to the database or local storage
        return Task.CompletedTask;
    }
}
