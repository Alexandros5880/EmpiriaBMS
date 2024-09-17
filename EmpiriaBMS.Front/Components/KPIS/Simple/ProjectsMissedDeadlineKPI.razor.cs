using EmpiriaBMS.Front.Interop.TeamsSDK;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.KPIS.Simple;

public partial class ProjectsMissedDeadlineKPI
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private decimal _missedDeadLineProject = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await MicrosoftTeams.InitializeTooltips();
            await _getMissedDeadLineProjects();
            StateHasChanged();
        }
    }

    private async Task _getMissedDeadLineProjects()
    {
        _missedDeadLineProject = await _dataProvider.KPIS.GetMissedDeadLineProjects(StartDate?.Date, EndDate?.Date);
    }

}
