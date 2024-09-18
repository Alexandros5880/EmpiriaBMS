using EmpiriaBMS.Front.Interop.TeamsSDK;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components.KPIS.Simple;

public partial class PaidUnpaidInvoicesCount
{
    private bool _startLoading = true;

    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private int paid = 0;
    private int unpaid = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await MicrosoftTeams.InitializeTooltips();
            var tuple = await _dataProvider.KPIS.GetPaidUnpaidInvoiceCount(StartDate?.Date, EndDate?.Date);
            paid = tuple.Paid;
            unpaid = tuple.Unpaid;
            _startLoading = false;
            StateHasChanged();
        }
    }

}