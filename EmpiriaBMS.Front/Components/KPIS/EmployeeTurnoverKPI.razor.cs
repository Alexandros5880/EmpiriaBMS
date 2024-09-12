using EmpiriaBMS.Front.Components.General;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class EmployeeTurnoverKPI
{
    private bool _startLoading = false;

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
        // _employeesTurnover = await _dataProvider.KPIS.GetEmployeesTurnover();
    }
}
