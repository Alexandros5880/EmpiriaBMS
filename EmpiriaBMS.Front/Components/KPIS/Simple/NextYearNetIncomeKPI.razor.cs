﻿using EmpiriaBMS.Front.Interop.TeamsSDK;
using Microsoft.Recognizers.Text;
using System.Globalization;

namespace EmpiriaBMS.Front.Components.KPIS.Simple;

public partial class NextYearNetIncomeKPI
{
    private bool _startLoading = true;
    private double _nextYearNetIncome = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await MicrosoftTeams.InitializeTooltips();
            _nextYearNetIncome = await _dataProvider.KPIS.GetNextYearNetIncome();
            _startLoading = false;
            StateHasChanged();
        }
    }

}
