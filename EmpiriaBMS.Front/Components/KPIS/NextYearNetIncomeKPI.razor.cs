namespace EmpiriaBMS.Front.Components.KPIS;

public partial class NextYearNetIncomeKPI
{

    private double _nextYearNetIncome = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _nextYearNetIncome = await _dataProvider.KPIS.GetNextYearNetIncome();
        }
    }

}
