using EmpiriaBMS.Front.Interop.TeamsSDK;
using Microsoft.JSInterop;
using System.Globalization;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class EstimatedInvoicing
{

    private double _estimatedInvoicing = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _estimatedInvoicing = await _dataProvider.KPIS.GetEstimatedInvoicing();
            StateHasChanged();
        }
    }

}