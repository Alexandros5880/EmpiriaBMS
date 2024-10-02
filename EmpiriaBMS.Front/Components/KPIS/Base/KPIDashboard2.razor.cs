using EmpiriaBMS.Front.Components.KPIS.Helper;

namespace EmpiriaBMS.Front.Components.KPIS.Base;

public partial class KPIDashboard2
{
    private List<DashboardComponent> components = new();

    private void _addNewComponents()
    {
        components.Add(new DashboardComponent
        {
            Id = "1",
            ComponentType = typeof(ProfitPerProjectKPI),
        });

        components.Add(new DashboardComponent
        {
            Id = "2",
            ComponentType = typeof(PandingPaymentsKPI),
        });
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await MicrosoftTeams.InitializeDragAndDrop("dashboard-grid");
        }
    }
}
