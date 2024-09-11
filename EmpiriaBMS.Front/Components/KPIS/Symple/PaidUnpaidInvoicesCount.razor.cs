namespace EmpiriaBMS.Front.Components.KPIS.Symple;

public partial class PaidUnpaidInvoicesCount
{

    private int paid = 0;
    private int unpaid = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var tuple = await _dataProvider.KPIS.GetPaidUnpaidInvoiceCount();
            paid = tuple.Paid;
            unpaid = tuple.Unpaid;
            StateHasChanged();
        }
    }

}