using EmpiriaBMS.Front.Interop.TeamsSDK;
using Microsoft.JSInterop;
using System.Globalization;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.KPIS.Simple;

public partial class EstimatedInvoicing
{
    private bool _startLoading = true;

    private double _estimatedInvoicing = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await MicrosoftTeams.InitializeTooltips();
            _estimatedInvoicing = await _dataProvider.KPIS.GetEstimatedInvoicing();
            _startLoading = false;
            StateHasChanged();
        }
    }

}