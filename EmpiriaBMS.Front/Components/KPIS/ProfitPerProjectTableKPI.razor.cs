using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using EmpiriaBMS.Core.Dtos.KPIS;
using EmpiriaBMS.Front.Horizontal;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.KPIS;

public partial class ProfitPerProjectTableKPI
{
    [Parameter]
    public DateTimeOffset? StartDate { get; set; }

    [Parameter]
    public DateTimeOffset? EndDate { get; set; }

    private IQueryable<TenderDataDto> _data = null;
    
    IQueryable<TenderDataDto>? FilteredItems => 
        _data?.Where(x => x.ProjectName.Contains(_nameFilter, StringComparison.CurrentCultureIgnoreCase));

    private string _nameFilter = string.Empty;

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
        var userId = _sharedAuthData.LogedUser.Id;
        var data = await _dataProvider.KPIS.GetProfitPerProject(userId, StartDate?.Date, EndDate?.Date);

        _data = data.Select(d => new TenderDataDto()
        {
            ProjectName = d.Key,
            Profit = d.Value
        }).AsQueryable();
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

    public class TenderDataDto
    {
        public string ProjectName { get; set; }
        public double Profit { get; set; } // Profit field
    }

}
