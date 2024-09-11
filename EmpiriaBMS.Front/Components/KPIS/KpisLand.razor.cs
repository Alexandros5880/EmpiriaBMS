using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class KpisLand : ComponentBase
{

    #region Authorization Properties
    bool SeeHoursPerRoleKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 18);
    bool SeeActiveDelayedProjectsKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 19);
    bool SeeActiveDelayedProjectsTypesCounterKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 23);
    bool SeeAllProjectsMissedDeadLineKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 20);
    bool SeeEmployeeTurnoverKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 21);
    bool SeeMyProjectsMissedDeadLineKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 22);
    bool SeeTenderTableKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 25);
    bool SeeDelayedPaymentsKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 26);
    bool SeePendingsPaymentsKPI => _sharedAuthData.Permissions.Any(p => p.Ord == 27);
    bool SeeNextYearIncome => _sharedAuthData.Permissions.Any(p => p.Ord == 34);
    bool SeeEstimatedInvoicing => _sharedAuthData.Permissions.Any(p => p.Ord == 41);
    bool SeeUnpaidPaidInvoices => _sharedAuthData.Permissions.Any(p => p.Ord == 42);
    #endregion


    #region Tab Actions
    bool[] tabs = new bool[50];

    private void TabMenuClick(MouseEventArgs e, int tabIndex)
    {
        for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
        tabs[tabIndex] = true;
    }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            tabs[0] = true;
            StateHasChanged();
            await MicrosoftTeams.InitializeTooltips();
        }
    }

}
