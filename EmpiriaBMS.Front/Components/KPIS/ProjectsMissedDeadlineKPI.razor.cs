namespace EmpiriaBMS.Front.Components.KPIS;

public partial class ProjectsMissedDeadlineKPI
{

    private decimal _missedDeadLineProject = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getMissedDeadLineProjects();
            StateHasChanged();
        }
    }

    private async Task _getMissedDeadLineProjects()
    {
        _missedDeadLineProject = await _dataProvider.KPIS.GetMissedDeadLineProjects();
    }

}
