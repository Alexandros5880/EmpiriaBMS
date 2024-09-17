using EmpiriaBMS.Front.Components.General;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class EmployeeTurnoverKPI
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private bool _startLoading = true;

    private Dictionary<string, long> _employeesTurnover = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getEmployeesTurnover();

            StateHasChanged();
        }
    }

    private async Task _getEmployeesTurnover()
    {
        await Task.Delay(1000);

        // TODO: _getEmployeesTurnover()
        // _employeesTurnover = await _dataProvider.KPIS.GetEmployeesTurnover(StartDate?.Date, EndDate?.Date);
    }
}
