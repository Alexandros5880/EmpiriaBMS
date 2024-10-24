﻿using EmpiriaBMS.Core.Dtos.KPIS;
using EmpiriaBMS.Front.Components.KPIS.Contract;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class TenderTable : IKpiCompoment
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    public string Title => "Tender Table";

    private IQueryable<TenderDataDto> _data;
    IQueryable<TenderDataDto>? FilteredItems => _data?.Where(x => x.ProjectName.Contains(_nameFilter, StringComparison.CurrentCultureIgnoreCase));

    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
    private string _nameFilter = string.Empty;

    private bool _showClient = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getData();
            StateHasChanged();
        }
    }

    private async Task _getData()
    {
        _data = await _dataProvider.KPIS.GetTenderTable(StartDate?.Date, EndDate?.Date);
    }

    private void HandleFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _nameFilter = value;
        }
        else if (string.IsNullOrWhiteSpace(_nameFilter) || string.IsNullOrEmpty(_nameFilter))
        {
            _nameFilter = string.Empty;
        }
    }

    private void HandleRowFocus(FluentDataGridRow<TenderDataDto> row)
    {
        //Console.WriteLine($"Row focused: {row.Item?.ProjectStage}");
    }

}
